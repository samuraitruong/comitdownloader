"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var Observable_1 = require('rxjs/Observable');
var TopStoryService = (function () {
    function TopStoryService(http) {
        this.http = http;
        this._topStoryAPI = '/api/story/top';
        this._top10StoryAPI = '/api/story/top10';
    }
    TopStoryService.prototype.getTopStory = function () {
        return this.http.get(this._topStoryAPI)
            .map(function (res) { return res.json(); })
            .catch(this.handleError)
            .do(function (data) { return console.log(data); });
    };
    TopStoryService.prototype.getTop10Stories = function () {
        return this.http.get(this._top10StoryAPI)
            .map(function (res) { return res.json(); })
            .catch(this.handleError)
            .do(function (data) { return console.log(data); });
    };
    TopStoryService.prototype.handleError = function (error) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    TopStoryService = __decorate([
        core_1.Injectable()
    ], TopStoryService);
    return TopStoryService;
}());
exports.TopStoryService = TopStoryService;
