const global = {
  counter: 0,
  highest: 0,
  lastOP: "",
  lastNum: localStorage.getItem("lastNum")
};

const setup = () => {
  let controls = document.querySelector('#controls');
  let input = document.querySelector('#manual');

  if (!(global.lastNum == null)) {
    global.counter = global.lastNum;
    global.highest = global.lastNum;
  }
  
    controls.addEventListener('click', e => {
    let manualInput = input.value;
    
    if (e.target.id == 'decrement' && global.counter >= 1) {
      global.counter--;
      global.lastOP = "-1";
      updateGUI(global.counter, global.highest, global.lastOP);
      keepCount(global.counter);
    } else if (e.target.id == 'reset' && positivecounter(global.counter)) {
      global.counter = 0;
      global.highest = 0;
      global.lastOP = "reset";
      updateGUI(global.counter, global.highest, global.lastOP);
      keepCount(global.counter);
    } else if (e.target.id == 'increment' && positivecounter(global.counter)) {
      global.counter++;
      global.highest++;
      global.lastOP = "+1";
      updateGUI(global.counter, global.highest, global.lastOP);
      keepCount(global.counter);
    } else if (e.target.id == "manualGO" && positivecounter(global.counter) && positivecounter(manualInput) && !manualInput == "") {
      global.counter = manualInput;
      global.highest = manualInput;
      global.lastOP = "manual"
      updateGUI(global.counter, global.highest, global.lastOP);
      keepCount(global.counter);
      input.value = "";
    } else {
      global.lastOP = "";
    }
  });

  global.lastOP = "";
  updateGUI(global.counter, global.highest, global.lastOP);
}

const updateGUI = (counter, highest, lastOP) => {
  let counterNumber = document.querySelector('#counterNumber');
  let lastMax = document.querySelector('#lastMax');
  let lastOp = document.querySelector('#lastOp');
  
    counterNumber.innerHTML = counter;
    lastMax.innerHTML = highest;
    lastOp.innerHTML = lastOP;
}

const positivecounter = (number) => {
  if (number >= 0) {
    return true;
  } else {
    return false;
  }
}

const keepCount = (counter) => {
  localStorage.setItem("lastNum", counter);
}

window.addEventListener('load', setup);