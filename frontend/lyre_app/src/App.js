import './App.css';
import MainPage from './Pages/MainPage';
import LoginPage from './Pages/LoginPage';
import React, { useEffect, useState } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";
import setupAxios from "./Common/setupAxios";
import { LoginContext } from './Stores/LoginContext';

// Setup default axios config
setupAxios()

export default function App() {
  const [loggedIn, setLoggedIn] = useState(false);
  const [token, setToken] = useState('');

  useEffect(() => {
    setToken(sessionStorage.getItem('token'));
    setLoggedIn(sessionStorage.getItem('loggedIn'))
  }, []);

  return (
    <div className="App">
      <LoginContext.Provider value={
        {
          loggedIn,
          setLoggedIn,
          token,
          setToken
        }}
      >
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
      </LoginContext.Provider>
    </div>
  );
}