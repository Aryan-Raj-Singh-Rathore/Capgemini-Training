import React, { useState } from 'react';
import axios from 'axios';

const CreateEvent = () => {
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  const [date, setDate] = useState('');
  const [location, setLocation] = useState('');
  const [maxAttendees, setMaxAttendees] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();

    const event = {
      title,
      description,
      date,
      location,
      maxAttendees,
    };

    try {
      await axios.post('http://localhost:5000/api/events', event);
      alert('Event created successfully!');
    } catch (error) {
      console.error('Error creating event:', error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input type="text" value={title} onChange={(e) => setTitle(e.target.value)} placeholder="Event Title" />
      <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Event Description" />
      <input type="date" value={date} onChange={(e) => setDate(e.target.value)} />
      <input type="text" value={location} onChange={(e) => setLocation(e.target.value)} placeholder="Event Location" />
      <input type="number" value={maxAttendees} onChange={(e) => setMaxAttendees(e.target.value)} placeholder="Max Attendees" />
      <button type="submit">Create Event</button>
    </form>
  );
};

export default CreateEvent;
