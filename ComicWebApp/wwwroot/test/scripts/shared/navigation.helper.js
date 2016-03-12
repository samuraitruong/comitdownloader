"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var NavigationHelper = (function () {
    function NavigationHelper(_router) {
        this._router = _router;
    }
    NavigationHelper.prototype.viewStory = function (story) {
        var link = ['StoryDetail', { name: story.Name }];
        this._router.navigate(link);
    };
    NavigationHelper.prototype.readChapter = function (story, chapter) {
        var link = ['ChapReader', { storyname: encodeURIComponent(story.Name), chapname: encodeURIComponent(chapter.Name) }];
        this._router.navigate(link);
    };
    NavigationHelper.prototype.viewGenre = function (genre) {
        var link = ['Genre', { genre: genre }];
        this._router.navigate(link);
    };
    NavigationHelper.prototype.getString = function (name) {
        return "";
        //return this._routerParams.get(name); r
    };
    NavigationHelper = __decorate([
        core_1.Injectable()
    ], NavigationHelper);
    return NavigationHelper;
}());
exports.NavigationHelper = NavigationHelper;
