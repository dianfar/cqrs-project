import * as React from "react";
import * as TestUtils from "react-dom/test-utils";
import * as ReactShallowRenderer from "react-test-renderer/shallow";
import Client from "./index";
import { ClientStore } from "./store";

const clientStore = new ClientStore();

describe("client", function () {
    it("should be created without any problem", function () {
        let client = TestUtils.renderIntoDocument(<Client clientStore={clientStore}></Client>) as React.Component;
        expect(client).toBeDefined();
    });

    it("should be rendered without any problem", function () {
        let renderer = ReactShallowRenderer.createRenderer();
        renderer.render(<Client clientStore={clientStore}></Client>);

        let result = renderer.getRenderOutput();
        expect(result).toBeDefined();
    });
});