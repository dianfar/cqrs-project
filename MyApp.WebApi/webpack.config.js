const commonConfig = {
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

function getConfig(configName, fileUrl) {
    return Object.assign({}, commonConfig, {
        name: configName,

        entry: fileUrl,

        output: {
            filename: `${configName}.js`,
            path: __dirname + "/wwwroot/script",
        },
    });
}

const mainConfig = getConfig("main", "./Frontend/src/main.ts");

module.exports = [
    mainConfig
];