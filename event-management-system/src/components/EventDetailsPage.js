// src/EventDetails.js
import React, { useState } from 'react';
import { useParams } from 'react-router-dom';
import { Button, Modal, Container } from 'react-bootstrap';
import { useEventContext } from '../context/EventContext';

const EventDetails = () => {
  const { id } = useParams();
  const { events } = useEventContext();
  const [showModal, setShowModal] = useState(false);

  // Find the event by ID
  const event = events.find(event => event.id === parseInt(id));

  if (!event) {
    return <div>Event not found!</div>;
  }

  const handleShowModal = () => setShowModal(true);
  const handleCloseModal = () => setShowModal(false);

  return (
    <Container className="mt-5">
      <h1>{event.title}</h1>
      <p>{event.description}</p>
      <p><strong>Date:</strong> {event.date}</p>
      <Button variant="primary" onClick={handleShowModal}>Register for Event</Button>

      {/* Modal for registration */}
      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Event Registration</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p>Register for {event.title}?</p>
          <form>
            <div className="mb-3">
              <label htmlFor="name" className="form-label">Your Name</label>
              <input type="text" className="form-control" id="name" placeholder="Enter your name" />
            </div>
            <div className="mb-3">
              <label htmlFor="email" className="form-label">Your Email</label>
              <input type="email" className="form-control" id="email" placeholder="Enter your email" />
            </div>
            <Button variant="primary" type="submit">Submit</Button>
          </form>
        </Modal.Body>
      </Modal>
    </Container>
  );
};

export default EventDetails;
