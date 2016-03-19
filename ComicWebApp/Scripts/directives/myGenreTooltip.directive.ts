import { Directive, ElementRef, Input, Output, EventEmitter, AfterContentInit} from 'angular2/core';

@Directive({
    selector: '[myGenreTooltip]',
    //host: { '(window:resize)': 'onResize()' } // Window resize listener
    host: {
        '(mouseenter)': 'onMouseEnter()',
        '(mouseleave)': 'onMouseLeave()',
    },
    
})

export class GenreTooltipDirective implements AfterContentInit {

    element: ElementRef; // Element that associated to attribute.
    $window: any;
    @Input('myGenreTooltip') genreName: string;
    @Output() onTooltipShown: EventEmitter<string> = new EventEmitter ();

    private tooltipPlaceHolder: string;
    ngAfterContentInit() {
        $(this.element.nativeElement).tooltipster({
            content: $(this.tooltipPlaceHolder),
            contentCloning: false,
            autoClose: false,
            interactive: true,
        });
        //$(this.element.nativeElement).tooltipster('show', () => {
        //    this.onTooltipShown.emit(this.genreName)
        //})
    }

    @Input() set tooltipContainer(id: string) {
        this.tooltipPlaceHolder = id;
    }

    constructor(_element: ElementRef) {
        this.element = _element;
    }
    onMouseLeave() {
        //$(this.element.nativeElement).tooltipster('hide')
    }
    onMouseEnter() {
        $(this.element.nativeElement).tooltipster('show', () => {
            this.onTooltipShown.emit(this.genreName)
        })
    }
}