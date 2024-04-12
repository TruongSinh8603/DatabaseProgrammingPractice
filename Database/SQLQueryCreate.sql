use master
go
create database QLSV
ON  PRIMARY 
( NAME = N'QLSV', FILENAME = N'D:\DatabaseProgrammingPractice\Database\QLSV.mdf' , SIZE = 102400KB , FILEGROWTH = 10%)
LOG ON 
( NAME = N'QLSV_log', FILENAME = N'D:\DatabaseProgrammingPractice\Database\QLSV_log.ldf' , SIZE = 51200KB , FILEGROWTH = 5%)
GO

use QLSV
go
create table SinhVien(
	SV_ID int not null primary key identity,
	SV_Name nvarchar(30) not null,
	SV_Phone varchar(11) not null,
	SV_Email varchar(30) not null
)

use QLSV
go
insert into SinhVien(SV_Name, SV_Phone, SV_Email)
values (N'Nguyễn Văn A', '1233', 'abc@123'),
	(N'Lê Văn B', '12333', 'def@456')