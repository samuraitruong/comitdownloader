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
var TopStoryComponent = (function () {
    function TopStoryComponent(_storyService, _nav) {
        this._storyService = _storyService;
        this._nav = _nav;
        this.classes = new Array();
    }
    TopStoryComponent.prototype.viewStory = function (story) {
        this._nav.viewStory(story);
        //let link = ['StoryDetail', { name: story.Name }];
        //this._router.navigate(link);
    };
    TopStoryComponent.prototype.loadTopStory = function () {
        var _this = this;
        this._storyService.getTopStory().
            subscribe(function (story) {
            _this.topStory = story;
            _this.lastChapter = story.Chapters[story.Chapters.length - 1];
        }, function (error) { return _this.errorMessage = error; });
    };
    TopStoryComponent.prototype.loadTop10Stories = function () {
        var _this = this;
        this._storyService.getTop10Stories().
            subscribe(function (top10stories) {
            _this.top10Stories = top10stories;
            top10stories.forEach(function (s, index, list) {
                var item = {};
                item["stt" + (index + 1)] = true;
                _this.classes.push(item);
            });
            console.log(_this.classes);
        }, function (error) { return _this.errorMessage = error; });
    };
    TopStoryComponent.prototype.ngOnInit = function () {
        this.loadTopStory();
        this.loadTop10Stories();
    };
    TopStoryComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-top-story',
            templateUrl: 'views/shared/top-story.html',
            providers: [top_story_service_1.TopStoryService]
        }), 
        __metadata('design:paramtypes', [top_story_service_1.TopStoryService, navigation_helper_1.NavigationHelper])
    ], TopStoryComponent);
    return TopStoryComponent;
})();
exports.TopStoryComponent = TopStoryComponent;
//# sourceMappingURL=top-story.component.js.map