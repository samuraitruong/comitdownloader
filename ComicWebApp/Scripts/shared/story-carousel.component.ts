import {Component} from 'angular2/core';
import {
OnChanges, SimpleChange,
OnInit,
AfterContentInit,
AfterContentChecked,
AfterViewInit,
AfterViewChecked,
OnDestroy
} from 'angular2/core';

@Component({
    selector: 'cmapp-story-carousel',
    templateUrl: 'views/shared/story-carousel.html'
})
export class StoryCarouselComponent implements AfterViewChecked {
    ngAfterViewChecked() {
    }
    initCarousel() {
    }
}

