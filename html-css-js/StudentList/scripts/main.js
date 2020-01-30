const global = {
    classA : [],
    classB : [],
    classC : [],
    classD : []
};

const setup = () => {
  sortStudents(students);
  updateClassNumbers(global);

  // page load produces class A students
  generateClassList(global.classA);

  // a click on a class shows only students from that particular class
  const classImgs = document.querySelectorAll('.classGroup img');
  classImgs.forEach(img => {
      img.addEventListener('click', e => {
          if (e.target.alt === 'class A') {
              generateClassList(global.classA);
          } else if (e.target.alt === 'class B') {
              generateClassList(global.classB);
          } else if (e.target.alt === 'class C') {
              generateClassList(global.classC);
          } else if (e.target.alt === 'class D') {
              generateClassList(global.classD);
          }
      });
  });

  // show student details on student click
  const classList = document.querySelector('#classList');
  classList.addEventListener('click', e => {
      if (e.target.tagName === 'H1') {
          showStudentDetails(e.target.id);
      }
  });
};

// Sort students per class
const sortStudents = (students) => {
    /* sort classes alphabetically */
    students.sort((first, last) => {
        if (first.firstname < last.firstname) {
            return -1;
        } else {
            return 1;
        }
    });

    /* Filter students into their correct classes */
    students.filter(student => {
        if (student.class === 'A'){
            global.classA.push(student);
        } else if (student.class === 'B') {
            global.classB.push(student);
        } else if (student.class === 'C'){
            global.classC.push(student);
        } else if (student.class === 'D') {
            global.classD.push(student);
        }
    });
};

// Get number of students per class and update header images
const updateClassNumbers = () => {
    const classNumbers = document.querySelectorAll('.amount');

    classNumbers[0].innerHTML = global.classA.length.toString();
    classNumbers[1].innerHTML = global.classB.length.toString();
    classNumbers[2].innerHTML = global.classC.length.toString();
    classNumbers[3].innerHTML = global.classD.length.toString();
};

// dynamically build a list in the classlist containing students from that particular class
const generateClassList = (classGroup) => {
    const classList = document.querySelector('#classList');
    const studentDetail = document.querySelector('#studentDetail');

    classList.innerHTML = "";
    studentDetail.style.display = 'none';


    /* Creating a div and h1 for every student in the class */
    for (let i = 0; i < classGroup.length; i++){
        const div = document.createElement('div');
        div.classList.add('student');

        const h1 = document.createElement('h1');
        h1.setAttribute('id', classGroup[i].id);
        h1.innerHTML = `${classGroup[i].firstname} ${classGroup[i].lastname}`;
        
        div.appendChild(h1);
        classList.appendChild(div);
    }
};

// dont show student details on page load and choosing a new class
const showStudentDetails = (studentId) => {
    const studentDetail = document.querySelector('#studentDetail');

    let currentStudent = students.find(person => {
        if (person.id === parseInt(studentId)){
            return true;
        }
    });

    generateStudentDetails(currentStudent, studentDetail);
};

const generateStudentDetails = (student, studentDetail) => {
    /* Clears the studentDetail section of any content */
    studentDetail.innerHTML = '';

    let h1 = document.createElement('h1');
    h1.innerHTML = '';
    h1.innerHTML = `${student.firstname} ${student.lastname}`;

    let a = document.createElement('a');
    a.setAttribute('href', `mailto:${student.email}`);
    a.innerHTML = '';
    a.innerHTML = student.email;

    let p = document.createElement('p');
    p.setAttribute('id', 'birthdate');
    p.innerHTML = '';
    p.innerHTML = `${student.gebdate}`;

    let label = document.createElement('label');
    label.setAttribute('class', 'scoreCount');
    label.setAttribute('for', 'score');
    label.innerHTML = 'Score: ';

    let span = document.createElement('span');
    span.setAttribute('class', 'scoreCount');
    span.setAttribute('id', 'score');
    span.innerHTML = student.score;

    let scoreButton = document.createElement('button');
    scoreButton.setAttribute('type', 'button');
    scoreButton.setAttribute('class', 'enterScore');
    scoreButton.innerHTML = 'Enter Score';

    studentDetail.appendChild(h1);
    studentDetail.appendChild(a);
    studentDetail.appendChild(p);
    
    // score gets adjusted depending on value
    if (student.score <= 0){
        studentDetail.appendChild(scoreButton);
    } else if (student.score >= 10){
        label.classList.add('scoreGreen');
        span.classList.add('scoreGreen');
        studentDetail.appendChild(label);
        studentDetail.appendChild(span);
    } else if (student.score < 10 && student.score > 0){
        label.classList.add('scoreRed');
        span.classList.add('scoreRed');
        studentDetail.appendChild(label);
        studentDetail.appendChild(span);
    }

    studentDetail.style.display = 'block';
};

window.addEventListener('load', setup);