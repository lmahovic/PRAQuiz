import {Component, OnInit} from '@angular/core';
import {ApiServiceAdmin} from "../../services/api.service-admin";
import {StateServiceAdmin} from "../../services/state.service-admin";
import {Router} from "@angular/router";
import {QuizViewModel} from "../../../player-app/models/quiz-view-model";

@Component({
  selector: 'app-admin-quiz-select-screen',
  templateUrl: './admin-quiz-select-screen.component.html',
  styleUrls: ['./admin-quiz-select-screen.component.css']
})
export class AdminQuizSelectScreenComponent implements OnInit {

  constructor(private apiService: ApiServiceAdmin,
              public stateService: StateServiceAdmin,
              private readonly router: Router) {
  }

  ngOnInit(): void {
    this.apiService.getQuizzes(this.stateService.getAuthor().id).subscribe(
      (response) => {
        for (const quizViewModel of response) {
          this.stateService.quizzes.push(quizViewModel);
        }
        this.stateService.selectedQuiz=this.stateService.quizzes[0].id;
        console.log(this.stateService.selectedQuiz)
      });
  }

  selectQuiz(quiz: string) {
    this.stateService.selectedQuiz=<number><unknown>quiz;
    console.log(this.stateService.selectedQuiz);
  }


  confirmQuizSelection() {
    this.apiService.postGame(this.stateService.selectedQuiz).subscribe(
      (response) => {
        this.stateService.game = response;
        console.log(this.stateService.game);
        this.router.navigate(["admin/lobby"]);
      }
    );
  }
}
