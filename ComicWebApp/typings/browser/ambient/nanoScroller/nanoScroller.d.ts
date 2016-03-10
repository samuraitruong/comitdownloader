
/// <reference path="../jquery/jquery.d.ts" />

declare module JQueryNanoScroller {
    export interface JQueryNanoScrollerOptions {
        alwaysVisible: boolean;
        scroll: string;
        [x: string]: any
    }
}
interface JQuery {
    /**
    * Creates a new tinycarousel with the specified, or default, options.
    *
    * @param options The options
    */
    nanoScroller(options?: JQueryNanoScroller.JQueryNanoScrollerOptions): JQuery;
}