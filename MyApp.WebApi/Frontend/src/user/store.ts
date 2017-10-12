import { IObservableArray, observable } from "mobx";
import * as fetch from "isomorphic-fetch";
import { IUser } from "./interface";

export class UserStore {
    async getUsers(): Promise<IUser[]> {
        let response = await fetch("/api/users");
        let users = await response.json() as IUser[];
        return users;
    }
}

const userStore = new UserStore();

export default userStore;