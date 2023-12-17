import ToDoItem from "./interfaces/ToDoItem";
import { ToDoList } from "./interfaces/ToDoList";
let url = "http://localhost:5294/";

Bun.serve({
  error(error: Error) {
    return new Response(
      `Something went wrong: ${(error.toString(), { status: 500 })}`
    );
  },
  fetch(req) {
    if (!url) throw new Error("url is not defined");

    const items: ToDoItem[] = [];
    const html = items.map((item: any) => `<li>${item}</li>`).join("");

    return new Response(`<ul>${html}</ul>`);
  },
});
