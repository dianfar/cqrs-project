import * as React from "react";
import * as ReactDOM from "react-dom";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import Client from "./client"

const main = (
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
                    <a asp-area="" asp-controller="Home" asp-action="Index" className="navbar-brand">Project Management System</a>
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
            <BrowserRouter>
                <Switch>
                    <Route exact path="/" component={Client}></Route>
                </Switch>
            </BrowserRouter>
            <hr />
            <footer>
                <p>&copy; 2017 - Project Management System</p>
            </footer>
        </div>
    </div>
);

ReactDOM.render(
    main,
    document.getElementById("main")
);