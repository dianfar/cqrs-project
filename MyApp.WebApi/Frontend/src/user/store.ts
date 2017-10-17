import { observable } from "mobx";
import axios from "axios";
import { IUser, IRole } from "./interface";

export class UserStore {
    async getUsers(): Promise<IUser[]> {
        let response = await fetch("/api/users");
        let users = await response.json() as IUser[];
        return users;
    }

    async getRoles(): Promise<IRole[]> {
        let response = await fetch("/api/roles");
        let roles = await response.json() as IRole[];
        return roles;
    }

    async getUser(userId: string): Promise<IUser> {
        let response = await fetch(`/api/users/${userId}`);
        let user = await response.json() as IUser;
        return user;
    }

    async addUser(user: IUser): Promise<void> {
        await axios.post(`/api/users/`, user);
    }

    async updateUser(user: IUser): Promise<void> {
        await axios.put(`/api/users/`, user);
    }
}

const userStore = new UserStore();

export default userStore;