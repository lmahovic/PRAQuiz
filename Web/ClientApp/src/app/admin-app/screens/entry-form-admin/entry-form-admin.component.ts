import {Component, OnInit, ViewChild} from "@angular/core";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {NgForm} from "@angular/forms";
import {StateServiceAdmin} from "../../services/state.service-admin";
import {ApiServiceAdmin} from "../../services/api.service-admin";


@Component({
  selector: 'app-entry-form-admin',
  templateUrl: './entry-form-admin.component.html',
  styleUrls: ['./entry-form-admin.component.css']
})
export class EntryFormAdminComponent implements OnInit {

  parameter: string | undefined;
  @ViewChild('f') form: NgForm | undefined
  parameterName: string | undefined;
  serverOk = true;
  serverErrorMessage: string | undefined;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private apiService: ApiServiceAdmin,
              private stateService: StateServiceAdmin
  ) {

  }

  ngOnInit(): void {


    this.route.params.subscribe(
      (params: Params) => {
        this.parameter = params['parameter'];
        if (this.parameter === 'Email') {
          this.parameterName = "Email";
        } else {
          console.log(this.stateService.getAuthor());
          this.parameterName = "Password";
        }
      }
    )
  };

  onSubmit() {
    // @ts-ignore
    if (this.parameter === 'Email') {
      this.apiService.checkEmail(this.form?.value.inputValue).subscribe(
        (response) => {
          // @ts-ignore
          this.form.reset();
          this.serverOk = true;
          // @ts-ignore
          this.stateService.setAuthor(response.body)
          this.router.navigate(['admin/entryForm/Password']);
        },
        (() => {
          // @ts-ignore
          this.form.reset();
          this.serverOk = false;
          this.serverErrorMessage = "Author with specified email not found!";
        }),
        () => {
        }
      )

    } else {

      const password = this.form?.value.inputValue;

      this.apiService.checkPassword(this.stateService.getAuthor().id, password).subscribe(
        (response) => {
          // @ts-ignore
          this.form.reset();
          if (response) {
            this.serverOk = true;
            console.log(this.stateService.getAuthor());
            this.router.navigate(['admin/quiz-select']);
          }
          else {
            this.serverOk = false;
            this.serverErrorMessage = "Incorrect password!";
          }


        },
        () => {
          // @ts-ignore
          this.form.reset();
          this.serverOk = false;
          this.serverErrorMessage = "Author not found!";
        },
        () => {

        }
      );
    }
  }
}
