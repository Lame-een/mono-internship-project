import './App.css';
import MainPage from './MainPage';
import React, { Component } from 'react';
import { Button, ButtonGroup, Form, Label, FormGroup, Input, InputGroup, InputGroupAddon } from 'reactstrap';
import {
  Switch,
  Route,
  useHistory,
  Redirect
} from "react-router-dom";
import CategoryLayout from './Layouts/CategoryLayout';

const App = () => {
  return (
    <div className="App">
      <MainPage /> 

      <Switch>
        <Route path="/song/:page">
          <h1>SONG</h1>
          <CategoryLayout baseUrl="./song" table="song" />
        </Route>

        <Route path="/album/:page">
          <h1>ALBUM</h1>
          <CategoryLayout baseUrl="./album" table="album" />
        </Route>

        <Route path="/artist/:page">
          <h1>ARTIST</h1>
          <CategoryLayout baseUrl="./album" table="album" />
        </Route>
      </Switch>
    </div>
  );
}

export default App;
