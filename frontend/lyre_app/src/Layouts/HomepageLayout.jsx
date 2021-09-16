import React, { useState } from 'react';
import { useHistory } from 'react-router';
import '../Assets/CSS/HomepageLayout.css'

const HomepageLayout = () => {
    const history = useHistory();
    const [searchString, setSearchString] = useState('');

    function submitInput(e) {
        e.preventDefault();
        history.push('/song?q=' + searchString);
        console.log(searchString);
    }

    return (
        <div className="homepage">
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