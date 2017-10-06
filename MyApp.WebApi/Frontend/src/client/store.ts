import { IObservableArray, observable } from "mobx";
import * as fetch from "isomorphic-fetch";
import { IClient } from "./interface";

export class ClientStore {
    @observable clients: IClient[];

    constructor(clients?: IClient[]) {
        if (clients) {
            this.clients = clients;
            return;
        }

        this.clients = [];
    }

    async getClients(): Promise<IClient[]> {
        let response = await fetch("/api/clients");
        let clients = await response.json() as IObservableArray<IClient>;
        this.clients = clients;
        return this.clients;
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