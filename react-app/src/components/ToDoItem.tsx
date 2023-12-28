import { useEffect, useState } from "react";
import axios from "axios";
import ToDoItemInterface from "../interfaces/ToDoItem";

function ToDoItem() {
  const [todos, setTodos] = useState([]);
  const url = "http://localhost:5294/todos";

  const headers = {
    "Content-Type": "application/json",
    "Access-Control-Allow-Origin": "*", // Add CORS header
  };

  useEffect(() => {
    // Replace with your actual API endpoint
    axios
      .get(url, { headers })
      .then((response) => {
        setTodos(response.data);
      })
      .catch((error) => {
        console.error("There was an error!", error);
      });
  }, []);

  return (
    <div>
      <h1>To Do List!</h1>
      <ul>
        {todos.map((todo: ToDoItemInterface) => (
          <li key={todo.id}>{todo.title}</li>
        ))}
      </ul>
    </div>
  );
}

export default ToDoItem;
