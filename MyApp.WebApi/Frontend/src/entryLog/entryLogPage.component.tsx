import * as React from "react";
import { observable } from "mobx";
import { observer } from "mobx-react";
import entryLogStore from "./entryLog.store";
import projectStore from "../project/store";
import { IEntryLog } from "./entryLog";
import { IProject } from "../project/interface";

@observer
export class EntryLogComponent extends React.Component {
    @observable editMode: boolean = false;
    @observable entryLogs: IEntryLog[] = [];
    @observable entryLog: IEntryLog = {
        projectName: "",
        hours: 0,
        entryDate: "",
        description: ""
    } as IEntryLog;
    @observable projects: IProject[] = [];

    constructor() {
        super();
        this.getEntryLogList();
        this.getProjectList();
    }

    async getEntryLogList(): Promise<void> {
        let entryLogs = await entryLogStore.getEntryLogs();
        this.entryLogs = entryLogs;
    }

    async getEntryLog(id: string): Promise<void> {
        let entryLog = await entryLogStore.getEntryLog(id);
        this.entryLog = entryLog;
        this.editMode = true;
    }

    async getProjectList(): Promise<void> {
        let projects = await projectStore.getProjects();
        this.projects = projects;
        if (this.projects[0]) {
            this.entryLog.projectId = this.projects[0].id;
        }
    }

    async saveEntryLog(entryLog: IEntryLog): Promise<void> {
        if (this.editMode) {
            entryLogStore.updateEntryLog(entryLog).then(() => {
                this.getEntryLogList();
                this.entryLog = {
                    projectName: "",
                    hours: 0,
                    entryDate: "",
                    description: ""
                } as IEntryLog;
                this.editMode = false;
            });
        } else {
            entryLogStore.addEntryLog(entryLog).then(() => {
                this.getEntryLogList();
            });
        }
    }

    async deleteEntryLog(log: IEntryLog): Promise<void> {

    }

    render() {
        return (
            <div>
                <div className="panel panel-default">
                    <table className="table table-striped">
                        <thead>
                            <tr>
                                <th>
                                    Project
                                </th>
                                <th>
                                    Hours
                                </th>
                                <th>
                                    Description
                                </th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.entryLogs.map((log) => (
                                    <tr key={log.id}>
                                        <td>
                                            {log.projectName}
                                        </td>
                                        <td>
                                            {log.hours}
                                        </td>
                                        <td>
                                            {log.description}
                                        </td>
                                        <td>
                                            <a className="btn btn-warning" onClick={() => this.getEntryLog(log.id)}>
                                                <span className="glyphicon glyphicon-pencil"></span>
                                            </a>
                                            <button type="button" className="btn btn-danger" onClick={(e) => this.deleteEntryLog(log)}>
                                                <span className="glyphicon glyphicon-trash"></span>
                                            </button>
                                        </td>
                                    </tr>
                                ))
                            }
                        </tbody>
                    </table>
                </div>
                <div className="row">
                    <div className="col-md-12">
                        <form>
                            <div className="form-horizontal">
                                <hr />

                                <div className="form-group">
                                    <label className="col-md-2 control-label">Project</label>
                                    <div className="col-md-10">
                                        <select name="ProjectId" value={this.entryLog.projectId} onChange={e => this.entryLog.projectId = e.target.value} >
                                            {
                                                this.projects.map((project) => (
                                                    <option key={project.id} value={project.id} > {project.name}</option>
                                                ))
                                            }
                                        </select>
                                    </div>
                                </div>

                                <div className="form-group">
                                    <label className="col-md-2 control-label">Entry Date</label>
                                    <div className="col-md-10">
                                        <input id="datepicker" name="EntryDate" className="form-control" value={this.entryLog.entryDate} onChange={e => this.entryLog.entryDate = e.target.value} />
                                    </div>
                                </div>

                                <div className="form-group">
                                    <label className="col-md-2 control-label">Hours</label>
                                    <div className="col-md-10">
                                        <input name="Hours" className="form-control" value={this.entryLog.hours} onChange={e => this.entryLog.hours = +e.target.value} />
                                    </div>
                                </div>

                                <div className="form-group">
                                    <label className="col-md-2 control-label">Description</label>
                                    <div className="col-md-10">
                                        <input name="Description" className="form-control" value={this.entryLog.description} onChange={e => this.entryLog.description = e.target.value} />
                                    </div>
                                </div>

                                <div className="form-group">
                                    <div className="col-md-offset-2 col-md-10">
                                        <input type="button" value="Save" className="btn btn-success" onClick={() => this.saveEntryLog(this.entryLog)} />
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}