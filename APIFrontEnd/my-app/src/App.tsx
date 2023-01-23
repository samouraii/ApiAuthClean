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
import ListPersonne from './Pages/Personne/ListPersonne';




function App() {
  return (
    <div className="App">
     <Nav ></Nav>
    <Routes>
      <Route path="/" element={<Accueil />} />
      <Route path="about" element={<ListPersonne />} />
      <Route path="/auth/*" element={<AuthRouter/>} />
      <Route path="/admin/*" element={
      <AuthGard roles = {['Admin','coco']}>
        <AdminRouter/>
      </AuthGard>
      } />
    </Routes>
  </div>
  );
}



export default App;
