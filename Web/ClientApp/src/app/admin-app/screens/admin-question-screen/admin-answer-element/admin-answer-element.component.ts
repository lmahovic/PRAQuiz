import {Component, Input, OnInit} from '@angular/core';
import {AnswerViewModel} from "../../../../player-app/models/answer-view-model";

@Component({
  selector: 'app-admin-answer-element',
  templateUrl: './admin-answer-element.component.html',
  styleUrls: ['./admin-answer-element.component.css']
})
export class AdminAnswerElementComponent implements OnInit {

  // @ts-ignore
  @Input() answer : AnswerViewModel;
  @Input() isResultView=false;

  constructor() { }

  ngOnInit(): void {

  }

}
