import './App.css';
import {BrowserRouter, Route, Switch} from "react-router-dom";
import {AuthProvider} from "./providers/AuthProvider";
import React, {Fragment} from "react";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Register from "./pages/Register";
function App() {

    return (
      <BrowserRouter>
        <AuthProvider>
          <Fragment>
              <Route exact path="/" component={Home} />
              <Switch>
                  <Route exact path="/login" component={Login} />
                  <Route exact path="/register" component={Register} />
              </Switch>
          </Fragment>
        </AuthProvider>
      </BrowserRouter>
    );
}


export default App;
