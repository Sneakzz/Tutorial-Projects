/* Cookies Management */

const express = require('express');
const cookieParser = require('cookie-parser');

const app = express();
app.use(cookieParser());

app.get('/', (req, res) => {
  console.log('Cookies: ', req.cookies);
  res.send(req.cookies);
});

app.listen(8081);