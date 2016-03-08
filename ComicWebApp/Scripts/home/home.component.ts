import {Component} from 'angular2/core';
import {HomeTopStoryComponent} from './home-top-story.component'

@Component({
    selector: 'cmapp-home',
    templateUrl: 'views/home/home.html',
    directives: [HomeTopStoryComponent]
})
export class HomeComponent { }

