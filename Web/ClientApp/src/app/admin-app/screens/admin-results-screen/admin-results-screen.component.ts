import {Component, OnInit} from '@angular/core';
import {StateServiceAdmin} from "../../services/state.service-admin";
import {Router} from "@angular/router";
import {ApiServiceAdmin} from "../../services/api.service-admin";

@Component({
  selector: 'app-admin-results-screen',
  templateUrl: './admin-results-screen.component.html',
  styleUrls: ['./admin-results-screen.component.css']
})
export class AdminResultsScreenComponent implements OnInit {

  question = this.stateService.getCurrentQuestionAfterCount();

  constructor(public stateService: StateServiceAdmin,
              public apiService: ApiServiceAdmin,
              private router: Router) {
    console.log(this.question);
  }

  ngOnInit(): void {

  }

  goToRankings() {
    if (this.stateService.getCurrentQuestionNumber() === this.stateService.getQuestionsAnswersState().length) {
      this.apiService.putGameEnd(this.stateService.game.id).subscribe();
      this.router.navigate(["admin/game-over-screen"]);
    } else {
      this.router.navigate(["admin/rankings-screen"]);
    }
  }
}
