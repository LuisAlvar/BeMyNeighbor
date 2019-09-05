create database BeMyNeighbor
go

create schema Users
go

create schema Posts
go

create schema Communities
go

create schema Tasks
go

create schema Evaluation
go

create schema [Location]
go

create table [Location].[Address](

    AddressID int not null IDENTITY(300,1),
    StreetName NVARCHAR(50) not null,
    City NVARCHAR(25) not null,
    StateProvince NVARCHAR (20) not null,
    Zipcode int not null
);

alter table [Location].[Address]
    add CONSTRAINT Address_PK PRIMARY KEY (AddressID);


create table [Users].[User](
    UserID int not null IDENTITY (1,1),
    CommunityID int not null,
    Firstname nvarchar(25) not null,
    Lastname nvarchar(25) not null,
    Username nvarchar (25) not null,
    HashedPassword nvarchar(max) not null,
    SeedPassword nvarchar(max) not null,
    VerifiedUser bit not null,
    NubmerOfPoints int not null,
    Email nvarchar(50) not null unique,
    AddressID int not null
);

alter table [Users].[User]
    add CONSTRAINT User_PK PRIMARY KEY (UserID);

alter table [Users].[User]
    add CONSTRAINT User_Address_FK FOREIGN KEY (AddressID) REFERENCES [Location].[Address] (AddressID);   
    
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Location].[GeoLocation](
	[GeoLocationID] [int] IDENTITY(30,1) NOT NULL,
	[Latitude] [decimal](12, 9) NOT NULL,
	[Longitude] [decimal](12, 9) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [Location].[GeoLocation] ADD  CONSTRAINT [Geo_Location_PK] PRIMARY KEY CLUSTERED 
(
	[GeoLocationID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Communities].[Community](
	[CommunityID] [int] IDENTITY(10,1) NOT NULL,
	[CommunityName] [nvarchar](50) NOT NULL,
	[LocationID] [int] NOT NULL,
	[Radius] [decimal](5, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [Communities].[Community] ADD  CONSTRAINT [Community_PK] PRIMARY KEY CLUSTERED 
(
	[CommunityID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO
ALTER TABLE [Communities].[Community]  WITH CHECK ADD  CONSTRAINT [Community_GeoLocation_FK] FOREIGN KEY([LocationID])
REFERENCES [Location].[GeoLocation] ([GeoLocationID])
GO
ALTER TABLE [Communities].[Community] CHECK CONSTRAINT [Community_GeoLocation_FK]
GO

create table [Posts].[Post](
  PostID int IDENTITY(1,1),
  GeoLocationID int not null,
  CommunityID int not null, 
  DatePosted DATETIME2 not null, 
  TaskTypeID int not null
);

alter table [Posts].[Post]
  add CONSTRAINT Post_PK PRIMARY KEY (PostID);

alter table [Posts].[Post]
  add CONSTRAINT CommunityID_FK FOREIGN KEY (CommunityID) REFERENCES [Communities].[Community] (CommunityID);

alter table [Posts].[Post]
  add CONSTRAINT GeoLocation_FK FOREIGN KEY (GeoLocationID) REFERENCES [Location].[GeoLocation] (GeoLocationID);

create table [Tasks].[Task] (
  TaskTypeID int identity (100,10) not null,
  TaskDescription nvarchar (50),
  TaskTypeRewardPoints int not null
);

alter table [Tasks].[Task]
  add CONSTRAINT Task_PK PRIMARY KEY (TaskTypeID);

alter table [Posts].[Post]
  add CONSTRAINT TaskType_FK FOREIGN KEY (TaskTypeID) REFERENCES [Tasks].[Task] (TaskTypeID);

create table [Evaluation].[Questions](
    QuestionID int identity (100,2) not null,
    QuestionText nvarchar (max) not null,
);

alter table [Evaluation].[Questions]
  add CONSTRAINT Task_PK PRIMARY KEY (QuestionID);

create table [Evaluation].[UsersEvaluation](
    EvaluationID int identity (1000,1) not null,
    PostID int not null,
    TaskTypeID int not null,
    UserID int not null,
    TotalScore int not null
);

alter table [Evaluation].[UsersEvaluation]
  add CONSTRAINT UserEval_PK PRIMARY KEY (EvaluationID);

alter table [Evaluation].[UsersEvaluation]
  add CONSTRAINT User_Evaluation_FK FOREIGN KEY (UserID) REFERENCES [Users].[User] (UserID);
alter table [Evaluation].[UsersEvaluation]
  add CONSTRAINT Post_FK FOREIGN KEY (PostID) REFERENCES [Posts].[Post] (PostID);
alter table [Evaluation].[UsersEvaluation]
  add CONSTRAINT Task_FK FOREIGN KEY (TaskTypeID) REFERENCES [Tasks].[Task] (TaskTypeID);

create table [Evaluation].[EvaluationQuestions](
  EvaluationID int not null,
  QuestionID int not null,
  QuestionScore int not null,
  QuestionAnswer nvarchar(max) null
);

alter table [Evaluation].[EvaluationQuestions]
  add CONSTRAINT Eval_Quest_PK PRIMARY KEY (EvaluationID,QuestionID);

alter table [Evaluation].[EvaluationQuestions]
  add CONSTRAINT Questions_UserEvaluation_FK FOREIGN KEY (EvaluationID) 
  REFERENCES [Evaluation].[UsersEvaluation] (EvaluationID);

alter table [Evaluation].[EvaluationQuestions]
  add CONSTRAINT Question_EvalQuestion_FK FOREIGN KEY (QuestionID) REFERENCES [Evaluation].[Questions] (QuestionID);
