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
var navigation_helper_1 = require('../shared/navigation.helper');
var directory_service_1 = require('./directory.service');
var story_list_component_1 = require('../shared/story-list.component');
var story_genres_component_1 = require('../shared/story-genres.component');
var GenreComponent = (function () {
    function GenreComponent(_nav, _service, _routeParams) {
        this._nav = _nav;
        this._service = _service;
        this._routeParams = _routeParams;
        this.page = 1;
        this.totalItems = 64;
        this.currentPage = 4;
        this.maxSize = 5;
        this.bigTotalItems = 175;
        this.bigCurrentPage = 1;
    }
    GenreComponent.prototype.ngAfterContentInit = function () {
    };
    GenreComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.genre = this._routeParams.get("genre");
        this._service.getGenreStories(this.genre, this.page).subscribe(function (res) {
            _this.stories = res.Stories;
            _this.pageCount = res.PageCount;
        }, function (err) {
            _this.errorMessage = err;
        });
    };
    GenreComponent.prototype.viewStory = function (s) {
        this._nav.viewStory(s);
    };
    GenreComponent.prototype.setPage = function (pageNo) {
        this.currentPage = pageNo;
    };
    ;
    GenreComponent.prototype.pageChanged = function (event) {
        console.log('Page changed to: ' + event.page);
        console.log('Number items per page: ' + event.itemsPerPage);
    };
    ;
    GenreComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-genre',
            templateUrl: 'views/directory/genre.html',
            directives: [story_list_component_1.StoryListComponent, story_genres_component_1.StoryGenresComponent],
            providers: [directory_service_1.DirectoryService]
        }), 
        __metadata('design:paramtypes', [navigation_helper_1.NavigationHelper, directory_service_1.DirectoryService, router_1.RouteParams])
    ], GenreComponent);
    return GenreComponent;
}());
exports.GenreComponent = GenreComponent;
