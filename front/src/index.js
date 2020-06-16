import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import WorkerMain from "./components/WorkerMain";
import UserMain from "./components/UserMain";
import * as serviceWorker from './serviceWorker';
import { Route, Switch, BrowserRouter as Router } from 'react-router-dom'


ReactDOM.render(
  <React.StrictMode>
      <Router>
          <Switch>
              <Route exact path="/" component={ App }/>
              <Route path="/worker" component={ WorkerMain }/>
              <Route path="/user" component={ UserMain }/>
          </Switch>
      </Router>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
