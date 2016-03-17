//read more - http://blog.thoughtram.io/angular/2015/05/18/dependency-injection-in-angular-2.html
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var core_1 = require('angular2/core');
var browser_1 = require('angular2/src/facade/browser');
var exceptions_1 = require('angular2/src/facade/exceptions');
function _window() {
    return browser_1.window;
}
var WINDOW = (function () {
    function WINDOW() {
    }
    Object.defineProperty(WINDOW.prototype, "nativeWindow", {
        get: function () {
            return exceptions_1.unimplemented();
        },
        enumerable: true,
        configurable: true
    });
    return WINDOW;
})();
exports.WINDOW = WINDOW;
var WindowRef = (function (_super) {
    __extends(WindowRef, _super);
    function WindowRef() {
        _super.call(this);
    }
    Object.defineProperty(WindowRef.prototype, "nativeWindow", {
        get: function () {
            return _window();
        },
        enumerable: true,
        configurable: true
    });
    return WindowRef;
})(WINDOW);
exports.WINDOW_PROVIDERS = [
    new core_1.Provider(WINDOW, { useClass: WindowRef }),
];
//# sourceMappingURL=window.service.js.map