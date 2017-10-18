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
    constructor() {
        super();
        
        const builder = new ReactHabitat.ContainerBuilder();
        builder.register(Client).as("Client");
        builder.register(AddClient).as("AddClient");
        builder.register(EditClient).as("EditClient");
        builder.register(Project).as("Project");
        builder.register(AddProject).as("AddProject");
        builder.register(EditProject).as("EditProject");
        builder.register(UserList).as("User");
        builder.register(AddUser).as("AddUser");
        builder.register(EditUser).as("EditUser");
        builder.register(EntryLogComponent).as("EntryLog");
        builder.register(LoginPage).as("Login");
        this.setContainer(builder.build());
    }
}

export default new Main();