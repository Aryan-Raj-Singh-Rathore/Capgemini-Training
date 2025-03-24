import React, { useState } from 'react';
import axios from 'axios';

const RegistrationPage = ({ match }) => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const eventId = match.params.id;

  const handleSubmit = (e) => {
    e.preventDefault();

    const registration = { name, email, eventId, registrationDate: new Date() };

    axios.post('https://localhost:5001/api/registrations', registration)
      .then(response => {
        alert('Registration successful!');
      })
      .catch(error => console.error(error));
  };

  return (
    <div>
      <h2>Register for Event</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Your Name"
          required
        />
        <input
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          placeholder="Your Email"
          required
        />
        <button type="submit">Register</button>
      </form>
    </div>
  );
};

export default RegistrationPage;
