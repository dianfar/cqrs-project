//import "react-hot-loader/patch";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { AddUser } from "./add";

export {
    AddUser,
    renderApp
}

function renderApp(Component) {
    ReactDOM.render(<Component />, document.getElementById("app"));
}

//if (module.hot) {
//    module.hot.accept("./add", () => {
//        let component = require("./add").AddUser;
//        renderApp(component);
//    });
//}