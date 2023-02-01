
import { Fragment } from 'react';
import { BrowserRouter, NavLink, Route, Switch } from 'react-router-dom';
import { Menu, MenuItem } from 'semantic-ui-react';
import './App.css';
import Accueil from './composants/Accueil';
import Recherche from './composants/Recherche';
import Film from './composants/Film';
import Page404 from './composants/Page404';

function App() {
  return (


<Fragment>
  <BrowserRouter>
    <h1>APP Films</h1>
        <Menu >
            <MenuItem as={NavLink} activeStyle={{color: "red", fontWeight: "bold" }} to="/" exact> Accueil</MenuItem>
            <MenuItem as={NavLink} activeStyle={{ color: "red", fontWeight: "bold" }} to="/recherche">Recherche Films</MenuItem>
        </Menu>

        <Switch>
            <Route path="/" component={Accueil} exact />
            <Route path="/recherche" component={Recherche} />
            <Route path="/film/:abc" component={Film} />            
            <Route path="*" component={Page404} />
        </Switch>
  </BrowserRouter>
</Fragment>
  
  );
}

export default App;


