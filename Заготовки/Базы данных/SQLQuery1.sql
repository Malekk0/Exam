CREATE TABLE Groups(
id INTEGER PRIMARY KEY,
course INTEGER,
name NVARCHAR(20));

CREATE TABLE Students(
id INTEGER PRIMARY KEY,
first_name NVARCHAR(30),
middle_name NVARCHAR(30),
last_name NVARCHAR(30),
gender NVARCHAR(1),
group_id INTEGER REFERENCES Groups(id));

CREATE TABLE Courses(
id INTEGER PRIMARY KEY,
name NVARCHAR(30));

CREATE TABLE Grades(
id INTEGER PRIMARY KEY,
value INTEGER,
student_id INTEGER REFERENCES Students(id),
course_id INTEGER REFERENCES Courses(id));

GO

INSERT INTO Groups
VALUES (4, 2, N'Группа 4');

INSERT INTO Students
VALUES (4, N'Зорина', N'Анатольевна', N'Оля', 'F', 3);

INSERT INTO Courses
VALUES (1, N'Математика')

INSERT INTO Grades
VALUES (5, 5, 3, 3);

GO

SELECT COUNT(id) as 'Кол-во студентов'
FROM Students

SELECT (SELECT COUNT(gender) FROM Students WHERE gender = 'M') / CAST(COUNT(id) AS FLOAT) AS 'Процент юношей'
FROM Students

SELECT c.id, c.name, AVG(g.value + 0.0) AS 'Средняя оценка'
FROM Courses c
LEFT JOIN Grades g ON c.id = g.course_id
GROUP BY c.id, c.name

SELECT gp.id, gp.name, AVG(ge.value + 0.0)
FROM Groups gp
LEFT JOIN Students s ON gp.id = s.group_id
LEFT JOIN Grades ge ON s.id = ge.student_id
GROUP BY gp.id, gp.name

SELECT s.id, s.last_name, AVG(g.value + 0.0)
FROM Students s
LEFT JOIN Grades g ON s.id = g.student_id
GROUP BY s.id, s.last_name

SELECT COUNT(s.id)
FROM Students s
WHERE (SELECT AVG(g.value + 0.0) FROM Grades g WHERE g.student_id = s.id) > 4.5