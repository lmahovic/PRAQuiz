import {EndGameScreenComponent} from "./player-app/screens/end-game-screen/end-game-screen.component";
import {
  NextQuestionCountdownComponent
} from "./player-app/screens/next-question-countdown/next-question-countdown.component";
import {LanguageTogglerComponent} from "./player-app/common/language-toggler/language-toggler.component";
import {LobbyScreenComponent} from "./player-app/screens/lobby-screen/lobby-screen.component";
import {StatusBarComponent} from "./player-app/common/status-bar/status-bar.component";
import {AnswerElementComponent} from "./player-app/screens/question-screen/answer-element/answer-element.component";
import {NgModule} from "@angular/core";
import {FormsModule} from "@angular/forms";
import {EntryFormComponent} from "./player-app/screens/entry-form/entry-form.component";
import {AbortButtonComponent} from "./player-app/common/abort-button/abort-button.component";
import {BrowserModule} from "@angular/platform-browser";
import {AppRoutingModule} from "./app-routing.module";
import {AppComponent} from "./app.component";
import {QuestionScreenComponent} from "./player-app/screens/question-screen/question-screen.component";
import {InfoScreenComponent} from "./player-app/screens/info-screen/info-screen.component";
import {
  WaitingForPlayersScreenComponent
} from "./player-app/screens/waiting-for-players-screen/waiting-for-players-screen.component";
import {HttpClientModule} from "@angular/common/http";
import {EntryFormAdminComponent} from "./admin-app/screens/entry-form-admin/entry-form-admin.component";
import { AppSelectionScreenComponent } from './common/app-selection-screen/app-selection-screen.component';
import { AdminLobbyScreenComponent } from './admin-app/screens/admin-lobby-screen/admin-lobby-screen.component';
import { AdminQuizSelectScreenComponent } from './admin-app/screens/admin-quiz-select-screen/admin-quiz-select-screen.component';
import { AbortConfirmationScreenComponent } from './admin-app/screens/abort-confirmation-screen/abort-confirmation-screen.component';
import { AdminNextQuestionComponent } from './admin-app/screens/admin-next-question/admin-next-question.component';
import { AdminQuestionScreenComponent } from './admin-app/screens/admin-question-screen/admin-question-screen.component';
import { AdminAnswerElementComponent } from './admin-app/screens/admin-question-screen/admin-answer-element/admin-answer-element.component';
import { AdminResultsScreenComponent } from './admin-app/screens/admin-results-screen/admin-results-screen.component';
import { AdminInfoScreenComponent } from './admin-app/screens/admin-info-screen/admin-info-screen.component';
import { AdminResultCardComponent } from './admin-app/screens/admin-results-screen/admin-result-card/admin-result-card.component';
import { AdminRankingsComponent } from './admin-app/screens/admin-rankings/admin-rankings.component';
import { GameOverComponent } from './admin-app/screens/game-over/game-over.component';

@NgModule({
  declarations: [
    AppComponent,
    EntryFormComponent,
    LobbyScreenComponent,
    NextQuestionCountdownComponent,
    QuestionScreenComponent,
    AnswerElementComponent,
    InfoScreenComponent,
    WaitingForPlayersScreenComponent,
    EndGameScreenComponent,
    LanguageTogglerComponent,
    StatusBarComponent,
    AbortButtonComponent,

    EntryFormAdminComponent,
     AppSelectionScreenComponent,
     AdminLobbyScreenComponent,
     AdminQuizSelectScreenComponent,
     AbortConfirmationScreenComponent,
     AdminNextQuestionComponent,
     AdminQuestionScreenComponent,
     AdminAnswerElementComponent,
     AdminResultsScreenComponent,
     AdminInfoScreenComponent,
     AdminResultCardComponent,
     AdminRankingsComponent,
     GameOverComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
