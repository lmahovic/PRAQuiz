import {Component, OnInit} from "@angular/core";
import {timer} from "rxjs";
import {StateService} from "../../services/state.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-next-question-countdown',
  templateUrl: './next-question-countdown.component.html',
  styleUrls: ['./next-question-countdown.component.css']
})
export class NextQuestionCountdownComponent implements OnInit {

  countdown: number = 5;

  constructor(private router: Router,
              private stateService: StateService) {
  }

  ngOnInit(): void {
    this.stateService.increaseQuestionCounter();
    const countDownStartTimerSub = timer(1000, 1000).subscribe(
      () => {
        this.countdown--;
        if (this.countdown === 0) {
          countDownStartTimerSub.unsubscribe();
          this.router.navigate(["player/question-screen"]);
        }
      }
    );


  }
}
