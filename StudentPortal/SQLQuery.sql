Create Database Student_Database


drop table Student_Personal_Info
use Student_Database
create table Student_Personal_Info(
	StudentId Int Not null identity(1,1) primary Key,
	FullName varchar(max) Not Null,
	Age Int,
	Gendar varchar(100) not null,
	Address_In_Text Varchar(max),
	Address_In_Menu Varchar(max),
	PhoneNumber varchar(max) not null,
	Email varchar(max),
	Date_insert Date null,
	Date_update Date null
)

EXEC sp_RENAME 'Student_Personal_Info.Gendar' , 'Gender', 'COLUMN'

Select * From Student_Personal_Info

INSERT INTO Student_Personal_Info(FullName, Age, Gendar, Address_In_Text, Address_In_Menu,  PhoneNumber, Email)
values ('Tamim Iqbal', 36, 'Male', 'Chittagang 1204 Road 12', 'Chittagang - CoxBaza - Uthuli', '0173569871', 'tamimiqbal@gmail.com')


