import { Component, OnInit } from '@angular/core';
import {ApiServiceAdmin} from "../../services/api.service-admin";
import {StateServiceAdmin} from "../../services/state.service-admin";
import {Router} from "@angular/router";

@Component({
  selector: 'app-abort-confirmation-screen',
  templateUrl: './abort-confirmation-screen.component.html',
  styleUrls: ['./abort-confirmation-screen.component.css']
})
export class AbortConfirmationScreenComponent implements OnInit {

  constructor(private apiService: ApiServiceAdmin,
              public stateService: StateServiceAdmin,
              private readonly router: Router) {  }


  ngOnInit(): void {
  }

  returnToLobby() {
      this.router.navigate(["admin/lobby"]);
  }

  confirmExit() {
      this.apiService.putGameStart(this.stateService.game.id).subscribe();
      this.apiService.putGameEnd(this.stateService.game.id).subscribe();
  }
}
