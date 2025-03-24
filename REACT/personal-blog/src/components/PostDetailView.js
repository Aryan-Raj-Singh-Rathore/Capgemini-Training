import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

function PostDetailView() {
  const { id } = useParams();
  const [post, setPost] = useState(null);

  useEffect(() => {
    const storedPosts = JSON.parse(localStorage.getItem('posts')) || [];
    const postDetail = storedPosts.find((post) => post.id.toString() === id);
    setPost(postDetail);
  }, [id]);

  if (!post) {
    return <div className="container mt-4"><p>Post not found.</p></div>;
  }

  return (
    <div className="container mt-4">
      <div className="card">
        <div className="card-body">
          <h1 className="card-title">{post.title}</h1>
          <p className="card-text">{post.content}</p>
        </div>
      </div>
    </div>
  );
}

export default PostDetailView;
