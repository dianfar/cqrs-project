import * as React from "react";
import * as TestUtils from "react-dom/test-utils";
import * as ReactShallowRenderer from "react-test-renderer/shallow";
import Client from "./index";

describe("client", function () {
    it("should be created without any problem", function () {
        let client = TestUtils.renderIntoDocument(<Client></Client>) as React.Component;
        expect(client).toBeDefined();
    });

    it("should be rendered without any problem", function () {
        let renderer = ReactShallowRenderer.createRenderer();
        renderer.render(<Client></Client>);

        let result = renderer.getRenderOutput();
        expect(result).toBeDefined();
    });
});