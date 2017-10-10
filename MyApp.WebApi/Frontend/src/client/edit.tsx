import * as React from "react";
import { observable } from "mobx";
import { observer, inject } from "mobx-react";
import { IClient } from "./interface";
import { ClientStore } from "./store";

interface IEditClientProps {
    clientStore: ClientStore
}

@inject("clientStore")
@observer
class EditClient extends React.Component<IEditClientProps> {
    @observable client: IClient = {
        name: "",
        description: ""
    } as IClient;

    constructor(props) {
        super(props);

        const { clientStore } = props;
        const clientId = (props as any).match.params.clientId;
        clientStore.getClient(clientId).then(client => {
            this.client = client;
        });
    }

    render() {
        const { clientStore } = this.props;

        return (
            <form>
                <div className="form-horizontal">
                    <hr />
                    <div className="form-group">
                        <label className="col-md-2 control-label"></label>
                        <div className="col-md-10">
                            <input
                                className="form-control"
                                value={this.client.name}
                                onChange={e => this.client.name = e.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label"></label>
                        <div className="col-md-10">
                            <input
                                className="form-control"
                                value={this.client.description}
                                onChange={e => this.client.description = e.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <div className="col-md-offset-2 col-md-10">
                            <button type="button" className="btn btn-success" onClick={() => clientStore.updateClient(this.client)}>
                                Save
                            </button>
                            <a href="/client" className="btn btn-info">Back to List</a>
                        </div>
                    </div>
                </div>
            </form>
        );
    }
}

export default EditClient;