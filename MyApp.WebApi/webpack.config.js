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

const clientListConfig = getConfig("clientList", "./Frontend/src/client/list.tsx");

const clientAddConfig = getConfig("clientAdd", "./Frontend/src/client/add.tsx");

const clientEditConfig = getConfig("clientEdit", "./Frontend/src/client/edit.tsx");

const projectListConfig = getConfig("projectList", "./Frontend/src/project/list.tsx");

const projectAddConfig = getConfig("projectAdd", "./Frontend/src/project/add.tsx");

const projectEditConfig = getConfig("projectEdit", "./Frontend/src/project/edit.tsx");

const userListConfig = getConfig("userList", "./Frontend/src/user/list.tsx");

module.exports = [
    clientListConfig,
    clientAddConfig,
    clientEditConfig,
    projectListConfig,
    projectAddConfig,
    projectEditConfig,
    userListConfig
];