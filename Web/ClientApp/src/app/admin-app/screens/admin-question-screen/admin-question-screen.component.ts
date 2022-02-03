import {Component, OnInit} from '@angular/core';
import {QuestionViewModel} from "../../../player-app/models/question-view-model";
import {interval, Subscription} from "rxjs";
import {Router} from "@angular/router";
import {StateServiceAdmin} from "../../services/state.service-admin";
import {ApiServiceAdmin} from "../../services/api.service-admin";
import {PlayerAnswerViewModel} from "../../../player-app/models/player-answer-view-model";

@Component({
  selector: 'app-admin-question-screen',
  templateUrl: './admin-question-screen.component.html',
  styleUrls: ['./admin-question-screen.component.css']
})
export class AdminQuestionScreenComponent implements OnInit {

  // @ts-ignore
  public question: QuestionViewModel;
  remainingTime = 0;
  playersAnswered = 0;
  private secondIntervalSub: Subscription | undefined;

  constructor(private apiService: ApiServiceAdmin,
              private stateService: StateServiceAdmin,
              private router: Router) {
  }

  ngOnInit(): void {

    this.question = this.stateService.getCurrentQuestionAfterCount();
    this.remainingTime = this.question.timeLimit;

    const secondInterval$ = interval(1000);

    this.secondIntervalSub = secondInterval$.subscribe(
      () => {
        if (this.remainingTime > 0) {
          this.remainingTime--;
        }
      }
    );

    const interval$ = interval(ApiServiceAdmin.pingInterval);
    let playerAnswers: PlayerAnswerViewModel[];

    const intervalSub = interval$.subscribe(() =>
      this.apiService.getPlayerQuestionAnswers(
        this.stateService.game.id,
        this.stateService.getCurrentQuestionAfterCount().id)
        .subscribe(
          (response) => {
            playerAnswers = response;
            this.apiService.checkOtherPlayersNotWaiting(playerAnswers[0].id)
              .subscribe(
                (response) => {
                  if (response) {
                    intervalSub.unsubscribe();
                    this.stateService.isTimeUp = playerAnswers.some(x => x.answerId === null);
                    this.stateService.playerQuestionAnswersByQuestion[this.stateService.getCurrentQuestionNumber() - 1] = playerAnswers;
                    this.router.navigate(["admin/info-screen"]);
                  }
                }
              );
          }
        )
    );
  }
}
