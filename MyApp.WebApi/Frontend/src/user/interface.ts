export interface IUser {
    id: string,
    name: string,
    email: string,
    active: boolean,
    password: string,
    roleId: string,
    roleName: string
}

export interface IRole {
    id: string,
    name: string
}