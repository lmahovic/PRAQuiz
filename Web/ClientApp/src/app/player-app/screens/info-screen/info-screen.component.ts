import {Component, OnInit} from "@angular/core";
import {interval, timer} from "rxjs";
import {ApiService} from "../../services/api.service";
import {StateService} from "../../services/state.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-info-screen',
  templateUrl: './info-screen.component.html',
  styleUrls: ['./info-screen.component.css']
})
export class InfoScreenComponent implements OnInit {

  isLastQuestion = false;

  constructor(private apiService: ApiService,
              public stateService: StateService,
              private router: Router) {
  }

  public waitDisplay = false;

  ngOnInit(): void {
    const sub = timer(ApiService.InfoScreenNextQuestionWaitDelay).subscribe(
      () => {
        sub.unsubscribe();
        this.waitDisplay = true;
        if (this.stateService.getCurrentQuestionNumber() === this.stateService.getQuestionsAnswersState().length) {

          this.isLastQuestion = true;
          const sub = interval(ApiService.pingInterval).subscribe(
            () => {
              this.apiService.getGameFromId(this.stateService.getGame().id).subscribe(
                (response) => {
                  console.log(response)
                  if (response.finishTime) {
                    this.router.navigate(["player/end-game-screen"]);
                  }
                }
              );
            }
          );
        } else {
          this.checkForNextQuestion(this.stateService.getPlayer().id, this.stateService.getCurrentQuestionBeforeCount().id);
        }
      }
    );
  }

  private checkForNextQuestion(playerId: number, questionId: number) {
    const interval$ = interval(ApiService.pingInterval);

    const sub = interval$.subscribe(() => {
      this.apiService.getQuestionStatus(playerId, questionId)
        .subscribe(response => {
          console.log("Ping iz lobbya - " + playerId + " " + questionId)
          if (response.body !== 0) {
            sub.unsubscribe();
            this.stateService.lastPlayerAnswer.id = (response.body as number);
            this.router.navigate(["player/next-question"]);
          }
        });
    });
  }

}
