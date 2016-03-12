"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var Observable_1 = require('rxjs/Observable');
var HomeService = (function () {
    function HomeService(_http) {
        this._http = _http;
        this._lastestStoriesApi = '/api/story/latest';
        this._todayPopularApi = '/api/story/toptoday';
        this._updatedPopularApi = '/api/story/updated';
    }
    HomeService.prototype.getPopularTodayStores = function () {
        return this._http.get(this._todayPopularApi)
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    HomeService.prototype.loadLastestUpdateStories = function () {
        return this._http.get(this._updatedPopularApi)
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    HomeService.prototype.loadLastestPostStories = function () {
        return this._http.get(this._lastestStoriesApi)
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    HomeService.prototype.handleError = function (error) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    HomeService = __decorate([
        core_1.Injectable()
    ], HomeService);
    return HomeService;
}());
exports.HomeService = HomeService;
