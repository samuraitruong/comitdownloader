﻿import { Directive, ElementRef, Input, Output} from 'angular2/core';

@Directive({
    selector: '[myBxSlider]',
    //host: { '(window:resize)': 'onResize()' } // Window resize listener
})

export class BXSliderDirective {

    element: ElementRef; // Element that associated to attribute.
    $window: any;

    constructor(_element: ElementRef) {
        this.element = _element;
        console.log('init bxslider.................')
        console.log(this.element)
        //this.onResize();
    }

    //// Adjust height of element.
    //onResize() {
    //    console.log('wind dow resize.')
    //    //$(this.element.nativeElement).css('height', (this.$window.height() - 163) + 'px');
    //}
}