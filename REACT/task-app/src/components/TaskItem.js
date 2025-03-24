import React, { useContext } from "react";
import TaskContext from "../contexts/TaskContext";

const TaskItem = ({ task }) => {
  const { toggleComplete, deleteTask } = useContext(TaskContext);

  return (
    <li
      className={`list-group-item d-flex justify-content-between align-items-center ${
        task.completed ? "list-group-item-success" : ""
      }`}
    >
      <span
        style={{
          textDecoration: task.completed ? "line-through" : "none",
          cursor: "pointer",
        }}
        onClick={() => toggleComplete(task.id)}
      >
        {task.text}
      </span>
      <button className="bi bi-trash" onClick={() => deleteTask(task.id)}>
       
      </button>
    </li>
  );
};

export default TaskItem;
