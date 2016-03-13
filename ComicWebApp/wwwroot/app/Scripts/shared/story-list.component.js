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
var navigation_helper_1 = require('./navigation.helper');
var StoryListComponent = (function () {
    function StoryListComponent(_nav) {
        this._nav = _nav;
    }
    StoryListComponent.prototype.viewStory = function (story) {
        this._nav.viewStory(story);
    };
    StoryListComponent.prototype.viewLatestChap = function (story) {
        if (story.Chapters.length > 0) {
            this._nav.readChapter(story, story.Chapters[story.Chapters.length - 1]);
        }
    };
    StoryListComponent.prototype.ngAfterViewChecked = function () {
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
    ], StoryListComponent.prototype, "stories", void 0);
    StoryListComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-story-list',
            templateUrl: 'views/shared/story-list.html'
        }), 
        __metadata('design:paramtypes', [navigation_helper_1.NavigationHelper])
    ], StoryListComponent);
    return StoryListComponent;
})();
exports.StoryListComponent = StoryListComponent;
//# sourceMappingURL=story-list.component.js.map