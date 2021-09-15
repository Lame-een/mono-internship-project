import React from 'react';
import LoginLayout from '../Layouts/LoginLayout'
import RegisterLayout from '../Layouts/RegisterLayout'
import {
    Switch,
    Route
} from "react-router-dom";

export default function LoginPage() {
    return (
        <div>
            <h1>THIS IS THE LOGIÍIN PAGÉ</h1>
            <Switch>
                <Route exact path='/login'>
                    <LoginLayout />
                </Route>
                <Route exact path='/register'>
                    <RegisterLayout />
                </Route>
            </Switch>
        </div>
    );
}