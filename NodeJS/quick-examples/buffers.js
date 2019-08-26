/* Creating Buffers */

// Uninitiated Buffer of 10 octets
const buf1 = new Buffer(10);

// Create Buffer from a given array
const buf2 = new Buffer([10, 20, 30, 40, 50]);

// Create Buffer from a given string and optionally encoding type
const buf3 = new Buffer("Some Random Text", "utf-8");

/* Writing Buffers */

const buf4 = new Buffer(256);
const len = buf4.write("Some Random Text");

console.log("Octets written : " + len);


/* Reading from Buffers */

const buf5 = new Buffer(26);
for (var i = 0; i < 26; i++) {
  buf5[i] = i + 97;
}

console.log(buf5.toString('ascii'));
console.log(buf5.toString('ascii', 0, 5));
console.log(buf5.toString('utf8', 0, 5));
console.log(buf5.toString(undefined, 0, 5));

/* Buffer to JSON */

const buf6 = new Buffer('Some Random Text');
const json = buf6.toJSON(buf6);

console.log(json);


/* Concatenate Buffers */

let buffer1 = new Buffer('Some ');
let buffer2 = new Buffer('Random Text');
let buffer3 = Buffer.concat([buffer1, buffer2]);

console.log('buffer3 content: ' + buffer3.toString());


/* Compare Buffers */

buffer1 = new Buffer('ABC');
buffer2 = new Buffer('ABCD');
const result = buffer1.compare(buffer2);

if(result < 0) {
  console.log(buffer1 + " comes before " + buffer2);
} else if(result === 0) {
  console.log(buffer1 + " is same as " + buffer2);
} else {
  console.log(buffer1 + " comes after " + buffer2);
}


/* Copy Buffer */

buffer1 = new Buffer('ABC');

// Copy a buffer
buffer2 = new Buffer(3);
buffer1.copy(buffer2);
console.log("buffer2 content: " + buffer2.toString());


/* Slice Buffer */

buffer1 = new Buffer('Some Random Text');

// Slicing a buffer
buffer2 = buffer1.slice(0, 9);
console.log("buffer2 content: " + buffer2.toString());


/* Buffer Length */

let buffer = new Buffer('Some Random Text');

// Length of the buffer
console.log('buffer length: ' + buffer.length);