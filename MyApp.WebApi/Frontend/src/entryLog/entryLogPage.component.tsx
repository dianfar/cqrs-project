import * as React from "react";
import * as ReactDom from "react-dom";
import { observable } from "mobx";
import { observer } from "mobx-react";
import entryLogStore from "./entryLog.store";
import { IEntryLog } from "./entryLog";

@observer
class EntryLogComponent extends React.Component {
    @observable entryLogs: IEntryLog[] = [];

    constructor() {
        super();
        this.getEntryLogList();
    }

    async getEntryLogList(): Promise<void> {
        let entryLogs = await entryLogStore.getEntryLogs();
        this.entryLogs = entryLogs;
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
                                            <a className="btn btn-warning" href={`/entryLogs/${log.id}/edit`}>
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
            </div>
        );
    }
}