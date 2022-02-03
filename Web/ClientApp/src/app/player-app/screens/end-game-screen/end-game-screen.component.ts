import {Component, OnInit} from "@angular/core";
import {timer} from "rxjs";
import {ApiService} from "../../services/api.service";
import {StateService} from "../../services/state.service";
import {Router} from "@angular/router";
import {PlayerRankingsViewModel} from "../../models/player-rankings-view-model";


@Component({
  selector: 'app-end-game-screen',
  templateUrl: './end-game-screen.component.html',
  styleUrls: ['./end-game-screen.component.css']
})
export class EndGameScreenComponent implements OnInit {

  public showRank = false;
  public playerRanking: PlayerRankingsViewModel | any;

  constructor(private router: Router,
              private apiService: ApiService,
              public stateService: StateService) {
  }

  ngOnInit(): void {

    this.stateService.showStatusBar=false;

    //@todo ukloni debug!
    // this.stateService.setPlayer( {
    //   id:1,
    //   gameId:1,
    //   nickname:""
    // });

    const sub = timer(ApiService.endGameReportDelay).subscribe(
      () => {
        sub.unsubscribe();
        this.apiService.getRanking(this.stateService.getPlayer().id)
          .subscribe(
            (response) => {
              // const sub = timer(1000).subscribe(
              //   () => {
              //     sub.unsubscribe();
              //   }
              // );
              this.playerRanking = response;
              this.showRank = true;
            }
          );
      }
    );
  }
}
