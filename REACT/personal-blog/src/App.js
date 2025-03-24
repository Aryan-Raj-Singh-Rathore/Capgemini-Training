import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './components/HomePage';
import PostCreationForm from './components/PostCreationForm';
import PostDetailView from './components/PostDetailView';
import Navigation from './components/Navigation';

function App() {
  return (
    <Router>
      <Navigation />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/create-post" element={<PostCreationForm />} />
        <Route path="/post/:id" element={<PostDetailView />} />
      </Routes>
    </Router>
  );
}

export default App;
