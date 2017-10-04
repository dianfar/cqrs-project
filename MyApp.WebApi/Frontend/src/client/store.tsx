import { IObservableArray } from "mobx";
import { types } from "mobx-state-tree";
import * as fetch from "isomorphic-fetch";

export const Client = types.model("client", {
    id: types.identifier<string>(),
    name: types.string,
    description: types.string
});

export type IClient = typeof Client.Type;

export const ClientStore = types.model("clientStore", {
    clients: types.array(Client)
}).actions(self => ({
    async getClients(): Promise<IObservableArray<IClient>> {
        let response = await fetch("/api/clients");
        let clients = await response.json() as IObservableArray<IClient>;
        return (self as IClientStore).loadClients(clients);
    },

    loadClients(clients: IObservableArray<IClient>): IObservableArray<IClient> {
        self.clients = clients;
        return self.clients;
    },
}));

export type IClientStore = typeof ClientStore.Type;

const clientStore = ClientStore.create({
    clients: []
});

export default clientStore;