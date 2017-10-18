import * as React from "react";
import { observable } from "mobx";
import { observer } from "mobx-react";
import { IUser, IRole } from "./interface";
import userStore from "./store";

interface IEditUserProps {
    userid: string
}

@observer
export class EditUser extends React.Component<IEditUserProps> {
    @observable roles: IRole[] = [];
    @observable user: IUser = {
        name: "",
        email: ""
    } as IUser;

    constructor(props) {
        super(props);
        
        userStore.getUser(this.props.userid).then(client => {
            this.user = client;
        });
        this.refreshRoleList();
    }

    async refreshRoleList(): Promise<void> {
        let roles = await userStore.getRoles();
        this.roles = roles;
    }

    async updateUser(user: IUser) {
        await userStore.updateUser(user);
        window.location.href = "/users";
    }

    render() {
        return (
            <form>
                <div className="form-horizontal">
                    <hr />
                    <div className="form-group">
                        <label className="col-md-2 control-label">Name</label>
                        <div className="col-md-10">
                            <input
                                className="form-control"
                                value={this.user.name}
                                onChange={e => this.user.name = e.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label">Email</label>
                        <div className="col-md-10">
                            <input
                                className="form-control"
                                value={this.user.email}
                                onChange={e => this.user.email = e.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label">Active</label>
                        <div className="col-md-10">
                            <input
                                type="checkbox"
                                className="form-control"
                                checked={this.user.active}
                                onChange={(e) => this.user.active = !this.user.active} />
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label">Role</label>
                        <div className="col-md-10">
                            <select name="RoleId" value={this.user.roleId} onChange={e => this.user.roleId = e.target.value} >
                                {
                                    this.roles.map((role) => (
                                        <option key={role.id} value={role.id} > {role.name}</option>
                                    ))
                                }
                            </select>
                        </div>
                    </div>

                    <div className="form-group">
                        <div className="col-md-offset-2 col-md-10">
                            <button type="button" className="btn btn-success" onClick={() => this.updateUser(this.user)}>
                                Save
                            </button>
                            <a href="/users" className="btn btn-info">Back to List</a>
                        </div>
                    </div>
                </div>
            </form>
        );
    }
}