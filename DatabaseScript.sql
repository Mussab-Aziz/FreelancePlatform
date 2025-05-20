
CREATE DATABASE FreelancePlatformDB;
GO
USE FreelancePlatformDB;
GO

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    Password NVARCHAR(256),
    Role NVARCHAR(50)
);

CREATE TABLE Jobs (
    JobId INT IDENTITY(1,1) PRIMARY KEY,
    ClientId INT FOREIGN KEY REFERENCES Users(UserId),
    Title NVARCHAR(200),
    Description NVARCHAR(MAX),
    Price DECIMAL(18, 2),
    Duration INT
);

CREATE TABLE Applications (
    ApplicationId INT IDENTITY(1,1) PRIMARY KEY,
    JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
    FreelancerId INT FOREIGN KEY REFERENCES Users(UserId),
    CoverLetter NVARCHAR(MAX),
    Status NVARCHAR(50)
);

CREATE TABLE Skills (
    SkillId INT IDENTITY(1,1) PRIMARY KEY,
    SkillName NVARCHAR(100)
);

CREATE TABLE FreelancerSkills (
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    SkillId INT FOREIGN KEY REFERENCES Skills(SkillId)
);
