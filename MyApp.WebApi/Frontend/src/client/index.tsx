import * as React from "react";
import { Link } from "react-router-dom";
import { observer, inject } from "mobx-react";
import { ClientStore } from "./store";

interface IClientProps {
    clientStore: ClientStore
}

@inject("clientStore")
@observer
class Client extends React.Component<IClientProps> {
    constructor(props) {
        super(props);
        const { clientStore } = this.props;
        clientStore.getClients();
    }

    render() {
        const { clientStore } = this.props;
        return (
            <div>
                <div className="row">
                    <div className="col-md-12">
                        <div>
                            <div className="pull-left">
                                <Link className="btn btn-primary" to={`/clients/add`}>
                                    <span title="Register New" className="glyphicon glyphicon-plus-sign"></span> Create New
                                </Link>
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
                                clientStore.clients.map((client) => (
                                    <tr key={client.id}>
                                        <td>
                                            {client.name}
                                        </td>
                                        <td>
                                            {client.description}
                                        </td>
                                        <td>
                                            <Link className="btn btn-warning" to={`/clients/${client.id}/edit`}>
                                                <span className="glyphicon glyphicon-pencil"></span>
                                            </Link>
                                            <button type="button" className="btn btn-danger" onClick={(e) => clientStore.deleteClient(client.id)}>
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

export default Client;