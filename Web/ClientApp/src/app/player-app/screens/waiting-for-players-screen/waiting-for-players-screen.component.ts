import {Component, OnInit} from "@angular/core";
import {ApiService} from "../../services/api.service";
import {StateService} from "../../services/state.service";
import {Router} from "@angular/router";
import {interval} from "rxjs";

@Component({
  selector: 'app-waiting-for-players-screen',
  templateUrl: './waiting-for-players-screen.component.html',
  styleUrls: ['./waiting-for-players-screen.component.css']
})
export class WaitingForPlayersScreenComponent implements OnInit {

  constructor(private apiService: ApiService,
              private stateService: StateService,
              private router: Router) {
  }

  ngOnInit(): void {
    const interval$ = interval(ApiService.pingInterval);
    const intervalSub = interval$.subscribe(() =>
      this.apiService.checkOtherPlayersNotWaiting(this.stateService.lastPlayerAnswer.id)
        .subscribe(
          (response) => {
            if (response) {
              intervalSub.unsubscribe();
              this.router.navigate(["player/info-screen"]);
            }
          }
        )
    );
  }

}
