import {AnswerViewModel} from "./answer-view-model";

export interface QuestionViewModel {
  id: number,
  questionOrder: number,
  questionText: string,
  timeLimit: number,
  answers: AnswerViewModel[],
}
