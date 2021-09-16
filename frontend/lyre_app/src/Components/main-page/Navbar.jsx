import '../../Assets/CSS/Navbar.css'
import Logo from '../../res/lyre_logo.svg';
import { Link } from "react-router-dom";

const Navbar = () => {
    return (
        <div className="navbar">
            <Link to="/" className="navbar__logo">
                <img src={Logo} alt="Lyre logo" />
            </Link>
            <div className="navbar__items">
                <Link to="/song">Songs</Link>
                <Link to="/album">Albums</Link>
                <Link to="/artist">Artists</Link>
            </div>
            <div className="navbar__buttons">
                <button>Sign in</button>
                <button>Sign up</button>
            </div>
        </div>
    )
}

export default Navbar