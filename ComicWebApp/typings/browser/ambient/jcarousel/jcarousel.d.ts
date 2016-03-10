
/// <reference path="../jquery/jquery.d.ts" />

declare module JQueryCarousel {
    export interface JQueryCarouselOptions {
        interval?: number
    }
}
interface JQuery {
    /**
    * Creates a new tinycarousel with the specified, or default, options.
    *
    * @param options The options
    */
    carousel(options?: JQueryCarousel.JQueryCarouselOptions): JQuery;
}