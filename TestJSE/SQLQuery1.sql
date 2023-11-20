CREATE DATABASE TestJSE;
USE TestJSE;

CREATE TABLE Schools (
    id INT PRIMARY KEY,
    name VARCHAR(100),
    id_country INT
);

CREATE TABLE Students (
    identity_card INT PRIMARY KEY,
    names VARCHAR(50),
    surnames VARCHAR(50),
    date_of_birth DATE,
    id_school INT
    FOREIGN KEY (id_school) REFERENCES Schools(id)
);

SELECT * FROM Students;
SELECT * FROM Schools;


INSERT INTO Schools (id, name, id_country)
VALUES (1, 'School1',2),(2, 'School1',1),(3, 'School1',1),(4, 'School1',1),(5, 'School1',2);

INSERT INTO Students (identity_card, names, surnames, date_of_birth, id_school)
VALUES (1, 'Juan Manuel','Perez Zea','2001-11-18',1),
        (2, 'Mateo','Zegarra','2002-11-18',1),
        (3, 'Santiago','Vizcarra','2023-11-18',2),
        (4, 'Rodirgo','Ramirez','2023-11-18',2);  


CREATE proc StudentsData

as
begin
    SELECT s.identity_card,CONCAT(s.names,' ',s.surnames), c.name FROM TestJSE.dbo.Students as s inner join
	TestJSE.dbo.Schools as c
	on s.id_school = c.id;
end