-- opret brugere
create login admin1 with password = '123';
GRANT ALL PRIVILEGES TO admin1;

create login bruger1 with password = '123';
GRANT SELECT ON ansatte to bruger1


---- opret database og brug database
CREATE DATABASE data1;
PRINT 'CREATE DATABASE data1'
GO
USE data1


-- Opret tabeller
CREATE TABLE Ansatte (
    AnsatteID INT PRIMARY KEY IDENTITY(1,1),
    Fornavn NVARCHAR(64),
    Efternavn NVARCHAR(64),
    Fødselsdato DATE,
    Månedsløn DECIMAL(10, 2),
    AnsatDato DATE,
);

CREATE TABLE Afdelinger (
    AfdelingID INT PRIMARY KEY IDENTITY(1,1),
    AfdelingNavn NVARCHAR(64),
    Lokation NVARCHAR(64),
);

CREATE TABLE Projekter (
    ProjektID INT PRIMARY KEY IDENTITY(1,1),
    ProjektNavn NVARCHAR(64),
    StartDato DATE,
    SlutDato DATE,
    Afsluttet BIT,
);

CREATE TABLE AnsatteAfdelinger (
    AnsatteAfdelingerID INT PRIMARY KEY IDENTITY(1,1),
    AnsatteID INT,
    AfdelingID INT,
    FOREIGN KEY (AnsatteID) REFERENCES Ansatte(AnsatteID),
    FOREIGN KEY (AfdelingID) REFERENCES Afdelinger(AfdelingID),
);

CREATE TABLE AnsatteProjekter (
    AnsatteProjekterID INT PRIMARY KEY IDENTITY(1,1),
    AnsatteID INT,
    ProjektID INT,
    FOREIGN KEY (AnsatteID) REFERENCES Ansatte(AnsatteID),
    FOREIGN KEY (ProjektID) REFERENCES Projekter(ProjektID),
);

-- Indsæt data i Ansatte tabel
INSERT INTO Ansatte (Fornavn, Efternavn, Fødselsdato, Månedsløn, AnsatDato)
VALUES
    ('Hansen', 'Andersen', '1990-05-15', 15000.00, '2022-01-10'),
    ('Anna', 'Petersen', '1985-08-20', 15500.00, '2021-03-05'),
    ('Peter', 'Nielsen', '1992-11-30', 14800.00, '2022-05-20'),
    ('Lars', 'Jensen', '1988-02-25', 16000.00, '2022-02-15'),
    ('Mette', 'Olsen', '1991-07-12', 14500.00, '2022-03-10'),
    ('Karina', 'Madsen', '1995-04-03', 15200.00, '2022-04-20');

-- Indsæt data i Afdelinger tabel
INSERT INTO Afdelinger (AfdelingNavn, Lokation)
VALUES
    ('Afdeling a', 'Lokation A'),
    ('Afdeling b', 'Lokation B'),
    ('Afdeling c', 'Lokation C');

-- Indsæt data i Projekter-tabel
INSERT INTO Projekter (ProjektNavn, StartDato, SlutDato, Afsluttet)
VALUES
    ('Projekt A1', '2022-01-01', '2022-03-31', 1),
    ('Projekt A2', '2022-04-01', '2022-06-30', 0),
    ('Projekt B1', '2022-01-01', '2022-03-31', 0),
    ('Projekt B2', '2022-04-01', '2022-06-30', 1),
    ('Projekt C1', '2022-01-01', '2022-03-31', 0),
    ('Projekt C2', '2022-04-01', '2022-06-30', 0);

-- Knyt ansatte til afdelinger
INSERT INTO AnsatteAfdelinger (AnsatteID, AfdelingID)
VALUES
    (1, 1), 
    (2, 2), 
    (3, 3), 
    (4, 1), 
    (5, 2), 
    (6, 3); 

-- Knyt ansatte til projekter
INSERT INTO AnsatteProjekter (AnsatteID, ProjektID)
VALUES
    (1, 1), 
    (1, 2), 
    (2, 3), 
    (2, 4), 
    (3, 5), 
    (3, 6), 
    (4, 1), 
    (5, 4), 
    (6, 6); 


-- sql opgave 
-- 1. jeg har lavet det omvendt
SELECT Efternavn
FROM Ansatte
WHERE Fornavn = 'Hansen';
-- det her er hvordan den skal se ud for jeg har lavet hansen til fornavn
--SELECT fornavn
--FROM Ansatte
--WHERE efternavn = 'Hansen';


-- 2. 
SELECT Fornavn, Efternavn
FROM Ansatte
WHERE Fornavn LIKE 'A%';


-- 3.
SELECT 
    A.AfdelingNavn, 
    A.Lokation, 
    ANS.Fornavn AS AnsatFornavn, 
    ANS.Efternavn AS AnsatEfternavn
FROM 
    Afdelinger A
JOIN 
    AnsatteAfdelinger AA ON A.AfdelingID = AA.AfdelingID
JOIN 
    Ansatte ANS ON AA.AnsatteID = ANS.AnsatteID;


-- 4.
-- a.
SELECT Fornavn, Efternavn
FROM Ansatte
WHERE Fødselsdato > '1990-01-01';

-- b.
SELECT Fornavn, Efternavn
FROM Ansatte
WHERE DATEDIFF(YEAR, AnsatDato, GETDATE()) > 5;

-- c.
SELECT A.Fornavn, A.Efternavn, D.AfdelingNavn, A.AnsatDato
FROM Ansatte A
JOIN AnsatteAfdelinger AA ON A.AnsatteID = AA.AnsatteID
JOIN Afdelinger D ON AA.AfdelingID = D.AfdelingID;

-- d.
SELECT Fornavn, Efternavn, CAST(Fødselsdato AS DATE) AS Fødselsdato
FROM Ansatte;


-- 5.
SELECT 
    P.ProjektNavn, 
    A.Fornavn AS AnsatFornavn, 
    A.Efternavn AS AnsatEfternavn
FROM 
    Projekter P
JOIN 
    AnsatteProjekter AP ON P.ProjektID = AP.ProjektID
JOIN 
    Ansatte A ON AP.AnsatteID = A.AnsatteID
JOIN 
    AnsatteAfdelinger AA ON A.AnsatteID = AA.AnsatteID
JOIN 
    Afdelinger D ON AA.AfdelingID = D.AfdelingID;


-- 6.
SELECT Fornavn, Efternavn, Månedsløn
FROM Ansatte
WHERE AnsatteID IN (
    SELECT AnsatteID
    FROM AnsatteAfdelinger
    WHERE AfdelingID = (
        SELECT AfdelingID
        FROM Afdelinger
        WHERE AfdelingNavn = 'Afdeling a'
    )
);


-- 7.
SELECT 
    CONCAT(A.Fornavn, ' ', A.Efternavn) AS AnsatNavn,
    D.AfdelingNavn AS Afdeling,
    STUFF((
        SELECT ', ' + P.ProjektNavn
        FROM Projekter P
        INNER JOIN AnsatteProjekter AP ON AP.ProjektID = P.ProjektID
        WHERE AP.AnsatteID = A.AnsatteID
        FOR XML PATH(''), TYPE
    ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Projekter
FROM Ansatte A
JOIN AnsatteAfdelinger AA ON A.AnsatteID = AA.AnsatteID
JOIN Afdelinger D ON AA.AfdelingID = D.AfdelingID;


-- 8.
SELECT TOP 1 CONCAT(Fornavn, ' ', Efternavn) AS AnsatNavn
FROM Ansatte
ORDER BY Månedsløn DESC;


-- 9.
SELECT AVG(Månedsløn) AS Gennemsnitsløn
FROM Ansatte;
