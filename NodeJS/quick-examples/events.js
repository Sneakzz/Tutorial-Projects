// Import events module
const events = require('events');

// Create an eventEmitter object
const eventEmitter = new events.EventEmitter();

// create an event handler
const connectHandler = () => {
  console.log('connection succesful.');

  // Fire the data_received event
  eventEmitter.emit('data_received');
}

// Bind the connection event with the handler
eventEmitter.on('connection', connectHandler);

// Bind the data_received event with the anonymous function
eventEmitter.on('data_received', () => {
  console.log('data received succesfully.');
});

// Fire the connection event
eventEmitter.emit('connection');

console.log('Program Finished');