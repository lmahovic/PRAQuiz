import { Component, OnInit } from '@angular/core';
import {PlayerRankingsViewModel} from "../../../player-app/models/player-rankings-view-model";
import {ApiServiceAdmin} from "../../services/api.service-admin";
import {StateServiceAdmin} from "../../services/state.service-admin";
import {Router} from "@angular/router";
import {PlayerViewModel} from "../../../player-app/models/player-view-model";

@Component({
  selector: 'app-game-over',
  templateUrl: './game-over.component.html',
  styleUrls: ['./game-over.component.css']
})
export class GameOverComponent implements OnInit {

  rankings: PlayerRankingsViewModel[] = [];
  playerNamesById: string[] = [];


  constructor(private apiService: ApiServiceAdmin,
              private stateService: StateServiceAdmin,
              private router: Router) {
  }

  ngOnInit(): void {
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

  private assignRankings(response: PlayerRankingsViewModel[]) {
    this.rankings = response;
    this.getPlayerNamesById(this.stateService.players);
    console.log(this.playerNamesById);
  }

  private getPlayerNamesById(players: PlayerViewModel[]) {

    for (const ranking of this.rankings) {
      // @ts-ignore
      const playerName = players.find((x) => x.id === ranking.playerId).nickname;
      this.playerNamesById.push(playerName);
    }
  }
}
