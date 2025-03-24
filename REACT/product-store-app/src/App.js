import React from 'react'
import { BrowserRouter, Route,Routes } from 'react-router-dom';
import Layout from "./components/Layout";
import ProductCatlog from './components/ProductCatlog';
import About from './components/About';
import Login from './components/Login';
import Register from './components/Register';
import Settings from './components/Settings';

function App() {
  return <BrowserRouter>
    <Routes>
      <Route path="/" element={<Layout/>}>
      <Route path='products' element={<ProductCatlog/>}/>
      <Route path='about' element={<About/>}/>
      <Route path='settings' element={<Settings/>}>
      <Route path='login' element={<Login/>}/>
      <Route path='register' element={<Register/>}/>
      </Route>
    </Route>
    <Route
      path=""
      element={
        <div>
          <h3 className="text-warning"> OOPS!</h3>
          <p className="lead">
            the page you are trying to access is invalid.
          </p>
        </div>
      }
      />
    
    </Routes>
  </BrowserRouter>
   
  
}

export default App;
