CREATE TABLE user (
    Id INT PRIMARY KEY,
    Username VARCHAR(255),
    Mail VARCHAR(255),
    PhoneNumber VARCHAR(20),
    Skillsets VARCHAR(255),
    Hobby VARCHAR(255)
);

CREATE TABLE Authors (
    AuthorId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255)
);

CREATE TABLE Books (
    BookId INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255),
    AuthorId INT,
    FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId)
);


INSERT INTO Authors (Name) VALUES ('Author 1');
INSERT INTO Authors (Name) VALUES ('Author 2');

INSERT INTO Books (Title, AuthorId) VALUES ('Book 1', 1);
INSERT INTO Books (Title, AuthorId) VALUES ('Book 2', 1);
INSERT INTO Books (Title, AuthorId) VALUES ('Book 3', 2);


POST 
{
  "bookId": 4,
  "title": "string",
  "authorId": 3,
  "author": {
    "authorId": 3,
    "name": "Ho Weng Yin",
    "books": []
  }
}


PUT

{
  "bookId": 4,
  "title": "string123123123131",
  "authorId": 3,
  "author": {
    "authorId": 3,
    "name": "string",
    "books": []
  }
}


CREATE TABLE Students (
    StudentId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255)
);

CREATE TABLE Results (
    ResultId INT AUTO_INCREMENT PRIMARY KEY,
    Exam VARCHAR(255)
);

CREATE TABLE StudentResults (
    StudentResultId INT AUTO_INCREMENT PRIMARY KEY,
    StudentId INT,
    ResultId INT,
    Score INT,
    FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
    FOREIGN KEY (ResultId) REFERENCES Results(ResultId)
);

-- Insert Students
INSERT INTO Students (Name) VALUES ('John Doe');
INSERT INTO Students (Name) VALUES ('Jane Doe');
INSERT INTO Students (Name) VALUES ('Bob Smith');

-- Insert Results
INSERT INTO Results (Exam) VALUES ('Math');
INSERT INTO Results (Exam) VALUES ('Science');
INSERT INTO Results (Exam) VALUES ('History');

-- Insert StudentResults
INSERT INTO StudentResults (StudentId, ResultId, Score) VALUES (1, 1, 95);
INSERT INTO StudentResults (StudentId, ResultId, Score) VALUES (1, 2, 85);
INSERT INTO StudentResults (StudentId, ResultId, Score) VALUES (2, 1, 90);
INSERT INTO StudentResults (StudentId, ResultId, Score) VALUES (2, 2, 75);
INSERT INTO StudentResults (StudentId, ResultId, Score) VALUES (3, 3, 80);

GET METHOD

https://localhost:7095/api/StudentResult

GET METHOD by ID

https://localhost:7095/api/StudentResult/1

POST METHOD

https://localhost:7095/api/StudentResult

{
  "studentId": 4,
  "student": {
    "studentId": 4,
    "name": "string",
    "studentResults": []
  },
  "resultId": 4,
  "result": {
    "resultId": 4,
    "exam": "COMPUTERSCIENCE",
    "studentResults": []
  },
  "score": 120
}

PUT METHOD:

https://localhost:7095/api/StudentResult/4

{
  "studentId": 4,
  "student": {
    "studentId": 4,
    "name": "string",
    "studentResults": []
  },
  "resultId": 4,
  "result": {
    "resultId": 4,
    "exam": "IT",
    "studentResults": []
  },
  "score": 50
}

DELETE METHOD:

https://localhost:7095/api/StudentResult/4
