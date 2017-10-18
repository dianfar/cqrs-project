import * as React from "react";
import { observable } from "mobx";
import { observer } from "mobx-react";
import projectStore from "./store";
import { IProject } from "./interface";

@observer
export class Project extends React.Component {
    @observable projects: IProject[] = [];

    constructor(props) {
        super(props);
        
        this.refreshList();
    }

    async refreshList(): Promise<void> {
        let projects = await projectStore.getProjects();
        this.projects = projects;
    }

    async deleteProject(project: IProject): Promise<void> {
        await projectStore.deleteProject(project.id);
        this.refreshList();
    }

    render() {
        return (
            <div>
                <div className="row">
                    <div className="col-md-12">
                        <div>
                            <div className="pull-left">
                                <a href="/projects/add" className="btn btn-primary">
                                    <span title="Create New" className="glyphicon glyphicon-plus-sign"></span> Create New
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
                                    Client Name
                                </th>
                                <th>
                                    Completion Date
                                </th>
                                <th>
                                    Status
                                </th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.projects.map(project => (
                                    <tr key={project.id}>
                                        <td>
                                            {project.name}
                                    </td>
                                        <td>
                                            {project.clientName}
                                    </td>
                                        <td>
                                            {project.completionDate}
                                    </td>
                                        <td>
                                            {project.active ? "active" : "inactive"}
                                    </td>
                                        <td>
                                            <a href={`/projects/${project.id}/edit`} className="btn btn-warning">
                                                <span className="glyphicon glyphicon-pencil"></span>
                                            </a>
                                            <button type="button" className="btn btn-danger" onClick={e => this.deleteProject(project)}>
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