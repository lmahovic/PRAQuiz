import {Component, Input, OnInit} from '@angular/core';
import {ApiServiceAdmin} from "../../services/api.service-admin";
import {StateServiceAdmin} from "../../services/state.service-admin";
import {Router} from "@angular/router";

@Component({
  selector: 'app-admin-info-screen',
  templateUrl: './admin-info-screen.component.html',
  styleUrls: ['./admin-info-screen.component.css']
})
export class AdminInfoScreenComponent implements OnInit {

  constructor(private apiService: ApiServiceAdmin,
              public stateService: StateServiceAdmin,
              readonly router: Router) {
  }

  ngOnInit(): void {
  }

  goToResults() {
    this.router.navigate(["admin/result-screen"]);
  }
}
