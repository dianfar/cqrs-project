/// <binding BeforeBuild='default' />
var gulp = require("gulp");
var exec = require("child_process").exec;
var runSequence = require("run-sequence");

gulp.task("copy:html", function () {
    return gulp.src("Frontend/src/index.html")
        .pipe(gulp.dest("wwwroot"));
});

gulp.task("webpack", function () {
    return exec("node ./node_modules/webpack/bin/webpack.js", function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
    });
});

gulp.task("karma", function () {
    return exec("karma start karma.conf.js", function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
    });
});

gulp.task("copy:lib", function () {
    var lib =
        [
            ["jquery/dist", "node_modules/jquery/dist/jquery.min.js"],
            ["bootstrap/dist", "node_modules/bootstrap/dist/**"]
        ];

    for (var index in lib) {
        gulp.src(lib[index][1]).pipe(gulp.dest("wwwroot/lib/" + lib[index][0]));
    }
});

gulp.task("tasks", ["karma", "copy:lib", "copy:html", "webpack"]);

gulp.task("default",
    function (callback) {
        runSequence("tasks", callback);
    }
);