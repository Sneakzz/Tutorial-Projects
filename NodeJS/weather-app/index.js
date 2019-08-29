// Node module called request, simplifies the code needed to make an http request.
const request = require('request');
// set up yargs, allows for setting up variables from the command line
const argv = require('yargs').argv;

let apiKey = '27783d2cd441a3de408803ff6ceccd2d';
let city = argv.c || 'Brugge';
let url = `http://api.openweathermap.org/data/2.5/weather?q=${city}&units=metric&appid=${apiKey}`;

request(url, (err, res, body) => {
  if (err) {
    console.log('error: ', err);
  } else {
    let weather = JSON.parse(body);
    let message = `It's ${weather.main.temp} degrees in ${weather.name}!`;
    console.log(message);
  }
});
