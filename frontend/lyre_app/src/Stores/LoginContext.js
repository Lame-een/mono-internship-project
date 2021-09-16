import React from 'react';
export var LoginContext = React.createContext(
    {
        loggedIn: false,
        setLoggedIn: (loginValue) => { },
        token: "",
        setToken: (newToken) => { },
    }
);