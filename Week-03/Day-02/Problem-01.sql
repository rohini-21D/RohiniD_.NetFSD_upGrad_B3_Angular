CREATE DATABASE EventDb;
USE EventDb;

--1.Add entity class UserInfo and add public properties:--
CREATE TABLE UserInfo(
      EmailId VARCHAR(100) PRIMARY KEY, 
      UserName VARCHAR(50) NOT NULL CHECK(LEN(UserName) BETWEEN 1 and 50),
      Role VARCHAR(20) NOT NULL CHECK(ROLE IN('Admin','Participant')),
      Password VARCHAR(20) NOT NULL CHECK(LEN(Password) BETWEEN 6 and 20)
);

INSERT INTO UserInfo VALUES('abc@gmail.com','Rohini','Admin','myPswd');
INSERT INTO UserInfo VALUES('agr@gmail.com','Rekha','Participant','myPswd');



--Add entity class EventDetails and add below public properties.--

CREATE TABLE EventDetails(
      EventId INT PRIMARY KEY,
      EventName VARCHAR(50) NOT NULL CHECK(LEN(EventName) BETWEEN 1 and 50),
      EventCategory VARCHAR(50) NOT NULL CHECK(LEN(EventCategory) BETWEEN 1 and 50),
      EventDate DATETIME NOT NULL,
      Description VARCHAR(100) NULL,
      Status VARCHAR(20) CHECK(Status IN('Active','In-Active'))
)
INSERT INTO EventDetails VALUES (1, 'Tech Conference', 'Technology', '2026-03-10 10:00:00', 'Annual tech event', 'Active');
INSERT INTO EventDetails VALUES (2, 'Social Conference', 'REAL WORLD', '2026-04-10 10:00:00', 'NULL', 'In-Active');


 --4. Add entity class SpeakersDetails and add below public properties.

 CREATE TABLE SpeakersDetails(
     SpeakerId INT PRIMARY KEY,
     SpeakerName VARCHAR(50) NOT NULL CHECK(LEN(SpeakerName) BETWEEN 1 and 50)
 )

 INSERT INTO SpeakersDetails VALUES(101,'ROHINI');
 INSERT INTO SpeakersDetails VALUES(102,'REKHA');



 --5. Add entity class SessionInfo and add below public properties.

 CREATE TABLE SessionInfo(
      SessionId INT PRIMARY KEY,
      EventId INT NOT NULL,
      SessionTitle VARCHAR(50) NOT NULL CHECK(LEN(SessionTitle) BETWEEN 1 and 50),
      SpeakerId INT NOT NULL,
      Description VARCHAR(100) NULL,
      SessionStart DATETIME NOT NULL,
      SessionEnd DATETIME NOT NULL,
      SessionUrl VARCHAR(50),
      FOREIGN KEY(EventId) REFERENCES EventDetails(EventId),
      FOREIGN KEY(SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
 );

 INSERT INTO SessionInfo VALUES (1,1,'SQL',101,'BASIC OF SQL','2026-03-10 11:00:00','2026-03-10 12:00:00','http://session1.com');
 INSERT INTO SessionInfo VALUES (2,2,'NoSQL',102,'BASIC OF No-SQL','2026-04-10 11:00:00','2026-04-10 12:00:00','http://session2.com');
 --. Add entity class ParticipantEventDetails and add below public properties.
 CREATE TABLE ParticipantEventDetails(
      Id INT PRIMARY KEY,
      ParticipantEmailId VARCHAR(100) NOT NULL,
      EventId INT NOT NULL,
      SessionId INT NOT NULL,
      IsAttended BIT CHECK(IsAttended IN(0,1)),
      FOREIGN KEY(ParticipantEmailId) REFERENCES UserInfo(EmailId),
      FOREIGN KEY(EventId) REFERENCES EventDetails(EventId),
      FOREIGN KEY(SessionId) REFERENCES SessionInfo(SessionId)
 )

 INSERT INTO ParticipantEventDetails VALUES(1,'abc@gmail.com',1,1,1);
 INSERT INTO ParticipantEventDetails VALUES(2,'agr@gmail.com',2,2,0);

 SELECT * FROM UserInfo;
 SELECT * FROM EventDetails;
 SELECT * FROM SpeakersDetails;
 SELECT * FROM SessionInfo;
 SELECT * FROM ParticipantEventDetails;
