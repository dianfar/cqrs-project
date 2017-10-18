import * as React from "react";
import { observable } from "mobx";
import { observer } from "mobx-react";
import accountStore from "./account.store";
import { IAccount } from "./account";

@observer
export class LoginPage extends React.Component {
    @observable account: IAccount = {
        email: "",
        password: ""
    };

    async login(account: IAccount): Promise<any> {
        accountStore.login(account).then(() => {
            window.location.href = "/clients";
        });
    }

    render() {
        return (
            <form>
                <div className="form-horizontal">
                    <hr />
                    <div className="form-group">
                        <label className="col-md-2 control-label">Email</label>
                        <div className="col-md-10">
                            <input name="Email"
                                className="form-control"
                                value={this.account.email}
                                onChange={(event) => this.account.email = event.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="col-md-2 control-label">Password</label>
                        <div className="col-md-10">
                            <input type="password"
                                name="Password"
                                className="form-control"
                                value={this.account.password}
                                onChange={(event) => this.account.password = event.target.value} />
                        </div>
                    </div>

                    <div className="form-group">
                        <div className="col-md-offset-2 col-md-10">
                            <input type="button" value="Login" className="btn btn-success" onClick={() => this.login(this.account)} />
                        </div>
                    </div>
                </div>
            </form>
        );
    }
}