-- Inserting data into the Country table
INSERT INTO Countries VALUES ('United States', 'New York', 0, 0);
INSERT INTO Countries VALUES ('United Kingdom', 'London', 0, 0);
INSERT INTO Countries VALUES ('Canada', 'Toronto', 0, 0);
INSERT INTO Countries VALUES ('Australia', 'Sydney', 0, 0);
INSERT INTO Countries VALUES ('Germany', 'Berlin', 0, 0);

-- Inserting data into the Olympiad table
INSERT INTO Olimpiads VALUES ('Summer Olympics 2024','Summer', '2024-07-23', 630, 1);
INSERT INTO Olimpiads VALUES ('Winter Olympics 2026', 'Winter', '2026-02-07', 210, 2);
INSERT INTO Olimpiads VALUES ('Olympics 2028', 'Summer', '2028-08-05', 540, 3);
INSERT INTO Olimpiads VALUES ('Australia Cup 2025', 'Spring', '2025-04-15', 366, 4);
INSERT INTO Olimpiads VALUES ('European Games 2027', 'Autumn', '2027-09-12', 758, 5);
INSERT INTO Olimpiads VALUES ('Test', 'Test', '2027-09-12', 758, 12);

SELECT * FROM Olimpiads
-- sports
INSERT INTO Sports VALUES('Soccer', 20, 1);
INSERT INTO Sports VALUES('Basketball', 10, 1);
INSERT INTO Sports VALUES('Hockey', 26, 1);

INSERT INTO Sports VALUES('Soccer', 20, 2);
INSERT INTO Sports VALUES('Basketball', 10, 2);
INSERT INTO Sports VALUES('Hockey', 26, 2);

INSERT INTO Sports VALUES('Soccer', 20, 3);
INSERT INTO Sports VALUES('Basketball', 10, 3);
INSERT INTO Sports VALUES('Hockey', 26, 3);

INSERT INTO Sports VALUES('Soccer', 20, 4);
INSERT INTO Sports VALUES('Basketball', 10, 4);
INSERT INTO Sports VALUES('Hockey', 26, 4);

INSERT INTO Sports VALUES('Soccer', 20, 5);
INSERT INTO Sports VALUES('Basketball', 10, 5);
INSERT INTO Sports VALUES('Hockey', 26, 5);

--medal statistics

INSERT INTO MedalsStatistics VALUES(2,3,4);

INSERT INTO MedalsStatistics VALUES(4,8,3);

INSERT INTO MedalsStatistics VALUES(1,1,2);

INSERT INTO MedalsStatistics VALUES(8,3,7);

INSERT INTO MedalsStatistics VALUES(9,3,4);

--members
SELECT * FROM Olimpiads
SELECT * FROM Countries
SELECT * FROM Members

INSERT INTO Members VALUES('Nazar', 'Buryak', 18, '2005-09-22', 1, 1, 1);
INSERT INTO Members VALUES('Homer', 'Simpson', 55, '1970-09-22', 2, 2, 8);
INSERT INTO Members VALUES('Bart', 'Simpson', 24, '1991-09-22', 3, 3, 7);
INSERT INTO Members VALUES('Lisa', 'Simpson', 28, '1981-09-22', 4, 4, 2);
INSERT INTO Members VALUES('Harry', 'Potter', 34, '1980-09-22', 5, 5, 11);

SELECT * FROM Members