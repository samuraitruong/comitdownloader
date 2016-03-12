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
var top_story_component_1 = require('../shared/top-story.component');
var story_carousel_component_1 = require('../shared/story-carousel.component');
var story_list_component_1 = require('../shared/story-list.component');
var home_service_1 = require('./home.service');
var story_genres_component_1 = require('../shared/story-genres.component');
var router_1 = require('angular2/router');
var HomeComponent = (function () {
    function HomeComponent(_homeService) {
        this._homeService = _homeService;
    }
    HomeComponent.prototype.ngOnInit = function () {
        this.loadCarouselItems();
        this.loadLastestUpdateStories();
        this.loadLastestPostStories();
    };
    HomeComponent.prototype.loadCarouselItems = function () {
        var _this = this;
        this._homeService.getPopularTodayStores()
            .subscribe(function (res) {
            _this.carouselItems = res;
        }, function (error) { });
    };
    HomeComponent.prototype.loadLastestUpdateStories = function () {
        var _this = this;
        this._homeService.loadLastestUpdateStories()
            .subscribe(function (res) {
            _this.lastestUpdateStories = res;
        }, function (error) { });
    };
    HomeComponent.prototype.loadLastestPostStories = function () {
        var _this = this;
        this._homeService.loadLastestPostStories()
            .subscribe(function (res) {
            _this.latestPostedStories = res;
        }, function (error) { });
    };
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-home',
            templateUrl: 'views/home/home.html',
            directives: [top_story_component_1.TopStoryComponent, story_carousel_component_1.StoryCarouselComponent, story_list_component_1.StoryListComponent, story_genres_component_1.StoryGenresComponent, router_1.ROUTER_DIRECTIVES],
            providers: [home_service_1.HomeService]
        }), 
        __metadata('design:paramtypes', [home_service_1.HomeService])
    ], HomeComponent);
    return HomeComponent;
})();
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map