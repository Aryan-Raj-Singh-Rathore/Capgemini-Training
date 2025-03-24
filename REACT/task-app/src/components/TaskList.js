import React, { useContext } from "react";
import TaskContext from "../contexts/TaskContext";
import TaskItem from "./TaskItem";

const TaskList = () => {
  const { tasks } = useContext(TaskContext);

  return (
    <ul className="list-group">
      {tasks.length === 0 ? (
        <li className="list-group-item text-center">No tasks available</li>
      ) : (
        tasks.map((task) => <TaskItem key={task.id} task={task} />)
      )}
    </ul>
  );
};

export default TaskList;
