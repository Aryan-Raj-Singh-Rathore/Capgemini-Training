import React from "react";
import { ThemeProvider } from "./contexts/ThemeContext";
import { TaskProvider } from "./contexts/TaskContext";
import TaskList from "./components/TaskList";
import TaskForm from "./components/TaskForm";
import ThemeSwitcher from "./components/ThemeSwitcher";

function App() {
  return (
    <ThemeProvider>
      <TaskProvider>
        <div
          className="container mt-4 p-4 rounded shadow"
          style={{
            maxWidth: "600px",
            backgroundColor: "var(--bg-color)",
            color: "var(--text-color)",
          }}
        >
          <h1 className="text-center">Task Management App</h1>
          <ThemeSwitcher />
          <TaskForm />
          <TaskList />
        </div>
      </TaskProvider>
    </ThemeProvider>
  );
}

export default App;
