import axios from "axios";
import { IAccount } from "./account";

export class AccountStore {
    async login(account: IAccount): Promise<any> {
        return await axios.post(`/api/account/login`, account);
    }
}

const accountStore = new AccountStore();

export default accountStore;