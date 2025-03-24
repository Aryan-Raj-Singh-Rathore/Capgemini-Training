import React from 'react';
import { BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

import Home from './components/HomePage';
import EventDetails from './components/EventDetailsPage';
import CreateEvent from './components/CreateEditEventPage';
import RegisterEvent from './components/RegistrationPage';

function App() {
  return (
    <Router>
      <div className="container">
        <h1>Event Management System</h1>
        <Routes>
          <Route path="/" exact component={Home} />
          <Route path="/event/:id" component={EventDetails} />
          <Route path="/create" component={CreateEvent} />
          <Route path="/register/:id" component={RegisterEvent} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
