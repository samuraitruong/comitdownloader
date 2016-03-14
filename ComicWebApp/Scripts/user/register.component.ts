//http://blog.ng-book.com/the-ultimate-guide-to-forms-in-angular-2/
//https://medium.com/@daviddentoom/angular-2-form-validation-9b26f73fcb81#.20uoltht5
//https://github.com/angular2-school/angular2-radio-button/tree/master/modules/ng-school/controls/radio - fix radio binding.

import {Component, OnInit, AfterContentInit, Output} from 'angular2/core';
import {NgForm, FORM_DIRECTIVES, FormBuilder, Validators, ControlGroup, AbstractControl} from 'angular2/common';
import {RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router'
import * as moment from 'moment';
import {DATEPICKER_DIRECTIVES} from 'ng2-bootstrap/ng2-bootstrap';
import {User, ValidationResult} from '../models/user'
import {NavigationHelper} from '../shared/navigation.helper'
import {UserService} from './user.service'

@Component({
    selector: 'cmapp-user-register',
    templateUrl: 'views/user/register.html',
    directives: [DATEPICKER_DIRECTIVES, ROUTER_DIRECTIVES, FORM_DIRECTIVES],
    providers: [UserService]
})
export class RegisterComponent implements OnInit, AfterContentInit {
    constructor(private _nav: NavigationHelper,
        private _service: UserService,
        private _routeParams: RouteParams,
        private _formBuilder: FormBuilder) {
        this.registerForm = _formBuilder.group({
           // username: ['', Validators.compose([Validators.required, Validators.pattern("[a-zA-Z][a-zA-Z0-9.-]{4,19}")])],
            username: ['', Validators.required, this.usernameTaken],
            email: ['', Validators.compose([Validators.required, Validators.pattern("^[a-zA-Z].+@[^\.].*\.[a-z0-9]{2,}$")])],
            password: ['', Validators.compose([Validators.required, Validators.pattern("^(?=.*[A-Z])(?=.*[!@#$&*^])(?=.*[0-9])(?=.*[a-z]).{6,20}$")])],
            toc: ['', this.requiredCheckbox]
        })
        this.username = this.registerForm.controls['username']
        this.email = this.registerForm.controls['email']
        this.password = this.registerForm.controls['password']
    }
    ngAfterContentInit() {
        setTimeout(() => {
            //$('#datetimepicker1').datetimepicker();
        }, 1000);
    }
    ngOnInit() {
    }
    public dt: Date = new Date();
    private minDate: Date = null;

    submitted = false;
    registerForm: ControlGroup;
    username: AbstractControl;
    email: AbstractControl;
    password: AbstractControl;
    onSubmit() {
        this._service.register(this.user).subscribe(res => {
            this.submitted = true;
        },
            err=> {
                this.errorMessage = <any>err;
            }
        );
    }
    log(event: any) {
        console.log(event)
    }
   
    public usernameTaken(control: AbstractControl): Promise<any> {
        return UserService.checkUsernameExist(control.value).toPromise().then( 
                (res)=> {
                    if (res.exist) {
                        return { 'userExist': true };
                    } else {
                        return null;
                    }
                },
                (err)=> { alert(err) }
            );
    }

    public uniqueDataValidator(property: string): Function {
        return (control: AbstractControl): { [s: string]: boolean } => {

            var obj = {};
            obj[property] = true
            return <{ [s: string]: boolean }>obj;
        }
    }

    public requiredCheckbox(control: AbstractControl): { [s: string]: boolean } {
        if (!control.value) {
            return {
                required: true
            }
        }
    }
    public usernameValidator(control: AbstractControl): { [s: string]: boolean } {
        if (control.value.match(/^123/)) {
            return { invalidUsername: true };
        }
    }

    user: User = new User("", "", "", "", "", "", new Date());

    errorMessage: string;

}

