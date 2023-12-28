import React, { useEffect, useState } from "react";
import axios from "axios";
import ToDoItem from "../interfaces/ToDoItem";

function ToDoItem() {
  const [todos, setTodos] = useState([]);
  const url = "http://localhost:5294/api/todos";

  useEffect(() => {
    // Replace with your actual API endpoint
    axios
      .get(url)
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
        {todos.map((todo: ToDoItem) => (
          <li key={todo.id}>{todo.name}</li>
        ))}
      </ul>
    </div>
  );
}

export default ToDoItem;
