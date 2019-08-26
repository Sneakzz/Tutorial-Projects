// import http module
const http = require('http');

// create server instance
http.createServer((req, res) => {
  // Send the HTTP header
  // HTTP Status: 200 : OK
  // Content Type: text/plain
  res.writeHead(200, { 'Content-Type': 'text/plain' });

  // Send response body as 'Hello World'
  res.end('Hello World\n');
}).listen(8081); // bind server to port 8081

console.log('Server running at http://127.0.0.1:8081');