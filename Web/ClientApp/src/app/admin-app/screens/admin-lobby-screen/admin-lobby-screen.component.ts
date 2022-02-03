import {Component, OnInit} from '@angular/core';
import {ApiServiceAdmin} from "../../services/api.service-admin";
import {StateServiceAdmin} from "../../services/state.service-admin";
import {Router} from "@angular/router";
import {Subscription, timer} from "rxjs";

const adminRefreshCounterTime = 10;

@Component({
  selector: 'app-admin-lobby-screen',
  templateUrl: './admin-lobby-screen.component.html',
  styleUrls: ['./admin-lobby-screen.component.css']
})
export class AdminLobbyScreenComponent implements OnInit {

  constructor(private apiService: ApiServiceAdmin,
              public stateService: StateServiceAdmin,
              private readonly router: Router) {
  }

  refreshCounter = adminRefreshCounterTime;
  refreshSub: Subscription | undefined;
  refreshIndicatorSub: Subscription | undefined;

  ngOnInit(): void {

    this.startAutoPlayerRefresh();
    this.startRefreshTimeIndicator();
  }

  private startRefreshTimeIndicator() {
    this.refreshIndicatorSub = timer(1000, 1000).subscribe(
      () => {
        if (this.refreshCounter === 1) {
          this.refreshCounter = adminRefreshCounterTime;
        } else {
          this.refreshCounter--;
        }
      }
    );
  }

  private startAutoPlayerRefresh() {
    this.refreshSub = timer(0, 10000).subscribe(
      () => {
        this.refreshPlayers()
      }
    );
  }

  private refreshPlayers() {
    this.apiService.getPlayers(this.stateService.game.id).subscribe(
      (response) => {
        this.stateService.players = response;
        console.log(this.stateService.players);
        this.stateService.noPlayers = response.length;
      }
    );
  }

  openAbortConfirmationDialog() {
    this.router.navigate(["admin/abort-confirmation"]);
  }

  manualRefresh() {
    this.refreshCounter = adminRefreshCounterTime;
    this.refreshSub?.unsubscribe();
    this.refreshIndicatorSub?.unsubscribe();
    this.startAutoPlayerRefresh();
    this.startRefreshTimeIndicator();
  }

  startQuiz() {
    this.apiService.putGameStart(this.stateService.game.id).subscribe();
    this.refreshSub?.unsubscribe();
    this.refreshIndicatorSub?.unsubscribe();

    this.apiService.getQuestions(this.stateService.selectedQuiz).subscribe(
      (response) => {

        this.stateService.saveQuestionsAnswersState(response);
        console.log(this.stateService.getQuestionsAnswersState())

        this.processNextQuestionPost();
      });
  }

  private processNextQuestionPost() {
    this.stateService.postNextPlayerQuestionAnswers().subscribe(
      (response) => {
        this.stateService.playerQuestionAnswersByQuestion
          [this.stateService.getCurrentQuestionNumber()] = response;
        console.log(this.stateService.playerQuestionAnswersByQuestion);
        this.router.navigate(["admin/next-question"]);
      }
    );
  }
}


