//import "react-hot-loader/patch";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { AddClient } from "./add";

export {
    AddClient,
    renderApp
}

function renderApp(Component) {
    ReactDOM.render(<Component />, document.getElementById("app"));
}

//if (module.hot) {
//    module.hot.accept("./add", () => {
//        let component = require("./add").AddClient;
//        renderApp(component);
//    });
//}