import {bootstrap} from 'angular2/platform/browser';
import {provide} from 'angular2/core';
import {HTTP_PROVIDERS, Http} from 'angular2/http'
import {AuthHttp, AuthConfig} from 'angular2-jwt';
import {AppComponent} from './app'
import {WINDOW, WINDOW_PROVIDERS}  from  './shared/window.service'

import 'rxjs/Rx';
//import {LocalStorageSubscriber} from 'angular2-localstorage/LocalStorageEmitter';
//var appPromise =
bootstrap(AppComponent, [WINDOW_PROVIDERS,
    HTTP_PROVIDERS,
    provide(AuthHttp, {
        useFactory: (http) => {
            return new AuthHttp(new AuthConfig(
                {
                    tokenName: 'auth_token'
                }
            ), http);
        },
        deps: [Http]
    })

]);

//LocalStorageSubscriber(appPromise)
