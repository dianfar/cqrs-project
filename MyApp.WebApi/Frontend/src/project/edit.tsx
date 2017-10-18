import * as React from "react";
import * as ReactDom from "react-dom";
import { observable } from "mobx";
import { observer } from "mobx-react";
import { IEditProject } from "./interface";
import projectStore from "./store";

interface IEditProjectProps {
    projectId: string
}

@observer
class EditProject extends React.Component<IEditProjectProps> {
    @observable project: IEditProject = {
        name: "",
        description: "",
        completionDate: "",
        active: false,
        clientId: "",
        clients: []
    } as IEditProject;

    constructor(props) {
        super(props);
        
        projectStore.getEditProject(this.props.projectId).then(project => {
            this.project = project;
        });
    }

    async updateProject(project: IEditProject) {
        await projectStore.updateProject(project);
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
                            <input name="Name" className="form-control" value={this.project.name} onChange={e => this.project.name = e.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label">Client</label>
                        <div className="col-md-10">
                            <select name="ClientId" value={this.project.clientId} onChange={e => this.project.clientId = e.target.value} >
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
                            <input name="Description" className="form-control" value={this.project.description} onChange={e => this.project.description = e.target.value} />
                            </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label">Completion Date</label>
                        <div className="col-md-10">
                            <input name="CompletionDate" className="form-control" type="datetime" value={this.project.completionDate} onChange={e => this.project.completionDate = e.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label">Active</label>
                        <div className="col-md-10">
                            <input type="checkbox" value={this.project.active ? 1 : 0} onChange={e => this.project.active = +e.target.value > 0} />
                        </div>
                    </div>

                    <div className="form-group">
                        <div className="col-md-offset-2 col-md-10">
                            <button type="button" className="btn btn-success" onClick={e => this.updateProject(this.project)}>Update</button>
                            <a href="/projects" className="btn btn-info">Back to List</a>
                        </div>
                    </div>
                </div>
            </form>
        );
    }
}

const html = document.getElementById("main");

ReactDom.render(
    <EditProject projectId={html.getAttribute("data-projectid")}></EditProject>,
    html
);