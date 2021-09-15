import React, { useState } from 'react';
import CategoryLayout from '../Layouts/CategoryLayout';
import logo from '../res/128x128_Lyre_icon.png';
import {
  NavLink,
  Nav,
  ListGroup,
  ListGroupItem,
  InputGroup,
  InputGroupAddon,
  Input,
  Button,
  Form
} from 'reactstrap';

import {
  Switch,
  Route
} from "react-router-dom";


const MainPage = (props) => {
  const [searchString, setSearchString] = useState('');
  const [searchStringBuffer, setBuffer] = useState('');
  var Img = <img src={logo} alt="logo" />

  function submitInput(e) {
    e.preventDefault();
    setSearchString(searchStringBuffer);
    console.log("searchString", searchString)
    console.log("searchStringBuffer", searchStringBuffer)
  }

  return (
    <div>
      <Nav style={{ backgroundColor: '#f1f1f1' }}>

        <ListGroup horizontal>
          <NavLink href="/">
            {Img}
            <h1>Lyre</h1>
          </NavLink>
          <ListGroupItem href="/song" tag="a" action>Songs</ListGroupItem>
          <ListGroupItem href="/album" tag="a" action>Albums</ListGroupItem>
          <ListGroupItem href="/artist" tag="a" action>Artists</ListGroupItem>
          <ListGroup>
            <ListGroupItem><NavLink href="/register">Sign Up</NavLink></ListGroupItem>
            <ListGroupItem><NavLink href="/login">Login</NavLink></ListGroupItem>
          </ListGroup>
        </ListGroup>
      </Nav>

      <Switch>

        <Route exact path="/song">
          <CategoryLayout baseUrl="./song" table="song" />
        </Route>
        <Route path="/song/:id">
          THIS IS A SONG ROUTE
        </Route>

        <Route exact path="/album">
          <CategoryLayout baseUrl="./album" table="album" />
        </Route>

        <Route exact path="/artist">
          <CategoryLayout baseUrl="./artist" table="artist" />
        </Route>
        <Route path="/">

          <Form onSubmit={submitInput}>
            <InputGroup>
              <InputGroupAddon addonType="prepend"><Button onClick={submitInput}>
                Search songs</Button></InputGroupAddon>
              <Input onChange={(e) => { setBuffer(e.target.value) }} />
            </InputGroup>
          </Form>

        </Route>
      </Switch>
    </div>
  );
}

export default MainPage;
