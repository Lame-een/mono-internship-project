import '../../Assets/CSS/Navbar.css'
import Logo from '../../Assets/Img/lyre_logo.svg';
import { Link, useHistory } from "react-router-dom";
import { LoginContext } from '../../Stores/LoginContext';
import { useContext, useState } from 'react';
import { Button } from 'reactstrap';
import { useEffect } from 'react/cjs/react.development';

export default function Navbar() {
    const context = useContext(LoginContext);
    const [loginButtons, setLoginButtons] = useState(<div></div>);
    const history = useHistory();

    function handleLogout() {
        context.setLoggedIn(false);
        context.setToken('');
        
        sessionStorage.setItem('loggedIn', false);
        sessionStorage.setItem('token', '');
        history.push('/');
    }

    useEffect(() => {
        if (!context.loggedIn) {
            setLoginButtons(
                <div className="navbar__buttons">
                    <Link className="navbar__button" to="/login">Sign in</Link>
                    <Link className="navbar__button" to="/register">Sign up</Link>
                </div>
            )
        } else {
            setLoginButtons(
                <div className="navbar__buttons">
                    You're logged in.
                    <Button className="navbar__button" onClick={handleLogout}>Sign Out</Button>
                </div>
            );
        }
    }, [context]);


    return (
        <div className="navbar">
            <Link to="/" className="navbar__logo">
                <img src={Logo} alt="Lyre logo" />
            </Link>
            <div className="navbar__items">
                <Link className="navbar__item" to="/song">Songs</Link>
                <Link className="navbar__item" to="/album">Albums</Link>
                <Link className="navbar__item" to="/artist">Artists</Link>
            </div>
            {loginButtons}
        </div>
    )
}