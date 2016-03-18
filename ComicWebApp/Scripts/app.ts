//AUTH: https://auth0.com/blog/2015/05/14/creating-your-first-real-world-angular-2-app-from-authentication-to-calling-an-api-and-everything-in-between/
//https://github.com/auth0/angular2-jwt

import {Component, provide} from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from 'angular2/router';
//import {LocalStorage} from "angular2-localstorage/LocalStorage";
import {HTTP_PROVIDERS}    from 'angular2/http';
import {HomeComponent} from './home/home.component'
import {StoryDetailComponent}  from './story/story-detail.component'
import {ChapReaderComponent} from './reader/chap-reader.component'
import {SearchComponent} from './search/search.component'
import {GenreComponent} from './directory/genre.component'
import {DirectoryComponent} from './directory/directory.component'
import {NavigationHelper} from './shared/navigation.helper'
import {TopNavComponent} from './shared/topnav.component'
import {RegisterComponent} from './user/register.component'
import {User, LoginRes} from './models/user'
import {UserService} from './user/user.service'
import {RequestOptions, Headers} from 'angular2/http';
import {Cookie} from './shared/cookie'
import {WINDOW_PROVIDERS, WINDOW} from './shared/window.service';
import {AuthHttp, AuthConfig, JwtHelper, tokenNotExpired} from 'angular2-jwt';

//import { PAGINATION_DIRECTIVES } from 'ng2-bootstrap/ng2-bootstrap';
import {enableProdMode} from 'angular2/core';
@Component({
    selector: 'comic-app',
    templateUrl: 'views/app.html',
    directives: [ROUTER_DIRECTIVES, TopNavComponent, RegisterComponent],
    providers: [ROUTER_PROVIDERS,
        HTTP_PROVIDERS,
        NavigationHelper,
        UserService,
        WINDOW_PROVIDERS
    ]
})

@RouteConfig([
    {
        path: '/home',
        name: 'Home',
        component: HomeComponent,
        useAsDefault: true
    },
    {
        path: '/story/:name',
        name: 'StoryDetail',
        component: StoryDetailComponent,
    },
    {
        path: '/reader/:storyname/:chapname',
        name: 'ChapReader',
        component: ChapReaderComponent,
    },
    {
        path: '/genre/:genre',
        name: 'Genre',
        component: GenreComponent,
    },
     {
        path: '/directory',
        name: 'Directory',
        component: DirectoryComponent,
    }, 
    {
         path: '/search/:keyword',
         name: 'Search',
         component: SearchComponent,
     },
    {
        path: '/search/:keyword/:page',
        name: 'SearchPaging',
        component: SearchComponent,
    },
        ,
    {
        path: '/register',
        name: 'Register',
        component: RegisterComponent,
    }

])

export class AppComponent {
    constructor(private _nav: NavigationHelper, private _userService: UserService, private win: WINDOW) {
        this.authToken = localStorage.getItem(this.AUTH_COOKIE_NAME)// Cookie.getCookie(this.AUTH_COOKIE_NAME);
        this.refreshToken();
    }

    private AUTH_COOKIE_NAME: string = 'auth_token';
    //@LocalStorage()
    public authToken: string

    public user: User = new User("", "", "", "", "", "");
    public keyword: string;
    public siteName: string = 'my site name';
    public rememberMe: boolean;
    public errorMessage: string;
    public logged: boolean = false;
    public doSearch() {
        this._nav.doSearch(this.keyword);
    }
    public postLogin(res: LoginRes) {
        this.logged = true;
        this.user = res.User;
        this.authToken = res.AuthToken;
        //Cookie.setCookie(this.AUTH_COOKIE_NAME, this.authToken, 0);
        localStorage.setItem(this.AUTH_COOKIE_NAME, this.authToken);
        this.errorMessage = null;
    }
    public refreshToken() {
        if (this.authToken) {
            this._userService.refreshToken(this.authToken).subscribe(res=> {
                this.postLogin(res);
            },
                err=> {
                    this.authToken = null;
                    //Cookie.deleteCookie(this.AUTH_COOKIE_NAME)
                    localStorage.removeItem(this.AUTH_COOKIE_NAME)
                    this.errorMessage = <any>err;
                });
        }
    }
    public onLogin() {
        this._userService.login(this.user.Username, this.user.Password, this.rememberMe).subscribe(res=> {
            this.postLogin(res);
            $("#login_section_wrapper").modal('hide');
        },
        err=> {
            this.errorMessage = <any>err;
        });
    }
}


