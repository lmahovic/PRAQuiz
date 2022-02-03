import {Component, OnInit} from "@angular/core";
import {QuestionViewModel} from "../../models/question-view-model";
import {ApiService} from "../../services/api.service";
import {StateService} from "../../services/state.service";
import {Router} from "@angular/router";
import {interval, Subscription} from "rxjs";

@Component({
  selector: 'app-question-screen',
  templateUrl: './question-screen.component.html',
  styleUrls: ['./question-screen.component.css']
})
export class QuestionScreenComponent implements OnInit {

  // @ts-ignore
  public question: QuestionViewModel;
  remainingTime: number = 0;
  private secondIntervalSub: Subscription | undefined;
  private startTime: Date | undefined;

  constructor(private apiService: ApiService,
              private stateService: StateService,
              private router: Router) {
  }

  ngOnInit(): void {

    this.question = this.stateService.getCurrentQuestionAfterCount();
    this.remainingTime = this.question.timeLimit;

    this.startTime = new Date();
    const secondInterval$ = interval(1000);

    this.secondIntervalSub = secondInterval$.subscribe(
      () => {
        this.remainingTime--;
        if (this.remainingTime === 0) {
          this.processPointsUpdate(0, this.question.timeLimit * 1000);
        }
      });
  }

  processAnswer(selectedAnswerId: number) {

    const answerTime = new Date();
    const answerTimeDiff = answerTime.getTime() - (this.startTime as Date).getTime();

    this.processPointsUpdate(selectedAnswerId, answerTimeDiff);
  }

  private processPointsUpdate(selectedAnswerId: number, answerTimeDiff: number) {

    this.secondIntervalSub?.unsubscribe();

    this.stateService.lastPlayerAnswer.answerId = selectedAnswerId;
    this.stateService.lastPlayerAnswer.answerTime = answerTimeDiff;
    this.stateService.lastPlayerAnswer.playerId = this.stateService.getPlayer().id;
    this.stateService.lastPlayerAnswer.points = 0;
    this.stateService.lastPlayerAnswer.questionId = this.question.id;

    this.apiService.putAnswer(this.stateService.lastPlayerAnswer).subscribe(
      points => {
        this.stateService.addToTotalPoints(points);
        this.apiService.checkOtherPlayersNotWaiting(this.stateService.lastPlayerAnswer.id).subscribe(
          (response) => {
            if (response) {
              this.router.navigate(["player/info-screen"]);
            } else {
              this.router.navigate(["player/wait-screen"]);
            }
          }
        )
      }
    );
  }
}
