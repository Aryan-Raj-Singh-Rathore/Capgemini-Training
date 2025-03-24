import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

function HomePage() {
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    const storedPosts = JSON.parse(localStorage.getItem('posts')) || [];
    setPosts(storedPosts);
  }, []);

  const handleDelete = (postId) => {
    const updatedPosts = posts.filter(post => post.id !== postId);

    setPosts(updatedPosts);

    localStorage.setItem('posts', JSON.stringify(updatedPosts));
  };

  return (
    <div className="container mt-4">
      <h1>Blog Posts</h1>
      {posts.length === 0 ? (
        <p>No posts available.</p>
      ) : (
        <ul className="list-group">
          {posts.map((post) => (
            <li key={post.id} className="list-group-item position-relative">
              <Link to={`/post/${post.id}`} className="h5">
                {post.title}
              </Link>

              <i
                onClick={() => handleDelete(post.id)}
                className="bi bi-trash position-absolute end-0 top-0 fs-5 text-danger cursor-pointer"
                style={{ marginTop: '10px', marginRight: '10px' }}
              ></i>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default HomePage;
