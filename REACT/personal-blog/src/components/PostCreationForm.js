import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

function PostCreationForm() {
  const [title, setTitle] = useState('');
  const [content, setContent] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!title || !content) {
      setError('Title and content are required');
      return;
    }

    const newPost = {
      id: Date.now(),
      title,
      content,
    };

    const storedPosts = JSON.parse(localStorage.getItem('posts')) || [];
    storedPosts.push(newPost);
    localStorage.setItem('posts', JSON.stringify(storedPosts));

    setTitle('');
    setContent('');
    setError('');
    navigate('/');
  };

  return (
    <div className="container mt-4">
      <h1>Create a New Post</h1>
      <form onSubmit={handleSubmit} className="mt-3">
        <div className="form-group">
          <label htmlFor="title">Title</label>
          <input
            type="text"
            id="title"
            className="form-control"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="content">Content</label>
          <textarea
            id="content"
            className="form-control"
            rows="4"
            value={content}
            onChange={(e) => setContent(e.target.value)}
            required
          ></textarea>
        </div>
        {error && <div className="alert alert-danger mt-2">{error}</div>}
        <button type="submit" className="btn btn-primary mt-3">Create Post</button>
      </form>
    </div>
  );
}

export default PostCreationForm;
