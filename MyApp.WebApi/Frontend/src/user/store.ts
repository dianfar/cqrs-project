import { IObservableArray, observable } from "mobx";
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

    async addUser(user: IUser): Promise<void> {
        await axios.post(`/api/users/`, user);
    }
}

const userStore = new UserStore();

export default userStore;