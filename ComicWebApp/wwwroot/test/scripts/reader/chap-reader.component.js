"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var chap_reader_service_1 = require('./chap-reader.service');
var ChapReaderComponent = (function () {
    function ChapReaderComponent(_nav, _service, _routeParams) {
        this._nav = _nav;
        this._service = _service;
        this._routeParams = _routeParams;
        this.hasNextChapter = false;
        this.hasPrevChapter = false;
        this.nextChapter = null;
        this.prevChapter = null;
    }
    ChapReaderComponent.prototype.ngAfterContentInit = function () {
    };
    ChapReaderComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.name = this._routeParams.get("storyname");
        this.chapname = this._routeParams.get('chapname');
        this._service.getChapInfo(this.name, this.chapname).subscribe(function (res) {
            _this.chapter = res;
            _this.story = _this.chapter.Story;
            var index = _this.story.Chapters.findIndex(function (c) { return c.Name === _this.chapter.Name; });
            console.log('index found .............' + index);
            if (index < _this.story.Chapters.length) {
                _this.nextChapter = _this.story.Chapters[index + 1];
                _this.hasNextChapter = true;
            }
            if (index > 0) {
                _this.hasPrevChapter = true;
                _this.prevChapter = _this.story.Chapters[index - 1];
            }
            console.log(_this);
        }, function (err) {
            _this.errorMessage = err;
        });
    };
    ChapReaderComponent.prototype.changeChap = function (ev) {
        var selected = ev.target.value;
        if (selected !== this.chapname) {
            var chap = this.story.Chapters.filter(function (s) {
                return s.Name == selected;
            })[0];
            this._nav.readChapter(this.story, chap);
        }
    };
    ChapReaderComponent.prototype.viewStory = function (s) {
        this._nav.viewStory(s);
    };
    ChapReaderComponent.prototype.viewChapter = function (c) {
        console.log(this);
        this._nav.readChapter(this.story, c);
    };
    ChapReaderComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-chap-reader',
            templateUrl: 'views/reader/chap-reader.html',
            directives: [],
            providers: [chap_reader_service_1.ChapReaderService]
        })
    ], ChapReaderComponent);
    return ChapReaderComponent;
}());
exports.ChapReaderComponent = ChapReaderComponent;
