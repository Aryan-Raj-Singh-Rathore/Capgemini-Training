import React, { useState } from "react";
import Swal from "sweetalert2";
import { ToastContainer, toast } from "react-toastify";

const initialState = [
  { id: 1, text: "Learn React", completed: false },
  { id: 2, text: "Attend global connect (cg)", completed: true },
  { id: 3, text: "Finish day 1 assignment", completed: true },
  { id: 4, text: "Take rest", completed: false },
];
function TodoList() {
  const [tasks, setTasks] = useState(initialState);
  const [hideCompletedTasks, setHideCompletedTasks] = useState(false);          
  const SortedTasks=[...tasks].sort((a,b)=>a.text.localeCompare(b.text));

  const deleteAllTasks = () => {
    Swal.fire({
      title: "Are you sure to delete all tasks?",
      showDenyButton: true,
      confirmButtonText: "Yes",
      denyButtonText: "No",
    }).then((result) => {
      if (result.isConfirmed) {
        setTasks([]);
        toast.success("All tasks deleted!");
      }
    });
    
  };

  const deleteCompletedTasks = () => {
    Swal.fire({
      title: "Are you sure to delete completed tasks?",
      showDenyButton: true,
      confirmButtonText: "Yes",
      denyButtonText: "No",
    }).then((result) => {
      if (result.isConfirmed) {
        setTasks([...tasks.filter((t) => !t.completed)]);
        toast.success("Completed tasks deleted!");
      }
    });
  };

  const deleteTask = (id) => {
    // if (!window.confirm("Are you sure you want to delete this task?")) return;

    // const input = window.prompt("Type DELETE to remove this task");
    // if (input !== "DELETE") return;

    Swal.fire({
      title: "Are you sure to delete this task?",
      showDenyButton: true,
      confirmButtonText: "Yes",
      denyButtonText: "No",
    }).then((result) => {
      if (result.isConfirmed) {
        const remainingTasks = tasks.filter((t) => t.id !== id);
        setTasks([...remainingTasks]);
        toast.success("Task deleted!");
      }
    });
  };

  const toggleTaskStatus = (id) => {
    const tempTasks = [...tasks];
    const index = tempTasks.findIndex((t) => t.id === id);
    if (index === -1) return;

    tempTasks[index].completed = !tempTasks[index].completed;
    setTasks([...tempTasks]);
  };

  const completedCount = () => tasks.filter((t) => t.completed).length;

  return (
    <>
      {tasks.length > 0 ? (
        <h3>Here are the tasks:</h3>
      ) : (
        <h3>You don't have any tasks!</h3>
      )}

      <div>
        {tasks.length === 0 || (
          <button
            onClick={deleteAllTasks}
            className="btn btn-link"
            style={{ paddingLeft: "0" }}
          >
            Delete all tasks
          </button>
        )}

        {completedCount() > 0 && (
          <button onClick={deleteCompletedTasks} className="btn btn-link">
            Delete completed tasks ({completedCount()})
          </button>
        )}
      </div>

      <div> 
        {completedCount() > 0 && (<input
          type="checkbox"
          id="hideCompletedTasksCheckbox"
          value={hideCompletedTasks}
          checked={hideCompletedTasks}
          onChange={() => setHideCompletedTasks(!hideCompletedTasks)}
        />)}

        {completedCount() > 0 && (<label
          htmlFor="hideCompletedTasksCheckbox"
          style={{ cursor: "pointer" }}
          className="form-label ms-2"
        >
          Hide completed tasks ({completedCount()})
        </label>)}
      </div>
      <ul className="list-group">
        {SortedTasks.map((t) => {
          if (hideCompletedTasks && t.completed) return;

          return (
            <li
              style={{ cursor: "pointer" }}
              className="list-group-item"
              key={t.id}
            >
              <span onClick={() => toggleTaskStatus(t.id)}>
                {t.completed ? <del>{t.text}</del> : <span>{t.text}</span>}
              </span>

              <button
                onClick={() => deleteTask(t.id)}
                className="btn btn-link float-end text-danger"
              >
                <i className="bi bi-trash"></i>
              </button>
            </li>
          );
        })}
      </ul>
      <ToastContainer />
    </>
  );
}

export default TodoList;
