import {Component, OnInit} from "@angular/core";
import {QuestionViewModel} from "../../models/question-view-model";
import {ApiService} from "../../services/api.service";
import {StateService} from "../../services/state.service";
import {Router} from "@angular/router";
import {interval} from "rxjs";

@Component({
  selector: 'app-lobby-screen',
  templateUrl: './lobby-screen.component.html',
  styleUrls: ['./lobby-screen.component.css']
})
export class LobbyScreenComponent implements OnInit {

  constructor(private apiService: ApiService,
              public stateService: StateService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.stateService.showStatusBar = false;
    this.stateService.showLanguageSelector = false;
    this.apiService.getQuestions(this.stateService.getGame().quizId).subscribe(
      (response) => {
        // @ts-ignore
        this.stateService.saveQuestionsAnswersState(response.body);

        console.log(this.stateService.getQuestionsAnswersState())

        const playerId = this.stateService.getPlayer().id;

        //@todo obriši test
        // //TEST
        // const testPlayer : PlayerViewModel = {
        //   id:1,
        //   gameId:1,
        //   nickname: "test!"
        // }
        // const playerId=testPlayer.id;
        // this.stateService.setPlayer(testPlayer);


        const questionId = (this.stateService.getCurrentQuestionBeforeCount() as QuestionViewModel).id;

        this.checkForNextQuestionLobby(playerId, questionId);
      });
  }

  private checkForNextQuestionLobby(playerId: number, questionId: number) {
    const interval$ = interval(ApiService.pingInterval);

    const sub = interval$.subscribe(() => {
      this.apiService.getQuestionStatus(playerId, questionId)
        .subscribe(response => {
          console.log("Ping iz lobbya - " + playerId + " " + questionId);
          if (response.body !== 0) {
            sub.unsubscribe();
            this.stateService.lastPlayerAnswer.id = (response.body as number);
            this.stateService.statusBarLobbyEntered = true;
            this.router.navigate(["player/next-question"]);
          }
        });
    });
  }
}
