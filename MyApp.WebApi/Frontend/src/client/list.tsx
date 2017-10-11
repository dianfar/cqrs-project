import * as React from "react";
import * as ReactDom from "react-dom";
import { observable } from "mobx";
import { observer } from "mobx-react";
import clientStore from "./store";
import { IClient } from "./interface";

@observer
class Client extends React.Component {
    @observable clients: IClient[] = [];

    constructor(props) {
        super(props);

        this.refreshList = this.refreshList.bind(this);
        this.refreshList();
    }

    async refreshList(): Promise<void> {
        let clients = await clientStore.getClients();
        this.clients = clients;
    }

    async deleteClient(client: IClient): Promise<void> {
        await clientStore.deleteClient(client.id);
        this.refreshList();
    }

    render() {
        return (
            <div>
                <div className="row">
                    <div className="col-md-12">
                        <div>
                            <div className="pull-left">
                                <a className="btn btn-primary" href="/clients/add">
                                    <span title="Register New" className="glyphicon glyphicon-plus-sign"></span> Create New
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <br />

                <div className="panel panel-default">
                    <table className="table table-striped">
                        <thead>
                            <tr>
                                <th>
                                    Name
                                </th>
                                <th>
                                    Description
                                </th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.clients.map((client) => (
                                    <tr key={client.id}>
                                        <td>
                                            {client.name}
                                        </td>
                                        <td>
                                            {client.description}
                                        </td>
                                        <td>
                                            <a className="btn btn-warning" href={`/clients/${client.id}/edit`}>
                                                <span className="glyphicon glyphicon-pencil"></span>
                                            </a>
                                            <button type="button" className="btn btn-danger" onClick={(e) => this.deleteClient(client)}>
                                                <span className="glyphicon glyphicon-trash"></span>
                                            </button>
                                        </td>
                                    </tr>
                                ))
                            }
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }
}

ReactDom.render(
    <Client></Client>,
    document.getElementById("main")
);