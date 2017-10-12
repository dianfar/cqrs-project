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

const userListConfig = Object.assign({}, commonConfig, {
    name: "userList",

    entry: "./Frontend/src/user/list.tsx",

    output: {
        filename: "userList.js",
        path: __dirname + "/wwwroot/script",
    },
});

module.exports = [
    clientListConfig,
    clientAddConfig,
    clientEditConfig,
    userListConfig
];