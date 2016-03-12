"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var Observable_1 = require('rxjs/Observable');
var StoryService = (function () {
    function StoryService(_http) {
        this._http = _http;
        this._storyDetailAPI = '/api/story/detail/';
    }
    StoryService.prototype.getStoryByName = function (name) {
        return this._http.get(this._storyDetailAPI + encodeURIComponent(name))
            .map(function (r) { return r.json(); })
            .catch(this.handleError)
            .do(function (d) { return function () { console.log('ajax resulr........................'); console.log(d); }; });
    };
    StoryService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    StoryService = __decorate([
        core_1.Injectable()
    ], StoryService);
    return StoryService;
}());
exports.StoryService = StoryService;
