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
var top_story_service_1 = require('./top-story.service');
var navigation_helper_1 = require('./navigation.helper');
var StoryGenresComponent = (function () {
    function StoryGenresComponent(_storyService, _nav) {
        this._storyService = _storyService;
        this._nav = _nav;
    }
    StoryGenresComponent.prototype.ngOnInit = function () {
    };
    StoryGenresComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-story-genres',
            templateUrl: 'views/shared/story-genres.html',
            providers: [top_story_service_1.TopStoryService]
        }), 
        __metadata('design:paramtypes', [top_story_service_1.TopStoryService, navigation_helper_1.NavigationHelper])
    ], StoryGenresComponent);
    return StoryGenresComponent;
}());
exports.StoryGenresComponent = StoryGenresComponent;
