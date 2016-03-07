/// <binding AfterBuild='copy' />
/// <binding Clean='clean' />

var gulp = require('gulp');
//var sass = require('gulp-sass');

var paths = {
    bowerSrc :"./bower_components",
    npmSrc: "./node_modules/",
    libTarget: "./wwwroot/libs/",
    vendorsTarget: "./wwwroot/vendors",
    views: ["views/*.html"],
    scss: ["content/css/*.css"],
    appFolder: 'wwwroot/app'
};

var bowerLibs = [
       paths.bowerSrc + '/bootstrap/dist/js/bootstrap.js',
       paths.bowerSrc + '/bootstrap/dist/css/bootstrap.css',
       paths.bowerSrc + '/jQuery/dist/jquery.js',
       paths.bowerSrc + '/jquery-ui/jquery-ui.min.js'
];

var libsToMove = [
   paths.npmSrc + '/angular2/bundles/angular2-polyfills.js',
   paths.npmSrc + '/systemjs/dist/system.js',
   paths.npmSrc + '/systemjs/dist/system-polyfills.js',
   paths.npmSrc + '/rxjs/bundles/Rx.js',
   paths.npmSrc + '/angular2/bundles/angular2.dev.js',
   paths.npmSrc + '/es6-shim/es6-shim.min.js',
   paths.npmSrc + 'angular2/es6/dev/src/testing/es6-shim.min.js',
   paths.npmSrc + 'angular2/bundles/router.dev.js'
];
gulp.task('moveToLibs', function () {
    return gulp.src(libsToMove).pipe(gulp.dest(paths.libTarget));
});
gulp.task('copyVendorLibs', function () {
    return gulp.src(bowerLibs).pipe(gulp.dest(paths.vendorsTarget));
});


gulp.task('copyViews', function () {
    return gulp.src(paths.views)
                .pipe(gulp.dest(paths.appFolder + '/views'));
})

gulp.task('buildCopyCSS', function () {
    return gulp.src(paths.scss)
                 //.pipe(sass())
                .pipe(gulp.dest('wwwroot/content/css'));
})

gulp.task('buildCopyIMG', function () {
    return gulp.src('content/images/*.*')
                 //.pipe(sass())
                .pipe(gulp.dest('wwwroot/content/images'));
})

gulp.task('copy', ['moveToLibs', 'copyViews', 'buildCopyCSS', 'buildCopyIMG','copyVendorLibs'], function () {
    
})

gulp.task('clean', function () {
});
