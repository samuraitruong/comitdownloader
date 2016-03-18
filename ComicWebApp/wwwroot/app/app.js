//AUTH: https://auth0.com/blog/2015/05/14/creating-your-first-real-world-angular-2-app-from-authentication-to-calling-an-api-and-everything-in-between/
//https://github.com/auth0/angular2-jwt
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
//import {LocalStorage} from "angular2-localstorage/LocalStorage";
var http_1 = require('angular2/http');
var home_component_1 = require('./home/home.component');
var story_detail_component_1 = require('./story/story-detail.component');
var chap_reader_component_1 = require('./reader/chap-reader.component');
var search_component_1 = require('./search/search.component');
var genre_component_1 = require('./directory/genre.component');
var directory_component_1 = require('./directory/directory.component');
var navigation_helper_1 = require('./shared/navigation.helper');
var topnav_component_1 = require('./shared/topnav.component');
var register_component_1 = require('./user/register.component');
var user_1 = require('./models/user');
var user_service_1 = require('./user/user.service');
var window_service_1 = require('./shared/window.service');
var AppComponent = (function () {
    function AppComponent(_nav, _userService, win) {
        this._nav = _nav;
        this._userService = _userService;
        this.win = win;
        this.AUTH_COOKIE_NAME = 'auth_token';
        this.user = new user_1.User("", "", "", "", "", "");
        this.siteName = 'my site name';
        this.logged = false;
        this.authToken = localStorage.getItem(this.AUTH_COOKIE_NAME); // Cookie.getCookie(this.AUTH_COOKIE_NAME);
        this.refreshToken();
    }
    AppComponent.prototype.doSearch = function () {
        this._nav.doSearch(this.keyword);
    };
    AppComponent.prototype.postLogin = function (res) {
        this.logged = true;
        this.user = res.User;
        this.authToken = res.AuthToken;
        //Cookie.setCookie(this.AUTH_COOKIE_NAME, this.authToken, 0);
        localStorage.setItem(this.AUTH_COOKIE_NAME, this.authToken);
        this.errorMessage = null;
    };
    AppComponent.prototype.refreshToken = function () {
        var _this = this;
        if (this.authToken) {
            this._userService.refreshToken(this.authToken).subscribe(function (res) {
                _this.postLogin(res);
            }, function (err) {
                _this.authToken = null;
                //Cookie.deleteCookie(this.AUTH_COOKIE_NAME)
                localStorage.removeItem(_this.AUTH_COOKIE_NAME);
                _this.errorMessage = err;
            });
        }
    };
    AppComponent.prototype.onLogin = function () {
        var _this = this;
        this._userService.login(this.user.Username, this.user.Password, this.rememberMe).subscribe(function (res) {
            _this.postLogin(res);
            $("#login_section_wrapper").modal('hide');
        }, function (err) {
            _this.errorMessage = err;
        });
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'comic-app',
            templateUrl: 'views/app.html',
            directives: [router_1.ROUTER_DIRECTIVES, topnav_component_1.TopNavComponent, register_component_1.RegisterComponent],
            providers: [router_1.ROUTER_PROVIDERS,
                http_1.HTTP_PROVIDERS,
                navigation_helper_1.NavigationHelper,
                user_service_1.UserService,
                window_service_1.WINDOW_PROVIDERS
            ]
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
            },
            {
                path: '/directory',
                name: 'Directory',
                component: directory_component_1.DirectoryComponent,
            },
            {
                path: '/search/:keyword',
                name: 'Search',
                component: search_component_1.SearchComponent,
            },
            {
                path: '/search/:keyword/:page',
                name: 'SearchPaging',
                component: search_component_1.SearchComponent,
            },
            ,
            {
                path: '/register',
                name: 'Register',
                component: register_component_1.RegisterComponent,
            }
        ]), 
        __metadata('design:paramtypes', [navigation_helper_1.NavigationHelper, user_service_1.UserService, window_service_1.WINDOW])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
