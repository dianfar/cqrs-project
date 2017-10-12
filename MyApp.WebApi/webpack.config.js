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

const clientListConfig = Object.assign({}, commonConfig, {
    name: "clientList",

    entry: "./Frontend/src/client/list.tsx",

    output: {
        filename: "clientList.js",
        path: __dirname + "/wwwroot/script",
    },
});

const clientAddConfig = Object.assign({}, commonConfig, {
    name: "clientAdd",

    entry: "./Frontend/src/client/add.tsx",

    output: {
        filename: "clientAdd.js",
        path: __dirname + "/wwwroot/script",
    },
});

const clientEditConfig = Object.assign({}, commonConfig, {
    name: "clientEdit",

    entry: "./Frontend/src/client/edit.tsx",

    output: {
        filename: "clientEdit.js",
        path: __dirname + "/wwwroot/script",
    },
});

const projectListConfig = Object.assign({}, commonConfig, {
    name: "projectList",

    entry: "./Frontend/src/project/list.tsx",

    output: {
        filename: "projectList.js",
        path: __dirname + "/wwwroot/script",
    },
});

const projectAddConfig = Object.assign({}, commonConfig, {
    name: "projectAdd",

    entry: "./Frontend/src/project/add.tsx",

    output: {
        filename: "projectAdd.js",
        path: __dirname + "/wwwroot/script",
    },
});

const projectEditConfig = Object.assign({}, commonConfig, {
    name: "projectEdit",

    entry: "./Frontend/src/project/edit.tsx",

    output: {
        filename: "projectEdit.js",
        path: __dirname + "/wwwroot/script",
    },
});

module.exports = [
    clientListConfig,
    clientAddConfig,
    clientEditConfig,
    projectListConfig,
    projectAddConfig,
    projectEditConfig
];