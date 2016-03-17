"use strict";
var browser_1 = require('angular2/platform/browser');
var app_1 = require('./app');
var window_service_1 = require('./shared/window.service');
require('rxjs/Rx');
//import {LocalStorageSubscriber} from 'angular2-localstorage/LocalStorageEmitter';
//var appPromise =
browser_1.bootstrap(app_1.AppComponent, [window_service_1.WINDOW_PROVIDERS]);
//LocalStorageSubscriber(appPromise)
