import { Directive, ElementRef, Input, Output, AfterContentInit} from 'angular2/core';

@Directive({
    selector: '[myBxSlider]',
    //host: { '(window:resize)': 'onResize()' } // Window resize listener
})

export class BXSliderDirective implements AfterContentInit {

    element: ElementRef; // Element that associated to attribute.
    $window: any;

    constructor(_element: ElementRef) {
        this.element = _element;
        //this.onResize();
    }
    public ngAfterContentInit() {

        //$(this.element).bxSlider(
        //    {
        //        slideWidth: 134,
        //        minSlides: 2,
        //        maxSlides: 7,
        //        slideMargin: 15,
        //        preloadImages: 'visible',
        //        auto: true,
        //        autoStart: true
        //    }
        //);

    }

    //// Adjust height of element.
    //onResize() {
    //    console.log('wind dow resize.')
    //    //$(this.element.nativeElement).css('height', (this.$window.height() - 163) + 'px');
    //}
}