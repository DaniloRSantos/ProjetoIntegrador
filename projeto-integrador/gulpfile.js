var gulp   = require('gulp'),
    stylus = require('gulp-stylus'),
    rename = require('gulp-rename');

gulp.task('compilar-css', function () {
    gulp.src('./Source/CSS/main-style.styl')
        .pipe(stylus())
        .pipe(gulp.dest('./Contents/CSS'))
});

gulp.task('minificar-css', function () {
    gulp.src('./Source/CSS/main-style.styl')
        .pipe(stylus({
            compress: true
        }))
        .pipe(rename(function (path) {
            path.basename += '.min'
        }))
        .pipe(gulp.dest('./Contents/CSS'))
});

gulp.task('default', function () {
    gulp.watch('./Source/CSS/*.styl', ['minificar-css', 'compilar-css']);
});

