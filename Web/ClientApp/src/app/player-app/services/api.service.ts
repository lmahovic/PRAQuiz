import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {GameViewModel} from "../models/game-view-model";
import {PlayerViewModel} from "../models/player-view-model";
import {QuestionViewModel} from "../models/question-view-model";
import {PlayerAnswerViewModel} from "../models/player-answer-view-model";
import {PlayerRankingsViewModel} from "../models/player-rankings-view-model";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public static readonly pingInterval = 300;
  public static readonly InfoScreenNextQuestionWaitDelay = 2000;
  public static readonly endGameReportDelay = 0;
  private readonly apiUrl = 'https://localhost:5001/api';


  constructor(private client: HttpClient) {
  }

  getGameFromPin(gamePin: string) {
    return this.client.get<GameViewModel>(this.apiUrl + "/Games", {params : {gamePin:gamePin}});
  }

  getGameFromId(gameId: number) {
    return this.client.get<GameViewModel>(this.apiUrl + "/Games/" + gameId);
  }

  postPlayer(player: PlayerViewModel) {
    return this.client.post<PlayerViewModel>(this.apiUrl + "/players/", player, {observe: 'response'})
  }

  getQuestions(quizId: number) {
    return this.client.get<QuestionViewModel[]>(this.apiUrl + "/Questions/" + quizId, {observe: 'response'})
  }

  getQuestionStatus(playerId: number, questionId: number) {
    return this.client.get<number>(this.apiUrl + '/PlayerQuestionAnswers/'+playerId+'/'+questionId, {
      // params: {
      //   playerId: playerId,
      //   questionId: questionId
      // },
      observe: 'response'
    });
  }

  putAnswer(playerAnswer: PlayerAnswerViewModel) {
    return this.client.put<number>(this.apiUrl + '/PlayerQuestionAnswers', playerAnswer);
  }

  checkOtherPlayersNotWaiting(playerAnswerId: number) {
    return this.client.get<boolean>(this.apiUrl + '/PlayerQuestionAnswers/' + playerAnswerId);
  }

  getRanking(id: number) {
    return this.client.get<PlayerRankingsViewModel>(this.apiUrl + '/PlayerRankings/' + id);
  }

  abortGameRequest(id: number) {
    return this.client.put<void>(this.apiUrl + '/Players/' + id, null);
  }
}
