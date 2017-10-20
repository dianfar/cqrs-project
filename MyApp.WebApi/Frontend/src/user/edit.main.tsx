//import "react-hot-loader/patch";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { EditUser } from "./edit";

export {
    EditUser,
    renderApp
}

function renderApp(Component, id: string) {
    ReactDOM.render(<Component userid={id} />, document.getElementById("app"));
}

//if (module.hot) {
//    module.hot.accept("./edit", () => {
//        let component = require("./edit").EditUser;
//        renderApp(component);
//    });
//}