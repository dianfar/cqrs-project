import * as React from "react";
import * as ReactDOM from "react-dom";
import { HashRouter, Switch, Route } from "react-router-dom";
import { Provider } from "mobx-react";
import Client from "./client"
import AddClient from "./client/add"
import EditClient from "./client/edit"
import clientStore from "./client/store"

const route = (
    <HashRouter>
        <Switch>
            <Route exact path="/" component={Client}></Route>
            <Route exact path="/clients" component={Client}></Route>
            <Route path="/clients/add" component={AddClient}></Route>
            <Route path="/clients/:clientId/edit" component={EditClient}></Route>
        </Switch>
    </HashRouter>
);

const main = (
    <Provider clientStore={clientStore}>
        <div>
            <nav className="navbar navbar-inverse">
                <div className="container">
                    <div className="navbar-header">
                        <button type="button" className="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span className="sr-only">Toggle navigation</span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                        </button>
                        <a className="navbar-brand">Project Management System</a>
                    </div>
                    <div className="navbar-collapse collapse">
                        <ul className="nav navbar-nav">
                            <li><a>Client</a></li>
                            <li><a>Project</a></li>
                            <li><a>User</a></li>
                            <li><a>Entry Log</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div className="container body-content">
                {route}
                <hr />
                <footer>
                    <p>&copy; 2017 - Project Management System</p>
                </footer>
            </div>
        </div>
    </Provider>
);

ReactDOM.render(
    main,
    document.getElementById("main")
);