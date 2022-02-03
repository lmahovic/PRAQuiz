import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-app-selection-screen',
  templateUrl: './app-selection-screen.component.html',
  styleUrls: ['./app-selection-screen.component.css']
})
export class AppSelectionScreenComponent implements OnInit {

  constructor(private readonly router: Router) { }

  ngOnInit(): void {
  }

  goToAdmin() {
    this.router.navigate(['admin/entryForm/Email']);
  }

  goToPlayer() {
    this.router.navigate(['player/entryForm/GamePin']);
  }
}
