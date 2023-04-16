import React from 'react';
import logo from './logo.svg';
import { Routes, Route, Link } from "react-router-dom";
import './App.css';
import AuthRouter from './Pages/Auth/AuthRouter';
import AdminRouter from './Pages/Admin/AdminRouter';
import AuthGard from './_helper/AuthGard';
import Accueil from './Pages/Accueil';

import Nav from './Pages/Nav';
import "./Pages/Nav.css"
import ListPersonne2 from './Pages/Personne/ListPersonne2';




function App() {
  return (
    <div className="App">
     <Nav ></Nav>
    <Routes>
      <Route path="/" element={<Accueil />} />
      <Route path="about" element={<ListPersonne2 />} />
      <Route path="/auth/*" element={<AuthRouter/>} />
      <Route path="/admin/*" element={
      <AuthGard roles = {['Admin', 'GestionCaisse']}>
        <AdminRouter/>
      </AuthGard>
      } />
    </Routes>

    <footer>
         <div className="container">
            <div className="row">
               <div className="col-sm-6">
                   <p>Copyright &copy; 2019 <a href="templatshub.net">Templates Hub</a>.</p>
               </div>
               <div className="col-sm-6">
                  <ul className="footer-list">
                     <li><a href="#">Merchant</a></li>
                     <li><a href="#">Dashboard</a></li>
                     <li><a href="#">Home</a></li>
                  </ul>
                  
               </div>
              
            </div>
            
         </div>
         
      </footer>
  </div>
  
  );
}



export default App;
