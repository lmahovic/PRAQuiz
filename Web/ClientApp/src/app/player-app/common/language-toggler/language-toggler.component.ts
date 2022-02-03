import {Component, OnInit} from "@angular/core";
import {StateService} from "../../services/state.service";

@Component({
  selector: 'app-language-toggler',
  templateUrl: './language-toggler.component.html',
  styleUrls: ['./language-toggler.component.css']
})
export class LanguageTogglerComponent implements OnInit {

  constructor(public stateService: StateService) {
  }

  ngOnInit(): void {
  }

}
