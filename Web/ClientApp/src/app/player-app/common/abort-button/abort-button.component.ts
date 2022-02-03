import {ApiService} from "../../services/api.service";
import {StateService} from "../../services/state.service";
import {Component} from "@angular/core";


@Component({
  selector: 'app-abort-button',
  templateUrl: './abort-button.component.html',
  styleUrls: ['./abort-button.component.css']
})
export class AbortButtonComponent  {

  constructor(
    private apiService: ApiService,
    public stateService: StateService) {
  }

  abortGame() {
    this.apiService.abortGameRequest(this.stateService.getPlayer().id)
      .subscribe(()=>{});
  }
}
