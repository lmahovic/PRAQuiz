import {Injectable} from '@angular/core';
import {GameViewModel} from "../models/game-view-model";
import {PlayerViewModel} from "../models/player-view-model";
import {QuestionViewModel} from "../models/question-view-model";
import {PlayerAnswerViewModel} from "../models/player-answer-view-model";

@Injectable({
  providedIn: 'root'
})
export class StateService {

  private game: GameViewModel | any;
  private player: PlayerViewModel | any;
  private _lastPlayerAnswer: PlayerAnswerViewModel = {
    id: 0,
    answerId: 0,
    points: 0,
    answerTime: 0,
    playerId: 0,
    questionId: 0
  }
  private _showLanguageSelector = true;
  private _languageSelectorExpanded = false;

  private _showStatusBar = false;
  private _statusBarLobbyEntered = false;

  private currentQuestion = 0;
  private questions: QuestionViewModel[] = [];

  private _totalPoints = 0;
  private _gamePin!: number;


  constructor() {
  }

  get gamePin(): number {
    return this._gamePin;
  }

  set gamePin(value: number) {
    this._gamePin = value;
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

  get lastPlayerAnswer(): PlayerAnswerViewModel {
    return this._lastPlayerAnswer;
  }

  set lastPlayerAnswer(value: PlayerAnswerViewModel) {
    this._lastPlayerAnswer = value;
  }

  getGame(): GameViewModel {
    return this.game;
  }

  setGame(game: GameViewModel) {
    this.game = game;
  }

  getPlayer(): PlayerViewModel {
    return this.player;
  }

  setPlayer(player: PlayerViewModel | null) {
    this.player = player;
  }

  saveQuestionsAnswersState(questions: QuestionViewModel[]) {
    this.questions = questions;
  }

  getQuestionsAnswersState(): QuestionViewModel[] {
    return this.questions;
  }

  increaseQuestionCounter() {
    this.currentQuestion++;
  }

  getCurrentQuestionNumber(): number {
    return this.currentQuestion;
  }

  getCurrentQuestionBeforeCount(): QuestionViewModel {
    return this.questions[this.currentQuestion];
  }

  getCurrentQuestionAfterCount(): QuestionViewModel {
    return this.questions[this.currentQuestion-1];
  }

  addToTotalPoints(points: number) {
    this.lastPlayerAnswer.points = points;
    this._totalPoints += points;
  }
}
