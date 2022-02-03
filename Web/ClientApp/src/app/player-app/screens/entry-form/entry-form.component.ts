import {Component, OnInit, ViewChild} from "@angular/core";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {ApiService} from "../../services/api.service";
import {StateService} from "../../services/state.service";
import {NgForm} from "@angular/forms";
import {PlayerViewModel} from "../../models/player-view-model";


@Component({
  selector: 'app-entry-form',
  templateUrl: './entry-form.component.html',
  styleUrls: ['./entry-form.component.css']
})
export class EntryFormComponent implements OnInit {

  parameter: string | undefined;
  @ViewChild('f') form: NgForm | undefined
  parameterName: string | undefined;
  serverOk = true;
  serverErrorMessage : string | undefined;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private apiService: ApiService,
              private stateService: StateService
  ) {

  }

  ngOnInit(): void {


    this.route.params.subscribe(
      (params: Params) => {
        this.parameter = params['parameter'];
        if (this.parameter === 'GamePin') {
          this.parameterName = "Game Pin";
        } else {
          console.log(this.stateService.getGame());
          this.parameterName = "Nickname";
        }
      }
    )
  };

  onSubmit() {
    // @ts-ignore
    if (this.parameter === 'GamePin') {
      this.apiService.getGameFromPin(this.form?.value.inputValue).subscribe(
        (response) => {
          this.stateService.gamePin=this.form?.value.inputValue;
          // @ts-ignore
          this.form.reset();
          this.serverOk = true;
          // @ts-ignore
          this.stateService.setGame(response)
          this.router.navigate(['player/entryForm/NickName']);
        },
        (() => {
          // @ts-ignore
          this.form.reset();
          this.serverOk = false;
          this.serverErrorMessage="Game not found!";
        }),
        ()=>{}
      )

    } else {
      const player: PlayerViewModel = {
        id: 0,
        nickname: this.form?.value.inputValue,
        gameId: this.stateService.getGame().id
      }

      this.apiService.postPlayer(player).subscribe(
        (response) => {
          // @ts-ignore
          this.form.reset();
          this.serverOk = true;
          this.stateService.setPlayer(response.body)
          console.log(this.stateService.getPlayer());
          this.router.navigate(['player/lobby-screen']);
        },
        () => {
          // @ts-ignore
          this.form.reset();
          this.serverOk = false;
          this.serverErrorMessage="Player already exists!";
        },
        ()=> {

        }
      );
    }
  }
}
