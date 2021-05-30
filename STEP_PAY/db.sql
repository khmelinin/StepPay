use master
go

drop database STEP_PAY 
go

go

create database STEP_PAY
go

use STEP_PAY
go
 
create table Users (
Id int not null primary key identity,
[Name] nvarchar(max) not null,
Email nvarchar(max) not null,
PhoneNumber nvarchar(15) not null,
Birthday date not null
)

 
create table Accounts (
Id int not null primary key identity,
UserId int not null foreign key references Users (Id),
[Login] nvarchar(max) not null,
[Password] nvarchar(max) not null
)


create table Cards (
Id int not null primary key identity,
[Money] money not null,
UserId int not null foreign key references Users (Id),
PinCode int not null,
[ExpiredDate] date not null,
Currency nvarchar(3) not null,
Title nvarchar(max) not null,
Number nvarchar(16) not null,
)
create table Expenses (
Id int not null primary key identity,
CardId int not null foreign key references Cards (Id),
[Money] money not null,
Title nvarchar(max) not null
)
create table Income (
Id int not null primary key identity,
CardId int not null foreign key references Cards (Id),
[Money] money not null,
Title nvarchar(max) not null
)

--insert into Users values (N'TestName', N'testname@gmail.com', '+38066789012345', N'1978-12-12')
--go
--insert into Cards values (300, 1, 1111, N'2024-12-12', 'UAH', 'TestCard', '1234567891234567')
--go

--insert into Expenses values (1, -300, 'Test')
--go

--delete from Expenses
--where Id = 5

--select *
--from Users

--select *
--from Cards

--select *
--from Expenses

--drop table Expenses



go