import { IClient } from "../client/interface";

export interface IProjectMember {
    id: string,
    projectId: string,
    userId: string,
    userName: string
}

export interface IProject {
    id: string,
    name: string,
    description: string,
    completionDate: string,
    active: boolean,
    clientId: string,
    clientName: string,
    projectMembers: IProjectMember[]
}

export interface IAddProject extends IProject {
    clients: IClient[];
}

export interface IEditProject extends IProject {
    clients: IClient[];
    users: any[]; // TODO - change type to IUser[]
}