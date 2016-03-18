"use strict";
var browser_1 = require('angular2/platform/browser');
var core_1 = require('angular2/core');
var http_1 = require('angular2/http');
var angular2_jwt_1 = require('angular2-jwt');
var app_1 = require('./app');
var window_service_1 = require('./shared/window.service');
require('rxjs/Rx');
//import {LocalStorageSubscriber} from 'angular2-localstorage/LocalStorageEmitter';
//var appPromise =
browser_1.bootstrap(app_1.AppComponent, [window_service_1.WINDOW_PROVIDERS,
    http_1.HTTP_PROVIDERS,
    core_1.provide(angular2_jwt_1.AuthHttp, {
        useFactory: function (http) {
            return new angular2_jwt_1.AuthHttp(new angular2_jwt_1.AuthConfig({
                tokenName: 'auth_token'
            }), http);
        },
        deps: [http_1.Http]
    })
]);
//LocalStorageSubscriber(appPromise)
