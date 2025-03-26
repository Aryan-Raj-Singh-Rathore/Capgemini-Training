import Header from "./components/Header";
import Footer from "./components/Footer";
import TodoList from "./components/TodoList";
import TodoForm from "./components/TodoForm";

const App = ({ org, year, title, subtitle }) => {
  return (
    <>
      <Header title={title} subtitle={subtitle} />
      <div className="container" style={{ minHeight: "500px" }}>
        <div className="row">
          <div className="col-md-4 col-sm-6 col-xs-12">
            <TodoList />
          </div>
          <div className="col-md-4 col-sm-6 col-xs-12">
            <TodoForm />
          </div>
        </div>
      </div>
      <Footer year={year || 2024} org={org || "KVinod Inc. Bangalore"} />
    </>
  );
};

export default App;
