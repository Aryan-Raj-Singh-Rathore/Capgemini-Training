import React, { useState, useContext } from "react";
import TaskContext from "../contexts/TaskContext";

const TaskForm = () => {
  const { addTask } = useContext(TaskContext);
  const [task, setTask] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!task.trim()) return;
    addTask({ id: Date.now(), text: task, completed: false });
    setTask("");
  };

  return (
    <form onSubmit={handleSubmit} className="mb-3">
      <input
        type="text"
        className="form-control"
        placeholder="New task..."
        value={task}
        onChange={(e) => setTask(e.target.value)}
      />
      <button className="btn btn-success mt-2" type="submit">
        Add Task
      </button>
    </form>
  );
};

export default TaskForm;
