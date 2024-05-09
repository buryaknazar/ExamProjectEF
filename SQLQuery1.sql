-- Inserting data into the Country table
INSERT INTO Countries VALUES ('United States', 'New York', 0, 0);
INSERT INTO Countries VALUES ('United Kingdom', 'London', 0, 0);
INSERT INTO Countries VALUES ('Canada', 'Toronto', 0, 0);
INSERT INTO Countries VALUES ('Australia', 'Sydney', 0, 0);
INSERT INTO Countries VALUES ('Germany', 'Berlin', 0, 0);

-- Inserting data into the Olympiad table
INSERT INTO Olimpiads VALUES ('Summer Olympics 2024','Summer', '2024-07-23', 630, 8);
INSERT INTO Olimpiads VALUES ('Winter Olympics 2026', 'Winter', '2026-02-07', 210, 9);
INSERT INTO Olimpiads VALUES ('Olympics 2028', 'Summer', '2028-08-05', 540, 10);
INSERT INTO Olimpiads VALUES ('Australia Cup 2025', 'Spring', '2025-04-15', 366, 11);
INSERT INTO Olimpiads VALUES ('European Games 2027', 'Autumn', '2027-09-12', 758, 12);
INSERT INTO Olimpiads VALUES ('Test', 'Test', '2027-09-12', 758, 12);

SELECT * FROM Olimpiads
-- sports
INSERT INTO Sports VALUES('Soccer', 20, 12);
INSERT INTO Sports VALUES('Basketball', 10, 12);
INSERT INTO Sports VALUES('Hockey', 26, 12);

INSERT INTO Sports VALUES('Soccer', 20, 13);
INSERT INTO Sports VALUES('Basketball', 10, 13);
INSERT INTO Sports VALUES('Hockey', 26, 13);

INSERT INTO Sports VALUES('Soccer', 20, 14);
INSERT INTO Sports VALUES('Basketball', 10, 14);
INSERT INTO Sports VALUES('Hockey', 26, 14);

INSERT INTO Sports VALUES('Soccer', 20, 15);
INSERT INTO Sports VALUES('Basketball', 10, 15);
INSERT INTO Sports VALUES('Hockey', 26, 15);

INSERT INTO Sports VALUES('Soccer', 20, 16);
INSERT INTO Sports VALUES('Basketball', 10, 16);
INSERT INTO Sports VALUES('Hockey', 26, 16);

--medal statistics

INSERT INTO MedalsStatistics VALUES(2,3,4);

INSERT INTO MedalsStatistics VALUES(4,8,3);

INSERT INTO MedalsStatistics VALUES(1,1,2);

INSERT INTO MedalsStatistics VALUES(8,3,7);

INSERT INTO MedalsStatistics VALUES(9,3,4);

--members
SELECT * FROM Sports

INSERT INTO Members VALUES('Nazar', 'Buryak', 18, '2005-09-22', 8, 1, 16);
INSERT INTO Members VALUES('Homer', 'Simpson', 55, '1970-09-22', 9, 2, 24);
INSERT INTO Members VALUES('Bart', 'Simpson', 24, '1991-09-22', 10, 3, 20);
INSERT INTO Members VALUES('Lisa', 'Simpson', 28, '1981-09-22', 11, 4, 27);
INSERT INTO Members VALUES('Harry', 'Potter', 34, '1980-09-22', 12, 5, 18);

SELECT * FROM Countries

