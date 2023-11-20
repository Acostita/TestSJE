CREATE DATABASE TestJSE; -- creamos la base de datos
USE TestJSE;             -- seleccionamos la base de datos creada

CREATE TABLE Schools (   -- creamos la tabla "Schools" para poder 
    id INT PRIMARY KEY,  -- asignar un id de Schools a nuestra tabla Students
    name VARCHAR(100),
    id_country INT
);

CREATE TABLE Students ( -- creamos la tabla students con el FK a Schools
    identity_card INT PRIMARY KEY,
    names VARCHAR(50),
    surnames VARCHAR(50),
    date_of_birth DATE,
    id_school INT
    FOREIGN KEY (id_school) REFERENCES Schools(id)
);

SELECT * FROM Students; -- seleccionamos los valores de nuestra tabla Students
SELECT * FROM Schools; -- seleccionamos los valores de nuestra tabla Schools

INSERT INTO Schools (id, name, id_country)
VALUES (2, 'School2', 1),(3, 'School3', 1),(4, 'School4', 1),(5, 'School5', 2);


CREATE PROCEDURE StudentsData -- creamos un procedimiento para llamar
as
begin
    SELECT * FROM Students;
end
