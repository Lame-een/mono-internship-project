import React, { useState } from 'react';
import { useHistory } from 'react-router';
import '../Assets/CSS/HomepageLayout.css'
import Logo from '../Assets/Img/lyre_logo.svg';

const HomepageLayout = () => {
    const history = useHistory();
    const [searchString, setSearchString] = useState('');

    function submitInput(e) {
        e.preventDefault();
        history.push('/song?q=' + searchString);
    }

    return (
        <div className="homepage">
            <img src={Logo} alt="" className="homepage__logo"/>
            <input
                type="text"
                className="homepage__search"
                placeholder="Search"
                onChange={(e) => { setSearchString(e.target.value) }}
            />
            <button
                className="homepage__search_button"
                onClick={submitInput}
            >
                Search
            </button>
        </div>
    )
}

export default HomepageLayout