import {EndGameScreenComponent} from "./player-app/screens/end-game-screen/end-game-screen.component";
import {
  NextQuestionCountdownComponent
} from "./player-app/screens/next-question-countdown/next-question-countdown.component";
import {LobbyScreenComponent} from "./player-app/screens/lobby-screen/lobby-screen.component";
import {RouterModule, Routes} from "@angular/router";
import {QuestionScreenComponent} from "./player-app/screens/question-screen/question-screen.component";
import {InfoScreenComponent} from "./player-app/screens/info-screen/info-screen.component";
import {
  WaitingForPlayersScreenComponent
} from "./player-app/screens/waiting-for-players-screen/waiting-for-players-screen.component";
import {NgModule} from "@angular/core";
import {EntryFormComponent} from "./player-app/screens/entry-form/entry-form.component";
import {EntryFormAdminComponent} from "./admin-app/screens/entry-form-admin/entry-form-admin.component";
import {AppSelectionScreenComponent} from "./common/app-selection-screen/app-selection-screen.component";
import {
  AdminQuizSelectScreenComponent
} from "./admin-app/screens/admin-quiz-select-screen/admin-quiz-select-screen.component";
import {AdminLobbyScreenComponent} from "./admin-app/screens/admin-lobby-screen/admin-lobby-screen.component";
import {
  AbortConfirmationScreenComponent
} from "./admin-app/screens/abort-confirmation-screen/abort-confirmation-screen.component";
import {AdminNextQuestionComponent} from "./admin-app/screens/admin-next-question/admin-next-question.component";
import {AdminQuestionScreenComponent} from "./admin-app/screens/admin-question-screen/admin-question-screen.component";
import {AdminResultsScreenComponent} from "./admin-app/screens/admin-results-screen/admin-results-screen.component";
import {AdminInfoScreenComponent} from "./admin-app/screens/admin-info-screen/admin-info-screen.component";
import {AdminRankingsComponent} from "./admin-app/screens/admin-rankings/admin-rankings.component";
import {GameOverComponent} from "./admin-app/screens/game-over/game-over.component";


const routes: Routes = [
  {path: "player/entryForm/:parameter", component: EntryFormComponent},
  {path: "player/lobby-screen", component: LobbyScreenComponent},
  {path: "player/next-question", component: NextQuestionCountdownComponent},
  {path: "player/question-screen", component: QuestionScreenComponent},
  {path: "player/info-screen", component: InfoScreenComponent},
  {path: "player/wait-screen", component: WaitingForPlayersScreenComponent},
  {path: "player/end-game-screen", component: EndGameScreenComponent},


  {path: "admin/entryForm/:parameter", component: EntryFormAdminComponent},
  {path: "admin/quiz-select", component: AdminQuizSelectScreenComponent},
  {path: "admin/lobby", component: AdminLobbyScreenComponent},
  {path: "admin/abort-confirmation", component: AbortConfirmationScreenComponent},
  {path: "admin/next-question", component: AdminNextQuestionComponent},
  {path: "admin/question-screen", component: AdminQuestionScreenComponent},
  {path: "admin/result-screen", component: AdminResultsScreenComponent},
  {path: "admin/info-screen", component: AdminInfoScreenComponent},
  {path: "admin/rankings-screen", component: AdminRankingsComponent},
  {path: "admin/game-over-screen", component: GameOverComponent},

  {path: "app-selection-screen", component: AppSelectionScreenComponent},
  {path: "**", redirectTo: "app-selection-screen", pathMatch: "full"},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
