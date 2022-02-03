import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {StateServiceAdmin} from "../../services/state.service-admin";
import {timer} from "rxjs";

const countdownSeconds = 5;

@Component({
  selector: 'app-admin-next-question',
  templateUrl: './admin-next-question.component.html',
  styleUrls: ['./admin-next-question.component.css']
})
export class AdminNextQuestionComponent implements OnInit {

  countdown: number = countdownSeconds;

  constructor(private router: Router,
              private stateService: StateServiceAdmin) {
  }

  ngOnInit(): void {
    this.stateService.increaseQuestionCounter();
    const countDownStartTimerSub = timer(1000, 1000).subscribe(
      () => {
        this.countdown--;
        if (this.countdown == 0) {
          countDownStartTimerSub.unsubscribe();
          this.router.navigate(["admin/question-screen"]);
        }
      }
    );
  }
}





