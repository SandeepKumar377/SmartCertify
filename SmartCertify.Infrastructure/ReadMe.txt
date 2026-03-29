------------------------------------- EF Core CLI Tool Installation-----------------------
dotnet tool list --global | finsstr "dotnet-ef"
If already have some version and wanted to upgrade use this cmd

cmd>dotnet tool update --global dotnet-ef --version 9.0.0

To un-install
cmd> dotnet tool uninstall --global dotnet-ef

--------------------------------------- EF Core CLI Commands------------------------------
To Scaffold database as model to local project use below cmd.

dotnet ef dbcontext scaffold "Server=DESKTOP-GKVHVMP;Initial Catalog=SmartCertifyDB; User Id=sa;Password=sandeep@123; MultipleActiveResultSets=true;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities -d

Video: 1.14.06


----------------------------------------Database Schema-----------------------------------

Create database SmartCertifyDB
use  SmartCertifyDB;

Create table UserProfile
(
UserId int identity(1,1),
DisplayName NVARCHAR(100) NOT NULL constraint DF_UserProfile_DisplayName Default 'Guest',
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Email NVARCHAR(100) NOT NULL,
AdObjId NVARCHAR(128) NOT NULL,
Constraint PK_UserProfile_UserId primary key (UserId)
)

Create table Roles
(
RoleId INT Identity(1,1),
RoleName NVARCHAR(50) NOT NULL,
Constraint PK_Roles_RoleId Primary Key (RoleId)
)

Create table SmartApp
(
SmartAppId INT Identity(1,1),
AppName NVARCHAR(50) NOT NULL,
CONSTRAINT PK_SmartApp_SmartAppId Primary Key (SmartAppId)
)


Create table UserRole
(
UserRoleId INT Identity(1,1),
RoleId INT NOT NULL,
UserId INT NOT NULL,
SmartAppId INT NOT NULL,
Constraint PK_UserRole_UserRoleId Primary key (UserRoleId),
Constraint FK_UserRole_UserProfileId Foreign Key (UserId) References UserProfile(UserId),
Constraint FK_UserRole_RoleId Foreign Key (RoleId) References Roles(RoleId),
Constraint FK_UserRole_SmartAppId Foreign Key (SmartAppId) References SmartApp(SmartAppId)
)

Create table Courses
(
CourseId INT Identity(1,1),
Title NVARCHAR(100) NOT NULL,
Description NVARCHAR(MAX) NOT NULL,
CreatedBy INT NOT NULL,
CreatedOn DateTime2 NOT NULL Constraint DF_Courses_CreatedOn Default GETDATE(),
Constraint PK_Courses_CourseId Primary key (CourseId),
Constraint FK_Courses_CreatedBy Foreign Key (CreatedBy) References UserProfile(UserId),
)

Create table Questions
(
QuestionId INT Identity(1,1),
CourseId INT NOT NULL,
QuestionText NVARCHAR(MAX) NOT NULL,
DifficultyLevel NVARCHAR(20) NOT NULL,
IsCode BIT NOT NULL Default 0,
HasMultipleAnswers BIT NOT NULL Default 0,
Constraint PK_Questions_QuestionId Primary key (QuestionId),
Constraint FK_Questions_CourseId Foreign Key (CourseId) References Courses(CourseId),
)

Create table Choices
(
ChoiceId INT Identity(1,1),
QuestionId INT NOT NULL,
ChoiceText NVARCHAR(MAX) NOT NULL,
IsCode BIT NOT NULL Default 0,
IsCorrect BIT NOT NULL,
Constraint PK_Choices_ChoiceId Primary key (ChoiceId),
Constraint FK_Choices_QuestionId Foreign Key (QuestionId) References Questions(QuestionId),
)

Create table Exams
(
ExamId INT Identity(1,1),
CourseId INT NOT NULL,
UserId INT NOT NULL,
Status NVARCHAR(20) NOT NULL Default 'In Progress',
StartedOn DateTime2 NOT NULL Constraint DF_Exams_StaredOn Default GetDate(),
FinishedOn DATETIME2 NULL,
Feedback NVARCHAR(2000) NULL,
Constraint PK_Exams_ExamId Primary key (ExamId),
Constraint FK_Exams_CourseId Foreign Key (CourseId) References Courses(CourseId),
Constraint FK_Exams_UserId Foreign Key (UserId) References UserProfile(UserId),
)

Create table ExamQuestions
(
ExamQuestionId INT Identity(1,1),
ExamId INT NOT NULL,
QuestionId INT NOT NULL,
SelectedChoiceId INT NULL,
IsCorrect BIT NULL,
ReviewLater BIT NULL Default 0,
Constraint PK_ExamQuestions_ExamQuestionId Primary key (ExamQuestionId),
Constraint FK_ExamQuestions_ExamId Foreign Key (ExamId) References Exams(ExamId),
Constraint FK_ExamQuestions_QuestionId Foreign Key (QuestionId) References Questions(QuestionId),
Constraint FK_ExamQuestions_SelectedChoiceId Foreign Key (SelectedChoiceId) References Choices(ChoiceId),
)

Create table Notification
(
NotificationId INT Identity(1,1),
Subject NVARCHAR(200) NOT NULL,
Content NVARCHAR(MAX) NOT NULL,
CreatedOn DATETIME2 NOT NULL Constraint DF_Notification_CreatedOn Default GETDATE(),
ScheduledSendTime DATETIME2 NOT NULL,
IsActive BIT NOT NULL DEFAULT 1,
Constraint PK_Notification_NotificationId Primary key (NotificationId)
)

Create table UserNotifications
(
UserNotificationId INT Identity(1,1),
NotificationId INT NOT NULL,
UserId INT NOT NULL,
EmailSubject NVARCHAR(200) NOT NULL,
EmailContent NVARCHAR(MAX) NOT NULL,
NotificationSent BIT NOT NULL DEFAULT 0,
SentOn DATETIME2 NULL,
CreatedOn DATETIME2 NOT NULL Constraint DF_UserNotification_CreatedOn Default GETDATE(),
Constraint PK_UserNotifications_UserNotificationId Primary key (UserNotificationId),
Constraint FK_UserNotifications_NotificationId Foreign Key (NotificationId) References Notification(NotificationId),
Constraint FK_UserNotifications_UserId Foreign Key (UserId) References UserProfile(UserId)
)

Create table BannerInfo
(
BannerId INT Identity(1,1),
Title NVARCHAR(100) NOT NULL,
Content NVARCHAR(MAX) NOT NULL,
ImageUrl NVARCHAR(500) null,
IsActive BIT NOT NULL DEFAULT 1,
DisplayFrom DATETIME2 NOT NULL,
DisplayTo DATETIME2 NOT NULL,
CreatedOn DATETIME2 NOT NULL Constraint DF_BannerInfo_CreatedOn Default GETDATE(),
Constraint PK_BannerInfo_BannerId Primary key (BannerId)
)

Create Table UserActivityLog
(
LogId INT Identity(1,1),
UserId INT,
ActivityType NVARCHAR(50) NOT NULL,
ActivityDescription NVARCHAR(MAX),
LogDate DATETIME NOT NULL,
Constraint PK_UserActivityLog_LogId Primary key (LogId),
Constraint FK_UserActivityLog_UserProfile Foreign Key (UserId) References UserProfile(UserId)
)

Create table ContactUs
(
ContactUsId INT Identity(1,1),
UserName NVARCHAR(100) NOT NULL,
UserEmail NVARCHAR(100) NOT NULL,
MessageDetail NVARCHAR(2000) NOT NULL,
CreatedOn DATETIME2 NOT NULL Constraint DF_ContactUs_CreatedOn Default GETDATE(),
Constraint PK_ContactUs_ContactUsId  Primary key (ContactUsId)
)

