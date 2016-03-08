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
    selector: 'cmapp-story-list',
    templateUrl: 'views/shared/story-list.html'
})
export class StoryListComponent implements AfterViewChecked {
    ngAfterViewChecked() {
    }
}

