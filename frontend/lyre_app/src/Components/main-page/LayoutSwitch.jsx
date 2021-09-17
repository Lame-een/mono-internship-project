import { Route, Switch } from "react-router-dom";

import '../../Assets/CSS/LayoutSwitch.css'

import CategoryLayout from "../../Layouts/CategoryLayout";
import SongLayout from "../../Layouts/SongLayout";
import AlbumLayout from "../../Layouts/AlbumLayout";
import ArtistLayout from "../../Layouts/ArtistLayout";
import HomepageLayout from "../../Layouts/HomepageLayout";

const LayoutSwitch = () => {
    return (
        <div className="layout_switch">
            <div className="layout_switch__component">
                <Switch>
                    <Route exact path="/song">
                        <CategoryLayout baseUrl="./song" table="song" />
                    </Route>
                    <Route path="/song/:id">
                        <SongLayout />
                    </Route>

                    <Route exact path="/album">
                        <CategoryLayout baseUrl="./album" table="album" />
                    </Route>
                    <Route path="/album/:id">
                        <AlbumLayout />
                    </Route>

                    <Route exact path="/artist">
                        <CategoryLayout baseUrl="./artist" table="artist" />
                    </Route>
                    <Route path="/artist/:id">
                        <ArtistLayout />
                    </Route>
                    <Route path="/">
                        <HomepageLayout />
                    </Route>
                </Switch>
            </div>
        </div>
    )
}

export default LayoutSwitch