import {bootstrap} from 'angular2/platform/browser'
import {AppComponent} from './app'
import {WINDOW, WINDOW_PROVIDERS}  from  './shared/window.service'

import 'rxjs/Rx';
//import {LocalStorageSubscriber} from 'angular2-localstorage/LocalStorageEmitter';
//var appPromise =
bootstrap(AppComponent, [WINDOW_PROVIDERS]);

//LocalStorageSubscriber(appPromise)
