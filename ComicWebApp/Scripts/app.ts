import {Component} from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from 'angular2/router';
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


//import { PAGINATION_DIRECTIVES } from 'ng2-bootstrap/ng2-bootstrap';
import {enableProdMode} from 'angular2/core';
 //test bla bla 
@Component({
    selector: 'comic-app',
    templateUrl: 'views/app.html',
    directives: [ROUTER_DIRECTIVES, TopNavComponent, RegisterComponent],
    providers: [ROUTER_PROVIDERS, HTTP_PROVIDERS, NavigationHelper]
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
    constructor(private _nav: NavigationHelper) {
    }

    keyword: string;
    siteName: string = 'my site name';
    doSearch() {
        this._nav.doSearch(this.keyword);
    }
}


