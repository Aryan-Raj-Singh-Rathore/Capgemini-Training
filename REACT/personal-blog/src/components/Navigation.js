import React from 'react';
import { Link } from 'react-router-dom';

function Navigation() {
  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-primary">
      <div className="container d-flex justify-content-between w-100">
        
        <Link className="navbar-brand" to="/">
          <h2 className="text-white">My Personal Blog</h2>
        </Link>

        
        <div className="navbar-nav">
          <li className="nav-item">
            <Link to="/" className="nav-link active">
              Home
            </Link>
          </li>
          <li className="nav-item">
            <Link to="/create-post" className="nav-link">
              Create Post
            </Link>
          </li>
        </div>
      </div>
    </nav>
  );
}

export default Navigation;
