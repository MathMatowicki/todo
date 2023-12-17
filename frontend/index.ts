const server = Bun.serve({
  port: 5294,
  fetch(req) {
    return new Response("test");
  },
});

console.log(`Listening on http://localhost:${server.port} ...`);
