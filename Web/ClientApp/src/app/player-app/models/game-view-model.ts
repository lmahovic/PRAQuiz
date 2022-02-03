export interface GameViewModel {
  id: number,
  quizId : number,
  gamePin : string,
  startTime : Date | null,
  finishTime : Date | null
}
