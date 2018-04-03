/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

var deps = {
    "jquery": {
        "dist/*": ""
    },
    "jquery-validation": {
        "dist/*": ""
    },
    "jquery-validation-unobtrusive": {
        "dist/*": ""
    },
    "bootstrap": {
        "dist/**/*": ""
    },
    "font-awesome": {
        "css/*": ""
    },
    // ...

};

gulp.task('default', function () {
    // place code for your default task here
});

gulp.task("scripts", function () {

    var streams = [];

    for (var prop in deps) {
        console.log("Prepping Scripts for: " + prop);
        for (var itemProp in deps[prop]) {
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest("wwwroot/vendor/" + prop + "/" + deps[prop][itemProp])));
        }
    }

    return merge(streams);

});