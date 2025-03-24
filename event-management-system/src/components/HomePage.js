import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import { useEventContext } from '../context/EventContext';

const Home = () => {
  const { events, fetchEvents, loading } = useEventContext();

  useEffect(() => {
    fetchEvents();
  }, [fetchEvents]);

  if (loading) return <p>Loading...</p>;

  return (
    <div>
      <h2>Events</h2>
      <ul className="list-group">
        {events.map(event => (
          <li key={event.id} className="list-group-item">
            <Link to={`/event/${event.id}`}>{event.title}</Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Home;
