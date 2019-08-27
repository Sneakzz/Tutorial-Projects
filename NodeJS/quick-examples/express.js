/* File Upload */

const express = require('express');
const app = express();
const fs = require('fs');

const bodyParser = require('body-parser');
const multer = require('multer');

app.use(express.static('public'));
app.use(bodyParser.urlencoded({extended: false}));
app.use(multer({dest: './tmp/'}).single('file'));

app.get('/index.html', (req, res) => {
  res.sendFile(__dirname + '/' + 'index.html');
});

app.post('/file_upload', (req, res) => {
  console.log(req.file.originalname);
  console.log(req.file.path);
  console.log(req.file.mimetype);
  console.log(req.file.encoding);
  const file = __dirname + '/' + req.file.originalname;
  console.log(file);

  fs.readFile(req.file.path, (err, data) => {
    fs.writeFile(file, data, err => {
      if (err) {
        console.log(err);
      } else {
        response = {
          message: 'File uploaded successfully',
          filename: req.file.originalname
        };
      }
      
      console.log(response);
      res.end(JSON.stringify(response));
    });
  });
});

const server = app.listen(8081, () => {
  const host = server.address().address;
  const port = server.address().port;

  console.log(`Example app listening at http://${host}:${port}`);
});