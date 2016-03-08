import {Component} from 'angular2/core';
import {TopStoryComponent} from '../shared/top-story.component'
import {StoryCarouselComponent} from '../shared/story-carousel.component'
import {StoryListComponent} from '../shared/story-list.component'

@Component({
    selector: 'cmapp-home',
    templateUrl: 'views/home/home.html',
    directives: [TopStoryComponent, StoryCarouselComponent, StoryListComponent]
})
export class HomeComponent { }

