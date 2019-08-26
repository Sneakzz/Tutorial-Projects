const events = require('events');
const eventEmitter = new events.EventEmitter();

// Listener 1
const listener1 = () => {
  console.log('listener1 executed.');
}

// Listener 2
const listener2 = () => {
  console.log('listener2 executed');
}

// Bind the connection event with the listener1 function
eventEmitter.addListener('connection', listener1);

// Bind the connection event with the listener2 function
eventEmitter.on('connection', listener2);

let eventListeners = require('events').EventEmitter.listenerCount(eventEmitter, 'connection');
console.log(eventListeners + " Listener(s) listening to connection event");

// Fire the connection event
eventEmitter.emit('connection');

// Remove the binding of listener1 function
eventEmitter.removeListener('connection', listener1);
console.log("Listener1 will not listen now.");

// Fire the connection event
eventEmitter.emit('connection');

eventListeners = require('events').EventEmitter.listenerCount(eventEmitter, 'connection');
console.log(eventListeners + " Listener(s) listening to connection event.");

console.log("Program Finished.");