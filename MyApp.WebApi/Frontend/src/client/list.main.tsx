//import "react-hot-loader/patch";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { Client } from "./list";

export {
    Client,
    renderApp
}

function renderApp(Component) {
    ReactDOM.render(<Component />, document.getElementById("app"));
}

//if (module.hot) {
//    module.hot.accept("./list", () => {
//        let component = require("./list").Client;
//        renderApp(component);
//    });
//}