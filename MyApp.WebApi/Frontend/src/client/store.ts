import { IObservableArray, observable } from "mobx";
import * as fetch from "isomorphic-fetch";
import { IClient } from "./interface";

export class ClientStore {
    @observable clients: IClient[] = [];
    
    async getClients(): Promise<IClient[]> {
        let response = await fetch("/api/clients");
        let clients = await response.json() as IClient[];
        this.clients = clients;
        return this.clients;
    }

    async getClient(clientId: string): Promise<IClient> {
        let response = await fetch(`/api/clients/${clientId}`);
        let client = await response.json() as IClient;
        return client;
    }

    async updateClient(client: IClient): Promise<void> {
        await fetch(`/api/clients/`, {
            method: "put",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(client)
        });
    }

    async addClient(client: IClient): Promise<void> {
        await fetch(`/api/clients/`, {
            method: "post",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(client)
        });
    }

    async deleteClient(clientId: string): Promise<void> {
        let response = await fetch(`/api/clients/${clientId}`, {
            method: "delete"
        });

        if (response.status == 200) {
            let clientIndex = this.clients.findIndex(client => client.id == clientId);
            this.clients.splice(clientIndex, 1);
        };
    }
}

const clientStore = new ClientStore();

export default clientStore;