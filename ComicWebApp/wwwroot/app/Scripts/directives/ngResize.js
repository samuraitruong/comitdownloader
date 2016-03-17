var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('angular2/core');
var AutoResize = (function () {
    function AutoResize(_element) {
        this.element = _element;
        // Get instance of DOM window.
        //this.$window = angular.element(window);
        this.onResize();
    }
    // Adjust height of element.
    AutoResize.prototype.onResize = function () {
        console.log('wind dow resize.');
        //$(this.element.nativeElement).css('height', (this.$window.height() - 163) + 'px');
    };
    AutoResize = __decorate([
        core_1.Directive({
            selector: '[ngResize]',
            host: { '(window:resize)': 'onResize()' } // Window resize listener
        }), 
        __metadata('design:paramtypes', [core_1.ElementRef])
    ], AutoResize);
    return AutoResize;
})();
exports.AutoResize = AutoResize;
//# sourceMappingURL=ngResize.js.map