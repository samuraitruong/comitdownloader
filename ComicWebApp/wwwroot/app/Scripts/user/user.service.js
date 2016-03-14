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
var http_1 = require('angular2/http');
var Observable_1 = require('rxjs/Observable');
var UserService = (function () {
    function UserService(http) {
        this.http = http;
        this._apiUrl = '/api/user/';
        this._apiLoginUrl = '/api/user/login';
        this._apiCheckUser = '/api/user/check';
    }
    UserService.prototype.requestOptions = function () {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        return options;
    };
    UserService.prototype.register = function (user) {
        var body = JSON.stringify(user);
        return this.http.post(this._apiUrl, body, this.requestOptions())
            .map(function (res) { return res.json(); })
            .catch(this.handleError)
            .do(function (data) { return console.log(data); });
    };
    UserService.prototype.checkUsernameExist = function (username) {
        return this.http.post(this._apiCheckUser, JSON.stringify({ Username: username }), this.requestOptions())
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    UserService.prototype.login = function (username, password, remember) {
        var body = JSON.stringify({
            Username: username,
            Password: password,
            Remember: remember
        });
        return this.http.post(this._apiLoginUrl, body, this.requestOptions())
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    UserService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error.json().message || 'Unknow error');
    };
    UserService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], UserService);
    return UserService;
})();
exports.UserService = UserService;
//# sourceMappingURL=user.service.js.map