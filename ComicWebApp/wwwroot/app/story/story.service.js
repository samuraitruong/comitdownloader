"use strict";
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
var angular2_jwt_1 = require('angular2-jwt');
var StoryService = (function () {
    function StoryService(_http, _authHttp) {
        this._http = _http;
        this._authHttp = _authHttp;
        this._storyDetailAPI = '/api/story/detail/';
        this._storyRateAPI = '/api/story/rate';
        console.log(this._authHttp);
    }
    //better to use DI as single value?? or factory here
    StoryService.prototype.requestOptions = function () {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        //TODO - Add more header....
        var options = new http_1.RequestOptions({ headers: headers });
        return options;
    };
    StoryService.prototype.getStoryByName = function (name) {
        return this._http.get(this._storyDetailAPI + encodeURIComponent(name))
            .map(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    StoryService.prototype.rateStory = function (story, rateValue) {
        var data = {
            Name: story.Name,
            Rate: rateValue
        };
        return this._authHttp.post(this._storyRateAPI, JSON.stringify(data), this.requestOptions())
            .map(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    StoryService.prototype.handleError = function (error) {
        console.error(error.json());
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    StoryService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http, angular2_jwt_1.AuthHttp])
    ], StoryService);
    return StoryService;
}());
exports.StoryService = StoryService;
