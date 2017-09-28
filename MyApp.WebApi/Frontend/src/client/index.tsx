import * as React from "react";

class Client extends React.Component {
    render() {
        return (
            <div>
                <div className="row">
                    <div className="col-md-12">
                        <div>
                            <div className="pull-left">
                                <a className="btn btn-primary">
                                    <span title="Register New" className="glyphicon glyphicon-plus-sign"></span> Create New
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <br />

                <div className="panel panel-default">
                    <table className="table table-striped">
                        <thead>
                            <tr>
                                <th>
                                    Name
                                </th>
                                <th>
                                    Description
                                </th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {/* Todo: using state management library, get a list of clients from api and display it here */}
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }
}

export default Client;