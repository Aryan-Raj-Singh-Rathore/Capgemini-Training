import { useDispatch, useSelector } from "react-redux";
import TodoItem from "./TodoItem";
import Swal from "sweetalert2";
import { toast } from "react-toastify";
import { useState } from "react";

function TodoList() {
  // by doing the following, we are making this component, subscribed to
  // the store; any change of state in the redux store, will make this
  // component rerender itself
  const { tasks } = useSelector((state) => state.todoReducer);
  const dispatch = useDispatch();
  const [hideCompleted, setHideCompleted] = useState(false);
  const completedCount = () => tasks.filter((t) => t.completed).length;
  const [toggleStatus, setToggleStatus] = useState(false);


  const deleteAllTasks = () => {
    Swal.fire({
      title: "Are you sure to delete all tasks?",
      showDenyButton: true,
      confirmButtonText: "Yes",
      denyButtonText: "No",
    }).then((result) => {
      if (result.isConfirmed) {
        dispatch({ type: "DELETE_ALL_TASKS" });
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
        dispatch({ type: "DELETE_COMPLETED_TASKS" });
        toast.success("Completed tasks deleted!");
      }
    });
  };
  const toggleHideCompleted = () => {
    setHideCompleted(!hideCompleted); // Toggle the state
  };

  const toggleTasksStatus=(id) => {
    dispatch({
    type: "TOGGLE_TASK_STATUS",
    payload: id, // `taskId` is the ID of the task you want to toggle
});
   
  }


  

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
            Delete completed tasks ({(completedCount())})
          </button>
        )}
      </div>

      {completedCount() > 0 && (
        <div>
          <input
            type="checkbox"
            id="hideCompletedTasksCheckbox"
            
            checked={hideCompleted}
            onChange={() => {toggleHideCompleted()}}
          />
          <label
            htmlFor="hideCompletedTasksCheckbox"
            style={{ cursor: "pointer" }}
            className="form-label ms-2"
          >
            Hide completed tasks ({completedCount()})
          </label>
        </div>
      )}
      <ul className="list-group">
        
        {tasks
          .filter((tasks) => !(hideCompleted && tasks.completed)) // Filter out completed tasks if checkbox is checked
          .map((tasks) => (
            <li key={tasks.id} className="list-group-item">
              <span onClick={() => toggleTasksStatus(tasks.id)}>
                {tasks.completed ? (
                  <del>{tasks.text}</del>
                ) : (
                  <span>{tasks.text}</span>
                )}
              </span>
            </li>
          ))}
      </ul>
      
    </>
  );
}

export default TodoList;
