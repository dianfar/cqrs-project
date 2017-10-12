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