//import "react-hot-loader/patch";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { UserList } from "./list";

export {
    UserList,
    renderApp
}

function renderApp(Component) {
    ReactDOM.render(<Component />, document.getElementById("app"));
}

//if (module.hot) {
//    module.hot.accept("./list", () => {
//        let component = require("./list").UserList;
//        renderApp(component);
//    });
//}