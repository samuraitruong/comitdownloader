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
var router_1 = require('angular2/router');
var navigation_helper_1 = require('../shared/navigation.helper');
var chap_reader_service_1 = require('./chap-reader.service');
var ChapReaderComponent = (function () {
    function ChapReaderComponent(_nav, _service, _routeParams) {
        this._nav = _nav;
        this._service = _service;
        this._routeParams = _routeParams;
    }
    ChapReaderComponent.prototype.ngAfterContentInit = function () {
    };
    ChapReaderComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.name = this._routeParams.get("storyname");
        console.log('storyname : ' + this.name);
        this.chapname = this._routeParams.get('chapname');
        console.log('chapname : ' + this.chapname);
        this._service.getChapInfo(this.name, this.chapname).subscribe(function (res) {
            _this.chapter = res;
            _this.story = _this.chapter.Story;
            console.log('data callback complete.....');
        }, function (err) {
            _this.errorMessage = err;
        });
    };
    ChapReaderComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-chap-reader',
            templateUrl: 'views/reader/chap-reader.html',
            directives: [],
            providers: [chap_reader_service_1.ChapReaderService]
        }), 
        __metadata('design:paramtypes', [navigation_helper_1.NavigationHelper, chap_reader_service_1.ChapReaderService, router_1.RouteParams])
    ], ChapReaderComponent);
    return ChapReaderComponent;
})();
exports.ChapReaderComponent = ChapReaderComponent;
//# sourceMappingURL=chap-reader.component.js.map