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
var story_genres_service_1 = require('./story-genres.service');
var router_1 = require('angular2/router');
var navigation_helper_1 = require('./navigation.helper');
var TopNavComponent = (function () {
    function TopNavComponent(_service, _nav) {
        this._service = _service;
        this._nav = _nav;
    }
    TopNavComponent.prototype.ngOnInit = function () {
        //this.selectedGenre = this._params.get('genre')
        this.loadGenres();
    };
    TopNavComponent.prototype.viewGenre = function (g) {
        this._nav.viewGenre(g.Name);
    };
    TopNavComponent.prototype.loadGenres = function () {
        var _this = this;
        this._service.getGenres().subscribe(function (res) {
            res.sort(function (a, b) { return b.StoriesCount - a.StoriesCount; });
            _this.topGenres = res.slice(0, 5);
        }, function (err) { return _this.errorMessage = err; });
    };
    TopNavComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-top-nav',
            templateUrl: 'views/shared/topnav.html',
            providers: [story_genres_service_1.StoryGenresService],
            directives: [router_1.ROUTER_DIRECTIVES]
        }), 
        __metadata('design:paramtypes', [story_genres_service_1.StoryGenresService, navigation_helper_1.NavigationHelper])
    ], TopNavComponent);
    return TopNavComponent;
})();
exports.TopNavComponent = TopNavComponent;
//# sourceMappingURL=topnav.component.js.map