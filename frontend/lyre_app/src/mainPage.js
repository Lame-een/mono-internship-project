import React, { useState, Component } from 'react';
import 
{ 
  NavLink, 
  Nav, 
  ListGroup, 
  ListGroupItem, 
  InputGroup, 
  InputGroupAddon,
  Input, 
  Button,

} from 'reactstrap';

import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";

import logo from './128x128_Lyre_icon.png';

const MainPage = (props) => {
  const [ searchString, setSearchString ] = useState('');
  const [ searchStringBuffer, setBuffer ] = useState('');
  var Img = <img src={logo}/>

  return (
  <div>
  <Router>
  <Nav style={{backgroundColor: '#f1f1f1'}}>

      <ListGroup horizontal>
        <NavLink href="http://localhost:3000">
          {Img}
        </NavLink>
        <ListGroupItem href="/song" tag="a" action>Songs</ListGroupItem> 
        <ListGroupItem href="/album" tag="a" action>Albums</ListGroupItem> 
        <ListGroupItem href="/artist" tag="a" action>Artists</ListGroupItem>
        <ListGroup>
          <ListGroupItem><NavLink href="/singup">Sign Up</NavLink></ListGroupItem>
          <ListGroupItem><NavLink href="/login">Login</NavLink></ListGroupItem>
        </ListGroup>
      </ListGroup>
  </Nav>
  <Switch>
    
    <Route path="/song">
      <Song />
    </Route>
    <Route path="/album">
      <Album />
    </Route>
    <Route path="/artist">
      <Artist />
    </Route>
    <Route path="/login">
      <Login />
    </Route>
    <Route path="/signup">
      <SignUp />
    </Route>
  </Switch>
  <InputGroup>
    <InputGroupAddon addonType="prepend"><Button onClick={() => 
      {
      setSearchString(searchStringBuffer); 
      console.log(searchString)}}>
        Search songs</Button></InputGroupAddon>
    <Input onChange={(e) => {setBuffer(e.target.value)}} />
  </InputGroup>
  </Router>
  </div>
  );
}

function Song() {
  return <h2>Songs</h2>;
}

function Album() {
  return <h2>Albums</h2>;
}

function Artist() {
  return <h2>Artists</h2>;
}

function SignUp() {
  return <h2>Sign Up</h2>;
}

function Login() {
  return <h2>Login</h2>;
}

export default MainPage;
