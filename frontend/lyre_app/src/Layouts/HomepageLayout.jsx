import React, { useState } from 'react';
import { useHistory } from 'react-router';
import { Form } from 'reactstrap';
import '../Assets/CSS/HomepageLayout.css'
import Logo from '../Assets/Img/lyre_logo.svg';

const HomepageLayout = () => {
    const history = useHistory();

    function submitInput(e) {
        e.preventDefault();
        history.push('/song?q=' + e.target[0].value);
    }

    return (
        <div className="homepage">
            <img src={Logo} alt="" className="homepage__logo" />
            <Form className="homepage__search__form" onSubmit={submitInput}>
                <input
                    type="text"
                    className="homepage__search"
                    placeholder="Search"
                />
                <button
                    className="homepage__search_button"
                    type="submit"
                >
                    Search
                </button>
            </Form>
        </div>
    )
}

export default HomepageLayout