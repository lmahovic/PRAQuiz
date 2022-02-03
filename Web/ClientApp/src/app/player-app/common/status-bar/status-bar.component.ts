import {Component, OnInit} from "@angular/core";
import {StateService} from "../../services/state.service";

@Component({
  selector: 'app-status-bar',
  templateUrl: './status-bar.component.html',
  styleUrls: ['./status-bar.component.css']
})
export class StatusBarComponent implements OnInit {

  constructor(public stateService: StateService) {
  }

  ngOnInit(): void {
  }

}
