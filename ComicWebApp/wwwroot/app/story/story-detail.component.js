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
var router_1 = require('angular2/router');
var story_service_1 = require('./story.service');
var story_genres_component_1 = require('../shared/story-genres.component');
var navigation_helper_1 = require('../shared/navigation.helper');
var ng2_bootstrap_1 = require('ng2-bootstrap/ng2-bootstrap');
var StoryDetailComponent = (function () {
    function StoryDetailComponent(_routeParams, _storyService, _nav) {
        this._routeParams = _routeParams;
        this._storyService = _storyService;
        this._nav = _nav;
        this.max = 5;
        this.rate = 4;
        this.currentRating = 0;
    }
    StoryDetailComponent.prototype.ngAfterContentInit = function () {
        setTimeout(function () {
            $(".nano").nanoScroller({
                alwaysVisible: true,
                scroll: "top"
            });
        }, 1000);
    };
    StoryDetailComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.name = this._routeParams.get('name');
        this._storyService.getStoryByName(this.name)
            .subscribe(function (d) { _this.story = d; }, function (err) { _this.errorMessage = err; });
    };
    StoryDetailComponent.prototype.readChapter = function (chapter) {
        this._nav.readChapter(this.story, chapter);
    };
    StoryDetailComponent.prototype.hoveringOver = function (value) {
        //console.log(value)
    };
    ;
    StoryDetailComponent.prototype.rateStory = function (value) {
        //console.log(value);
        if (value != this.currentRating) {
            console.log('call rating service....');
            this._storyService.rateStory(this.story, value)
                .subscribe(function (res) { }, function (err) { });
        }
    };
    StoryDetailComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-story-detail',
            templateUrl: 'views/story/story-detail.html',
            directives: [story_genres_component_1.StoryGenresComponent, ng2_bootstrap_1.Rating, router_1.RouterLink],
            providers: [story_service_1.StoryService]
        }), 
        __metadata('design:paramtypes', [router_1.RouteParams, story_service_1.StoryService, navigation_helper_1.NavigationHelper])
    ], StoryDetailComponent);
    return StoryDetailComponent;
}());
exports.StoryDetailComponent = StoryDetailComponent;
