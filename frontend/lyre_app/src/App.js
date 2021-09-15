import './App.css';
import MainPage from './Pages/MainPage';
import LoginPage from './Pages/LoginPage';
import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";
import setupAxios from "./Common/setupAxios";

// Setup default axios config
setupAxios()

export default function App(){
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route exact path='/login'>
            <LoginPage />
          </Route>
          <Route exact path='/register'>
            <LoginPage />
          </Route>

          <Route path='*'>
            <MainPage />
          </Route>
        </Switch>
      </Router>
    </div>
  );
}