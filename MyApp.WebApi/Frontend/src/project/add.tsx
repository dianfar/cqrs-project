import * as React from "react";
import { observable } from "mobx";
import { observer } from "mobx-react";
import { IAddProject } from "./interface";
import projectStore from "./store";

@observer
export class AddProject extends React.Component {
    @observable project: IAddProject = {
        name: "",
        description: "",
        completionDate: "",
        clientId: "",
        clients: []
    } as IAddProject;

    constructor(props) {
        super(props);
        
        this.getAddProject();
    }
    
    async getAddProject(): Promise<void> {
        let project = await projectStore.getAddProject();
        if (project.clients[0]) {
            this.project.clientId = project.clients[0].id;
            this.project.clients = project.clients;
        }
    }

    async addProject(project: IAddProject): Promise<void> {
        await projectStore.addProject(project);
        window.location.href = "/projects";
    }

    render() {
        return (
            <form>
                <div className="form-horizontal">
                    <hr />
                    <div className="form-group">
                        <label className="col-md-2 control-label">Name</label>
                        <div className="col-md-10">
                            <input name="Name" className="form-control" type="text" value={this.project.name} onChange={e => this.project.name = e.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label">Client</label>
                        <div className="col-md-10">
                            <select name="ClientId" value={this.project.clientId} onChange={e => this.project.clientId = e.target.value}>
                                {
                                    this.project.clients.map(client => (
                                        <option key={client.id} value={client.id}>{client.name}</option>
                                    ))
                                }
                            </select>
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label">Description</label>
                        <div className="col-md-10">
                            <input name="Description" className="form-control" type="text" value={this.project.description} onChange={e => this.project.description = e.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label">Completion Date</label>
                        <div className="col-md-10">
                            <input name="CompletionDate" className="form-control" type="datetime" value={this.project.completionDate} onChange={e => this.project.completionDate = e.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <div className="col-md-offset-2 col-md-10">
                            <button type="button" className="btn btn-success" onClick={e => this.addProject(this.project)}>Create</button>
                            <a href="/projects" className="btn btn-info">Back to List</a>
                        </div>
                    </div>
                </div>
            </form>
        );
    }
}