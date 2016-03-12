"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Story = (function () {
    function Story() {
    }
    return Story;
}());
exports.Story = Story;
var GenreRes = (function () {
    function GenreRes() {
    }
    return GenreRes;
}());
exports.GenreRes = GenreRes;
var GenreInfo = (function () {
    function GenreInfo() {
    }
    return GenreInfo;
}());
exports.GenreInfo = GenreInfo;
var StoryListRes = (function (_super) {
    __extends(StoryListRes, _super);
    function StoryListRes() {
        _super.apply(this, arguments);
    }
    return StoryListRes;
}(GenreRes));
exports.StoryListRes = StoryListRes;
