import React from 'react'
import { Link } from 'react-router-dom'
const Header = () => {
  return (
    <>
    <div className="alert alert-primary">
      <div className="container">
        <h1>Product Catlog App</h1>
      </div>
    </div>
    <div className="container">
      <Link to="/" className="btn btn-link">
      Home
      </Link>
      <Link to="/products" className="btn btn-link">
      Products
      </Link>
      <Link to="/about" className="btn btn-link">
      About Us
      </Link>
      <Link to="/settings" className="btn btn-link">
      Settings
      </Link>
      
      
    </div>
    </>
    
  )
}

export default Header