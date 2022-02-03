import {Component, EventEmitter, Input, OnInit, Output} from "@angular/core";
import {AnswerViewModel} from "../../../models/answer-view-model";

@Component({
  selector: 'app-answer-element',
  templateUrl: './answer-element.component.html',
  styleUrls: ['./answer-element.component.css']
})
export class AnswerElementComponent implements OnInit {

  // @ts-ignore
  @Input() answer : AnswerViewModel;
  @Output() selectedAnswerEvent = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

}
