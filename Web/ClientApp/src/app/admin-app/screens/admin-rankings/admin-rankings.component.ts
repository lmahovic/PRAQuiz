import {Component, OnInit} from '@angular/core';
import {ApiServiceAdmin} from "../../services/api.service-admin";
import {StateServiceAdmin} from "../../services/state.service-admin";
import {Router} from "@angular/router";
import {PlayerRankingsViewModel} from "../../../player-app/models/player-rankings-view-model";
import {PlayerViewModel} from "../../../player-app/models/player-view-model";

@Component({
  selector: 'app-admin-rankings',
  templateUrl: './admin-rankings.component.html',
  styleUrls: ['./admin-rankings.component.css']
})
export class AdminRankingsComponent implements OnInit {

  rankings: PlayerRankingsViewModel[] = [];
  playerNamesById: string[] = [];


  constructor(private apiService: ApiServiceAdmin,
              private stateService: StateServiceAdmin,
              private router: Router) {
  }

  ngOnInit(): void {
    if (this.stateService.getCurrentQuestionNumber() == 1) {
      this.apiService.postRankings(this.stateService.game.id)
        .subscribe(
          (response) => {
            this.assignRankings(response);
          }
        );
    } else {
      this.apiService.putRankings(this.stateService.game.id)
        .subscribe(
          () => {
            this.apiService.getGameRanking(this.stateService.game.id)
              .subscribe(
                (response) => {
                  this.assignRankings(response)
                }
              );
          }
        );
    }
  }


  private assignRankings(response: PlayerRankingsViewModel[]) {
    this.rankings = response;
    this.getPlayerNamesById(this.stateService.players);
    console.log(this.playerNamesById);
  }

  goToAbort() {
    this.router.navigate(["admin/abort-confirmation"]);
  }

  goToNext() {
    this.processNextQuestionPosts();
  }

  public processNextQuestionPosts() {
    this.apiService.getPlayers(this.stateService.game.id).subscribe(
      (response) => {
        this.stateService.players = response;
        this.stateService.postNextPlayerQuestionAnswers().subscribe(
          (response) => {
            this.stateService.playerQuestionAnswersByQuestion
              [this.stateService.getCurrentQuestionNumber()] = response;
            console.log(this.stateService.playerQuestionAnswersByQuestion);
            this.router.navigate(["admin/next-question"]);
          }
        );
      }
    );
  }

  private getPlayerNamesById(players: PlayerViewModel[]) {

    for (const ranking of this.rankings) {
      // @ts-ignore
      const playerName = players.find((x) => x.id === ranking.playerId).nickname;
      this.playerNamesById.push(playerName);
    }
  }
}
