//import "react-hot-loader/patch";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { LoginPage } from "./loginPage.component";

export {
    LoginPage,
    renderApp
}

function renderApp(Component) {
    ReactDOM.render(<Component />, document.getElementById("app"));
}

//if (module.hot) {
//    module.hot.accept("./loginPage.component", () => {
//        let component = require("./loginPage.component").LoginPage;
//        renderApp(component);
//    });
//}