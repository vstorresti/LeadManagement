import React from 'react';
import { BrowserRouter as Router, Routes, Route, NavLink } from 'react-router-dom';
import Invited from './pages/Invited';
import Accepted from './pages/Accepted';
import CreateLead from './pages/CreateLead';
import './App.css';

function App() {
  return (
    <Router>
      <nav>
        <NavLink to="/" className={({ isActive }) => isActive ? 'active' : ''}>Invited</NavLink>
        <NavLink to="/accepted" className={({ isActive }) => isActive ? 'active' : ''}>Accepted</NavLink>
        <NavLink to="/create" className={({ isActive }) => isActive ? 'active' : ''}>Create Lead</NavLink>
      </nav>
      <Routes>
        <Route path="/" element={<Invited />} />
        <Route path="/accepted" element={<Accepted />} />
        <Route path="/create" element={<CreateLead />} />
      </Routes>
    </Router>
  );
}

export default App;
