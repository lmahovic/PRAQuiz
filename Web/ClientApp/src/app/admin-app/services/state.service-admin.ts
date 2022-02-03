import {Injectable} from "@angular/core";
import {QuestionViewModel} from "../../player-app/models/question-view-model";
import {PlayerAnswerViewModel} from "../../player-app/models/player-answer-view-model";
import {PlayerViewModel} from "../../player-app/models/player-view-model";
import {AuthorViewModel} from "../../player-app/models/author-view-model";
import {QuizViewModel} from "../../player-app/models/quiz-view-model";
import {GameViewModel} from "../../player-app/models/game-view-model";
import {PlayerAnswerCreation} from "../../player-app/models/player-answer-creation";
import {ApiServiceAdmin} from "./api.service-admin";
import {Observable} from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class StateServiceAdmin {

  private author: AuthorViewModel | any;
  private _quizzes: QuizViewModel[] = [];
  private _selectedQuiz: number | undefined;

  private _showLanguageSelector = true;
  private _languageSelectorExpanded = false;

  private _showStatusBar = false;
  private _statusBarLobbyEntered = false;

  private currentQuestion = 0;
  private _questions: QuestionViewModel[] = [];

  private _totalPoints = 0;
  private _game: GameViewModel | undefined;
  private _noPlayers = 0;
  private _players: PlayerViewModel[] = [];

  private _playerQuestionAnswersByQuestion: [PlayerAnswerViewModel[]] = [[]];
  private _isTimeUp: boolean =false;

  constructor(private apiService: ApiServiceAdmin) {
  }

  get isTimeUp(): boolean {
    return this._isTimeUp;
  }

  set isTimeUp(value: boolean) {
    this._isTimeUp = value;
  }

  get playerQuestionAnswersByQuestion(): PlayerAnswerViewModel[][] {
    return this._playerQuestionAnswersByQuestion;
  }

  get game(): GameViewModel {
    return <GameViewModel>this._game;
  }

  set game(value: GameViewModel) {
    this._game = value;
  }

  get noPlayers(): number {
    return this._noPlayers;
  }

  set noPlayers(value: number) {
    this._noPlayers = value;
  }

  get quizzes(): QuizViewModel[] {
    return this._quizzes;
  }

  set quizzes(value: QuizViewModel[]) {
    this._quizzes = value;
  }

  get players(): PlayerViewModel[] {
    return this._players;
  }

  set players(value: PlayerViewModel[]) {
    this._players = value;
  }

  get selectedQuiz(): number {
    return <number>this._selectedQuiz;
  }

  set selectedQuiz(value: number) {
    this._selectedQuiz = value;
  }

  get statusBarLobbyEntered(): boolean {
    return this._statusBarLobbyEntered;
  }

  set statusBarLobbyEntered(value: boolean) {
    this._statusBarLobbyEntered = value;
  }

  set showStatusBar(value: boolean) {
    this._showStatusBar = false;
  }

  get showStatusBar(): boolean {
    return this._showStatusBar;
  }

  get languageSelectorExpanded(): boolean {
    return this._languageSelectorExpanded;
  }

  set languageSelectorExpanded(value: boolean) {
    this._languageSelectorExpanded = value;
  }

  get showLanguageSelector(): boolean {
    return this._showLanguageSelector;
  }

  set showLanguageSelector(value: boolean) {
    this._showLanguageSelector = value;
  }

  get totalPoints(): number {
    return this._totalPoints;
  }


  getAuthor(): AuthorViewModel {
    return this.author;
  }

  setAuthor(author: AuthorViewModel) {
    this.author = author;
  }


  saveQuestionsAnswersState(questions: QuestionViewModel[]) {
    this._questions = questions;
  }

  getQuestionsAnswersState(): QuestionViewModel[] {
    return this._questions;
  }

  increaseQuestionCounter() {
    this.currentQuestion++;
  }

  getCurrentQuestionNumber(): number {
    return this.currentQuestion;
  }

  getCurrentQuestionBeforeCount(): QuestionViewModel {
    return this._questions[this.currentQuestion];
  }

  getCurrentQuestionAfterCount(): QuestionViewModel {
    return this._questions[this.currentQuestion - 1];
  }

  postNextPlayerQuestionAnswers(): Observable<PlayerAnswerViewModel[]> {
    const currentQuestionId = this.getCurrentQuestionBeforeCount().id;
    const playerQuestionAnswers: PlayerAnswerCreation[] = [];

    for (const player of this.players) {
      playerQuestionAnswers.push({
        playerId: player.id,
        questionId: currentQuestionId
      });
    }
    return this.apiService.postPlayerAnswers(playerQuestionAnswers);
  }
}
