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
var http_1 = require('angular2/http');
var home_component_1 = require('./home/home.component');
var story_detail_component_1 = require('./story/story-detail.component');
var chap_reader_component_1 = require('./reader/chap-reader.component');
var genre_component_1 = require('./directory/genre.component');
var navigation_helper_1 = require('./shared/navigation.helper');
//import { PAGINATION_DIRECTIVES } from 'ng2-bootstrap/ng2-bootstrap';
var AppComponent = (function () {
    function AppComponent() {
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'comic-app',
            templateUrl: 'views/app.html',
            directives: [router_1.ROUTER_DIRECTIVES],
            providers: [router_1.ROUTER_PROVIDERS, http_1.HTTP_PROVIDERS, navigation_helper_1.NavigationHelper]
        }),
        router_1.RouteConfig([
            {
                path: '/home',
                name: 'Home',
                component: home_component_1.HomeComponent,
                useAsDefault: true
            },
            {
                path: '/story/:name',
                name: 'StoryDetail',
                component: story_detail_component_1.StoryDetailComponent,
            },
            {
                path: '/reader/:storyname/:chapname',
                name: 'ChapReader',
                component: chap_reader_component_1.ChapReaderComponent,
            },
            {
                path: '/genre/:genre',
                name: 'Genre',
                component: genre_component_1.GenreComponent,
            }
        ]), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
})();
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.js.map