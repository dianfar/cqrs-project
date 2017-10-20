//import "react-hot-loader/patch";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { EditProject } from "./edit";

export {
    EditProject,
    renderApp
}

function renderApp(Component, id: string) {
    ReactDOM.render(<Component projectid={id} />, document.getElementById("app"));
}

//if (module.hot) {
//    module.hot.accept("./edit", () => {
//        let component = require("./edit").EditProject;
//        renderApp(component);
//    });
//}