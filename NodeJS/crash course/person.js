// Module Wrapper Function
// (function (exports, require, module, __filename, __dirname) {

// })

// console.log(__dirname, __filename);

class Person {
  constructor(name, age) {
    this.name = name;
    this.age = age;
  }

  greeting() {
    console.log(`My name is ${this.name} and i am ${this.age}`);
  }
}

// this is how things like classes, objects and other things can be exported to other files
module.exports = Person;