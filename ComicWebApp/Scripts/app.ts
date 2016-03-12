import {Component} from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS, RouteParams} from 'angular2/router';
import {HTTP_PROVIDERS}    from 'angular2/http';
import {HomeComponent} from './home/home.component'
import {StoryDetailComponent}  from './story/story-detail.component'
import {ChapReaderComponent} from './reader/chap-reader.component'
import {GenreComponent} from './directory/genre.component'
import {NavigationHelper} from './shared/navigation.helper'
//import { PAGINATION_DIRECTIVES } from 'ng2-bootstrap/ng2-bootstrap';
import {enableProdMode} from 'angular2/core';
 //test bla bla 
@Component({
    selector: 'comic-app',
    templateUrl: 'views/app.html',
    directives: [ROUTER_DIRECTIVES],
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
    }
])

export class AppComponent {
}


