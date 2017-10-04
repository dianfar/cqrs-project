module.exports = {
    entry: "./Frontend/src/main.tsx",

    output: {
        filename: "bundle.js",
        path: __dirname + "/wwwroot",
    },

    resolve: {
        extensions: [".tsx", ".ts", ".js"]
    },

    module: {
        loaders: [
            {
                test: /\.tsx?$/,
                exclude: /node_modules/,
                loaders: ["ts-loader"]
            }
        ]
    }
};