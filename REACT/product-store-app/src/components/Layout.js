import React from 'react'
import Header from './Header'
import Footer from './Footer'
import { Outlet } from 'react-router-dom'

const Layout = () => {
  return (
    <>
    <Header/>
    <div className="container" style={{minHeight:"500px"}}>
      <Outlet />
    </div>
    <Footer/>
    </>
    
  )
}

export default Layout