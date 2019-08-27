const url = require('url');
const fs = require('fs');
const http = require('http');

http.createServer( (req, res) => {
  const pathname = "." + url.parse(req.url).pathname;

  fs.readFile(pathname, (err, data) => {
    if (err) {
      res.writeHead(404, {'Content-Type':'text/html'});
    } else {
      res.writeHead(200, {'Content-Type':'text/html'});
      res.write(data.toString());
    }

    res.end();
  });
}).listen(8081);

/* Creating a Web Client using Node */

// Options to be used by request
const options = {
  host: 'localhost',
  port: '8081',
  path: '/index.html'
};

// Callback function is used to deal with response
const callback = response => {
  // Continuously update stream with data
  let body = '';
  response.on('data', data => {
    body += data;
  });

  response.on('end', () => {
    // Data received completely.
    console.log(body);
  });
}

// Make a request to the server
const req = http.request(options, callback);
req.end();