import { Between, Grid, Icon, Line, Row } from 'UIKit';
import { Route, Routes, NavLink } from "react-router-dom";

import { Home } from "Views/Home";
import { About } from "Views/About";
import { States } from "Views/States";

import './App.css';

const App = (props) => {
  return (
    <>
      <Grid>
        <div>
          <Between>
            <Line>
              <Icon i="menu" />
              <h3>Bar's Website</h3>
            </Line>
            <Line>
              <NavLink to='/home'>Home</NavLink>
              <NavLink to='/about'>About</NavLink>
              <NavLink to='/states'>States</NavLink>
            </Line>
          </Between>
        </div>
        <div>
          <Row>
            <Routes>
              <Route path="/home" element={<Home />} />
              <Route path="/about" element={<About />} />
              <Route path="/states" element={<States />} />
            </Routes>
          </Row>
        </div>
        <div>
          <Line>
            <h3>Sela Group</h3>
          </Line>
        </div>
      </Grid>
    </>
  )
}

export default App;