import {Component, Input, OnInit} from '@angular/core';
import {AnswerViewModel} from "../../../../player-app/models/answer-view-model";
import {StateServiceAdmin} from "../../../services/state.service-admin";

@Component({
  selector: 'app-admin-result-card',
  templateUrl: './admin-result-card.component.html',
  styleUrls: ['./admin-result-card.component.css']
})
export class AdminResultCardComponent implements OnInit {

  @Input()
  answer!: AnswerViewModel;
  answerNumber = 0;

  constructor(public stateService: StateServiceAdmin) {

  }

  ngOnInit(): void {
    this.answerNumber = this.getNoAnswers(this.answer);
  }

  getNoAnswers(answer: AnswerViewModel | undefined) {
    // @ts-ignore
    return this.stateService.playerQuestionAnswersByQuestion[this.stateService.getCurrentQuestionNumber() - 1]
      .filter((x) => x.answerId == answer?.id).length;
  }
}
