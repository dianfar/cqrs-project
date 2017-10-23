//import "react-hot-loader/patch";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { EditClient } from "./edit";

export {
    EditClient,
    renderApp
}

function renderApp(Component, id: string) {
    ReactDOM.render(<Component clientid={id} />, document.getElementById("app"));
}

//if (module.hot) {
//    module.hot.accept("./edit", () => {
//        let component = require("./edit").EditClient;
//        renderApp(component);
//    });
//}