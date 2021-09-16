import {Route, Switch} from "react-router-dom";

import '../../Assets/CSS/LayoutSwitch.css'

import CategoryLayout from "../../Layouts/CategoryLayout";
import SongLayout from "../../Layouts/SongLayout";
import AlbumLayout from "../../Layouts/AlbumLayout";
import HomepageLayout from "../../Layouts/HomepageLayout";

const LayoutSwitch = () => {
    return (
        <div className="layout_switch">
            <Switch className="layout_switch">
                <Route exact path="/song">
                    <CategoryLayout baseUrl="./song" table="song" />
                </Route>
                <Route path="/album/:id">
                    <AlbumLayout />
                </Route>
                <Route path="/song/:id">
                    <SongLayout />
                </Route>

                <Route exact path="/album">
                    <CategoryLayout baseUrl="./album" table="album" />
                </Route>

                <Route exact path="/artist">
                    <CategoryLayout baseUrl="./artist" table="artist" />
                </Route>
                <Route path="/">
                    <HomepageLayout />
                </Route>
            </Switch>
        </div>
    )
}

export default LayoutSwitch