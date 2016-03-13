//http://blog.ng-book.com/the-ultimate-guide-to-forms-in-angular-2/
//https://medium.com/@daviddentoom/angular-2-form-validation-9b26f73fcb81#.20uoltht5
//https://github.com/angular2-school/angular2-radio-button/tree/master/modules/ng-school/controls/radio - fix radio binding.
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('angular2/core');
var common_1 = require('angular2/common');
var router_1 = require('angular2/router');
var user_1 = require('../models/user');
var navigation_helper_1 = require('../shared/navigation.helper');
var user_service_1 = require('./user.service');
var RegisterComponent = (function () {
    function RegisterComponent(_nav, _service, _routeParams, _formBuilder) {
        this._nav = _nav;
        this._service = _service;
        this._routeParams = _routeParams;
        this._formBuilder = _formBuilder;
        this.submitted = false;
        this.user = new user_1.User("", "", "", "", "", "", new Date());
        this.registerForm = _formBuilder.group({
            username: ['', common_1.Validators.compose([common_1.Validators.required, common_1.Validators.pattern("[a-zA-Z][a-zA-Z0-9.-]{4,19}")])],
            email: ['', common_1.Validators.compose([common_1.Validators.required, common_1.Validators.pattern("^[a-zA-Z].+@[^\.].*\.[a-z0-9]{2,}$")])],
            password: ['', common_1.Validators.compose([common_1.Validators.required, common_1.Validators.pattern("^(?=.*[A-Z])(?=.*[!@#$&*^])(?=.*[0-9])(?=.*[a-z]).{6,20}$")])],
            toc: ['', common_1.Validators.required]
        });
        this.username = this.registerForm.controls['username'];
        this.email = this.registerForm.controls['email'];
        this.password = this.registerForm.controls['password'];
    }
    RegisterComponent.prototype.ngAfterContentInit = function () {
    };
    RegisterComponent.prototype.ngOnInit = function () {
    };
    RegisterComponent.prototype.onSubmit = function () {
        var _this = this;
        this._service.register(this.user).subscribe(function (res) {
            _this.submitted = true;
        }, function (err) {
            _this.errorMessage = err;
        });
    };
    RegisterComponent.prototype.log = function (event) {
        console.log(event);
    };
    RegisterComponent.prototype.usernameValidator = function (control) {
        if (control.value.match(/^123/)) {
            return { invalidUsername: true };
        }
    };
    RegisterComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-user-register',
            templateUrl: 'views/user/register.html',
            directives: [router_1.ROUTER_DIRECTIVES, common_1.FORM_DIRECTIVES],
            providers: [user_service_1.UserService]
        }), 
        __metadata('design:paramtypes', [navigation_helper_1.NavigationHelper, user_service_1.UserService, router_1.RouteParams, common_1.FormBuilder])
    ], RegisterComponent);
    return RegisterComponent;
})();
exports.RegisterComponent = RegisterComponent;
//# sourceMappingURL=register.component.js.map