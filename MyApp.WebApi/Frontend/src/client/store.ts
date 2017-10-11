import { IObservableArray, observable } from "mobx";
import axios from "axios";
import { IClient } from "./interface";

export class ClientStore {
    async getClients(): Promise<IClient[]> {
        let response = await axios.get("/api/clients");
        let clients = response.data as IClient[];
        return clients;
    }

    async getClient(clientId: string): Promise<IClient> {
        let response = await axios.get(`/api/clients/${clientId}`);
        let client = response.data as IClient;
        return client;
    }

    async updateClient(client: IClient): Promise<void> {
        await axios.put(`/api/clients/`, client);
    }

    async addClient(client: IClient): Promise<void> {
        await axios.post(`/api/clients/`, client);
    }

    async deleteClient(clientId: string): Promise<void> {
        await axios.delete(`/api/clients/${clientId}`);
    }
}

const clientStore = new ClientStore();

export default clientStore;