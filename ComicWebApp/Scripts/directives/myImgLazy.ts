import { Directive, ElementRef, Input, Output} from 'angular2/core';



@Directive({
    selector: '[ngResize]',
    host: { '(window:resize)': 'onResize()' } // Window resize listener
})

export class AutoResize {

    element: ElementRef; // Element that associated to attribute.
    $window: any;

    constructor(_element: ElementRef) {
        this.element = _element;
        // Get instance of DOM window.
        //this.$window = angular.element(window);

        this.onResize();
    }

    // Adjust height of element.
    onResize() {
        console.log('wind dow resize.')
        //$(this.element.nativeElement).css('height', (this.$window.height() - 163) + 'px');
    }
}