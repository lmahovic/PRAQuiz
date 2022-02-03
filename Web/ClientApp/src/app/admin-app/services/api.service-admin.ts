import {Injectable} from "@angular/core";
import {QuestionViewModel} from "../../player-app/models/question-view-model";
import {PlayerAnswerViewModel} from "../../player-app/models/player-answer-view-model";
import {HttpClient} from "@angular/common/http";
import {PlayerRankingsViewModel} from "../../player-app/models/player-rankings-view-model";
import {PlayerViewModel} from "../../player-app/models/player-view-model";
import {AuthorViewModel} from "../../player-app/models/author-view-model";
import {QuizViewModel} from "../../player-app/models/quiz-view-model";
import {GameViewModel} from "../../player-app/models/game-view-model";
import {PlayerAnswerCreation} from "../../player-app/models/player-answer-creation";

@Injectable({
  providedIn: 'root'
})
export class ApiServiceAdmin {

  public static readonly pingInterval = 300;
  private readonly apiUrl = 'https://localhost:5001/api';


  constructor(private client: HttpClient) {
  }

  checkEmail(email: string) {
    return this.client.get<AuthorViewModel>(this.apiUrl + "/Authors/" + email, {observe: 'response'})
  }

  postPlayer(player: PlayerViewModel) {
    return this.client.post<PlayerViewModel>(this.apiUrl + "/players/", player, {observe: 'response'})
  }

  getQuestions(quizId: number) {
    return this.client.get<QuestionViewModel[]>(this.apiUrl + "/Questions/" + quizId)
  }

  getQuestionStatus(playerId: number, questionId: number) {
    return this.client.get<number>(this.apiUrl + '/PlayerQuestionAnswers/' + playerId + '/' + questionId, {
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

  checkPassword(id: number, password: string) {
    return this.client.get<boolean>(this.apiUrl + '/Authors/' + id, {
      params: {
        password: password
      }
    });
  }

  getQuizzes(id: number) {
    return this.client.get<QuizViewModel[]>(this.apiUrl + '/Quizzes/' + id);
  }

  postGame(selectedQuizId: number) {
    return this.client.post<GameViewModel>(this.apiUrl + "/Games/" + selectedQuizId, {observe: 'response'})
  }

  getPlayers(gameId: number) {
    return this.client.get<PlayerViewModel[]>(this.apiUrl + '/Players/', {params: {gameId: gameId}});
  }

  putGameStart(gameId: number) {
    return this.client.put<void>(this.apiUrl + '/Games/' + gameId, null);
  }

  putGameEnd(gameId: number) {
    return this.client.put<void>(this.apiUrl + '/Games', null, {params: {id: gameId}});
  }

  postPlayerAnswers(playerQuestionAnswers: PlayerAnswerCreation[]) {
    return this.client.post<PlayerAnswerViewModel[]>(this.apiUrl + "/PlayerQuestionAnswers", playerQuestionAnswers);
  }

  getPlayerQuestionAnswers(gameId: number, questionId: number) {
    return this.client.get<PlayerAnswerViewModel[]>(this.apiUrl + '/PlayerQuestionAnswers', {
      params: {
        gameId: gameId,
        questionId: questionId
      }
    });
  }

  postRankings(id: number) {
    return this.client.post<PlayerRankingsViewModel[]>(this.apiUrl + "/PlayerRankings/" + id, null);
  }

  putRankings(id: number) {
    return this.client.put<void>(this.apiUrl + "/PlayerRankings/" + id, null);
  }

  getGameRanking(id: number) {
    return this.client.get<PlayerRankingsViewModel[]>(this.apiUrl + "/PlayerRankings", {params: {gameId: id}});
  }
}
