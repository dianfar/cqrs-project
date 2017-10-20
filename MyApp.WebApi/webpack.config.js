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

        entry: { "main": fileUrl },

        output: {
            filename: `${configName}.js`,
            path: __dirname + "/wwwroot/scripts",
            //publicPath: '/',
            //hotUpdateChunkFilename: 'hot/hot-update.js',
            //hotUpdateMainFilename: 'hot/hot-update.json',
            library: "MyApp"
        },
    });
}

const clientListConfig = getConfig("clientList", "./Frontend/src/client/list.main.tsx");
const clientEditConfig = getConfig("clientEdit", "./Frontend/src/client/edit.main.tsx");
const clientAddConfig = getConfig("clientAdd", "./Frontend/src/client/add.main.tsx");
const projectListConfig = getConfig("projectList", "./Frontend/src/project/list.main.tsx");
const projectEditConfig = getConfig("projectEdit", "./Frontend/src/project/edit.main.tsx");
const projectAddConfig = getConfig("projectAdd", "./Frontend/src/project/add.main.tsx");
const userListConfig = getConfig("userList", "./Frontend/src/user/list.main.tsx");
const userEditConfig = getConfig("userEdit", "./Frontend/src/user/edit.main.tsx");
const userAddConfig = getConfig("userAdd", "./Frontend/src/user/add.main.tsx");
const loginConfig = getConfig("login", "./Frontend/src/account/loginPage.main.tsx");
const entryLogConfig = getConfig("entryLog", "./Frontend/src/entryLog/entryLog.main.tsx");

module.exports = [
    clientListConfig,
    clientEditConfig,
    clientAddConfig,
    projectListConfig,
    projectEditConfig,
    projectAddConfig,
    userListConfig,
    userEditConfig,
    userAddConfig,
    loginConfig,
    entryLogConfig
];