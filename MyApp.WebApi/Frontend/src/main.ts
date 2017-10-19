import "react-hot-loader/patch";
import * as ReactHabitat from "react-habitat";
import { Client } from "./client/list";
import { AddClient } from "./client/add";
import { EditClient } from "./client/edit";
import { Project } from "./project/list";
import { AddProject } from "./project/add";
import { EditProject } from "./project/edit";
import { UserList } from "./user/list";
import { AddUser } from "./user/add";
import { EditUser } from "./user/edit";
import { EntryLogComponent } from "./entryLog/entryLogPage.component";
import { LoginPage } from "./account/loginPage.component";

class Main extends ReactHabitat.Bootstrapper {
    client = Client;
    addClient = AddClient;
    editClient = EditClient;
    project = Project;
    addProject = AddProject;
    editProject = EditProject;
    user = UserList;
    addUser = AddUser;
    editUser = EditUser;
    entryLog = EntryLogComponent;
    login = LoginPage;

    build() {
        const builder = new ReactHabitat.ContainerBuilder();
        builder.register(this.client).as("Client");
        builder.register(this.addClient).as("AddClient");
        builder.register(this.editClient).as("EditClient");
        builder.register(this.project).as("Project");
        builder.register(this.addProject).as("AddProject");
        builder.register(this.editProject).as("EditProject");
        builder.register(this.user).as("User");
        builder.register(this.addUser).as("AddUser");
        builder.register(this.editUser).as("EditUser");
        builder.register(this.entryLog).as("EntryLog");
        builder.register(this.login).as("Login");

        this.setContainer(builder.build());
    }
}

const main = new Main();
main.build();

if (module.hot) {
    module.hot.accept([
        "./client/list",
        "./client/add",
        "./client/edit",
        "./project/list",
        "./project/add",
        "./project/edit",
        "./user/list",
        "./user/add",
        "./user/edit",
        "./entryLog/entryLogPage.component",
        "./account/loginPage.component"], () => {
            main.client = require("./client/list").Client;
            main.addClient = require("./client/add").AddClient;
            main.editClient = require("./client/edit").EditClient;
            main.project = require("./project/list").Project;
            main.addProject = require("./project/add").AddProject;
            main.editProject = require("./project/edit").EditProject;
            main.user = require("./user/list").User;
            main.addUser = require("./user/add").AddUser;
            main.editUser = require("./user/edit").EditUser;
            main.entryLog = require("./entryLog/entryLogPage.component").EntryLogComponent;
            main.login = require("./account/loginPage.component").LoginPage;
            main.dispose();
            main.build();
        });
}

export default main;