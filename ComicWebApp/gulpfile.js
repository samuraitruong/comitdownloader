/// <binding />
/// <binding Clean='clean' />

var gulp = require('gulp');
var gulpLoadPlugins = require('gulp-load-plugins');
var plugins = gulpLoadPlugins();

//var sass = require('gulp-sass');

var paths = {
    bowerSrc :"./bower_components",
    npmSrc: "./node_modules/",
    libTarget: "./wwwroot/libs/",
    vendorsTarget: "./wwwroot/vendors",
    views: ["views/*.html"],
    scss: ["content/css/*.scss","content/css/**/*.scss"],
    appFolder: 'wwwroot/app',
    htmls: ['scripts/*.html', 'scripts/**/*.html'],
    typescripts: ['scripts/*.ts', 'scripts/**/*.ts'],
};

var bowerLibs = [
       paths.bowerSrc + '/bootstrap/dist/js/bootstrap.js',
       paths.bowerSrc + '/bootstrap/dist/css/bootstrap.css',
       paths.bowerSrc + '/jQuery/dist/jquery.js',
       paths.bowerSrc + '/jquery-ui/jquery-ui.min.js',
       paths.bowerSrc + '/jcarousel/dist/jquery.jcarousel.min.js',
       paths.bowerSrc + '/jcarousel/examples/responsives/jcarousel.responsive.css',
       paths.bowerSrc + '/jquery-ui/themes/vader/jquery-ui.min.css',
       paths.bowerSrc + '/nanoscroller/bin/javascripts/jquery.nanoscroller.min.js',
       paths.bowerSrc + '/nanoscroller/bin/css/nanoscroller.css'
       
];

var libsToMove = [
   paths.npmSrc + '/angular2/bundles/angular2-polyfills.js',
   paths.npmSrc + '/systemjs/dist/system.js',
   paths.npmSrc + '/systemjs/dist/system-polyfills.js',
   paths.npmSrc + '/rxjs/bundles/Rx.js',
   paths.npmSrc + '/angular2/bundles/angular2.dev.js',
   paths.npmSrc + '/es6-shim/es6-shim.min.js',
   paths.npmSrc + 'angular2/es6/dev/src/testing/es6-shim.min.js',
   paths.npmSrc + 'angular2/bundles/router.dev.js',
   paths.npmSrc + 'angular2/bundles/http.dev.js',
   paths.npmSrc + 'ng2-bootstrap/bundles/ng2-bootstrap.min.js',
   paths.npmSrc + 'moment/moment.js'

];


gulp.task('moveToLibs', function () {
    return gulp.src(libsToMove).pipe(gulp.dest(paths.libTarget));
});

gulp.task('copyHtml', function () {
    return gulp.src(paths.htmls)
        .pipe(gulp.dest("wwwroot/views"))
        .pipe(plugins.livereload());
});


gulp.task('copyVendorLibs', function () {
    return gulp.src(bowerLibs).pipe(gulp.dest(paths.vendorsTarget));
});


gulp.task('copyViews', function () {
    return gulp.src(paths.views)
                .pipe(gulp.dest(paths.appFolder + '/views'));
})

gulp.task('css:build', function () {
    return gulp.src(paths.scss)
                .pipe(plugins.sass())
                .pipe(plugins.autoprefixer({
                    browsers: ['last 2 versions'],
                    cascade: false
                }))
                .pipe(plugins.csso())
                .pipe(plugins.size())
                .pipe(gulp.dest('wwwroot/content/css'))
                .pipe(plugins.livereload())
                .pipe(plugins.concatCss('all.min.css'))
                .pipe(plugins.csso())
                .pipe(plugins.size())
                .pipe(gulp.dest('wwwroot/content/css/'))
                .pipe(plugins.livereload());
})

gulp.task('buildCopyIMG', function () {
    return gulp.src('content/images/*.*')
                 //.pipe(sass())
                .pipe(gulp.dest('wwwroot/content/images'));
})

gulp.task('copy', ['moveToLibs', 'copyViews', 'css:build', 'buildCopyIMG', 'copyVendorLibs', 'copyHtml', 'typescript:build'], function () {
    plugins.sequence('typescript:build')
})

gulp.task('watch', ['copy'], function () {
    plugins.livereload.listen({ start: true });

    gulp.watch(paths.htmls, ['copyHtml']).on('ready', function () { console.log('watching html: ' + paths.htmls.join()) });;
    gulp.watch(paths.typescripts, ['typescript:build']).on('ready', function () { console.log('watching typescript: ' + paths.typescripts.join()) });;
    gulp.watch(paths.scss, ['css:build']).on('ready', function () { console.log('watching: ' + paths.scss.join()) });
    
    console.log('watching: html/typescripts')
});
gulp.task('typescript:compile', function () {
    var tsProject = plugins.typescript.createProject('tsconfig.json');

    //return gulp.src(['scripts/*.ts','scripts/**/*.ts'])
	//	.pipe(plugins.typescript({
	//	    noImplicitAny: false,
	//	    experimentalDecorators: true,
    //        out:'test.js',
	//	    outDir: 'wwwroot/test'
	//	}))
    //	.pipe(gulp.dest('wwwroot/test'));

    var tsResult = tsProject.src() // instead of gulp.src(...) 
        .pipe(plugins.typescript(tsProject));
    return tsResult.js.pipe(gulp.dest('.temp/'));
});
gulp.task('typescript:copy', function () {
    return gulp.src(['./.temp/scripts/*.*', './.temp/scripts/**/*.*'])
        //.pipe(plugins.replaceName(/Scripts/,'xxx'))
        .pipe(gulp.dest('wwwroot/app/'))
        .pipe(plugins.livereload());
});

gulp.task('typescript:build', function (cb) {
    plugins.sequence('typescript:compile', 'typescript:copy', cb);
});


gulp.task('clean', function () {
});
