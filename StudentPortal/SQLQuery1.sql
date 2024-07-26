Create Database Student_Database


drop table Student_Personal_Info
use Student_Database
create table Student_Personal_Info(
	StudentId Int Not null identity(1,1) primary Key,
	FullName varchar(max) Not Null,
	Age Int,
	Gender varchar(100) not null,
	Address_In_Text Varchar(max),
	Address_In_Menu Varchar(max),
	PhoneNumber varchar(max) not null,
	Email varchar(max),
	Date_insert Date null,
	Date_update Date null
)

EXEC sp_RENAME 'Student_Personal_Info.Gendar' , 'Gender', 'COLUMN'

Select * From Student_Personal_Info

INSERT INTO Student_Personal_Info(FullName, Age, Gender, Address_In_Text, Address_In_Menu,  PhoneNumber, Email)
values ('Shakib Al Hasan', 36, 'Male', 'Chittagang 1204 Road 12', 'Chittagang - CoxBaza - Uthuli', '0173569871', 'tamimiqbal@gmail.com')


Select * from AddressCombobox

create table AddressCombobox(
	Division varchar(max),
	District	varchar(max),
	Thana  varchar(max)
)
drop table AddressCombobox

EXEC sp_RENAME 'AddressCombobox.Divition' , 'Division', 'COLUMN'

INSERT INTO AddressCombobox(Division, District, Thana)
values ('Rajshahi', 'Bogura', 'Bogura Sadar'),
		('Rajshahi', 'Bogura', 'Dhunot'),
		('Rajshahi', 'Bogura', 'NondiGram'),
		('Rajshahi', 'Bogura', 'ShibGange'),
		('Rajshahi', 'Bogura', 'Sonatola'),
		('Rajshahi', 'Pabna', 'Pabna Sadar'),
		('Rajshahi', 'Pabna', 'Sathia'),
		('Rajshahi', 'Pabna', 'Bera'),
		('Rajshahi', 'Pabna', 'Aminpur'),
		('Rajshahi', 'Pabna', 'Chatmohor'),
		('Dhaka', 'Dhaka', 'Pollobi'),
		('Dhaka', 'Dhaka', 'Mirpur'),
		('Dhaka', 'Dhaka', 'Kawranbazar'),
		('Dhaka', 'ManikGanje', 'Shibaloy'),
		('Dhaka', 'ManikGanje', 'Sadar')


SELECT DISTINCT(Division) FROM AddressCombobox
SELECT DISTINCT(District) from AddressCombobox where Division =  'Dhaka'

SELECT DISTINCT(Thana) from AddressCombobox where District = 'Pabna'