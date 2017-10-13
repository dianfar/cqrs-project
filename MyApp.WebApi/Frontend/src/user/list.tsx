import * as React from "react";
import * as ReactDom from "react-dom";
import { observable } from "mobx";
import { observer } from "mobx-react";
import userStore from "./store";
import { IUser } from "./interface";

@observer
class UserList extends React.Component {
    @observable users: IUser[] = [];

    constructor() {       
        super();
        this.refreshList();
    }

    async refreshList(): Promise<void> {
        let users = await userStore.getUsers();
        this.users = users;
    }

    render() {
        return (
            <div>
                <div className="row">
                    <div className="col-md-12">
                        <div>
                            <div className="pull-left">
                                <a className="btn btn-primary" href="/users/add">
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
                                    Email
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.users.map((user) => (
                                    <tr key={user.id}>
                                        <td>
                                            {user.name}
                                        </td>
                                        <td>
                                            {user.email}
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
    <UserList></UserList>,
    document.getElementById("main")
);