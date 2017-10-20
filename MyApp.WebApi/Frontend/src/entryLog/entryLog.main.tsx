//import "react-hot-loader/patch";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { EntryLogComponent } from "./entryLogPage.component";

export {
    EntryLogComponent,
    renderApp
}

function renderApp(Component) {
    ReactDOM.render(<Component />, document.getElementById("app"));
}

//if (module.hot) {
//    module.hot.accept("./entryLogPage.component", () => {
//        let component = require("./entryLogPage.component").EntryLogComponent;
//        renderApp(component);
//    });
//}