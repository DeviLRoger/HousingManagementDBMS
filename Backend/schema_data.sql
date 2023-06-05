use apartmentDB;

create table Signin(
username varchar(30),
pass     varchar(30),
primary key(username));

create table Tenant(
userName varchar(30),
Tenant_Name varchar(30),
aadhar_ID varchar(30),
age int,
primary key(userName),
foreign key(userName) references Signin(username));

create table building(
Building_no  varchar(20),
Building_name varchar(20),
complaint     varchar(30),
primary key(Building_name)
);

create table apartment(
occupancy_status varchar(30),
Apartment_no     int,
design           varchar(20),
Floor_no         int,
Building_name         varchar(20),
parking_sapce    varchar(20),
primary key (Apartment_no),
foreign key (Building_name) references building(Building_name));

create table Owner_Table(
userName varchar(30),
Owner_Name varchar(30),
apartment_no  int, 
aadhar_ID varchar(30),
building_name varchar(20),
primary key(userName),
foreign key(apartment_no) references apartment(Apartment_no),
foreign key(userName) references Signin(username),
foreign key (Building_name) references building(Building_name));

create table Employee1(
userName  varchar(30),
Emp_name  varchar(30),
Salary    int,
age       int,
Building_name varchar(20),
primary key(userName),
foreign key(Building_name) references building(Building_name));

ALTER TABLE  ADD CONSTRAINT ForeignKey_Name FOREIGN KEY (Column_Name) REFERENCES Table_Name2 (Column_Name);

create table agreement(
Owner_id     varchar(30),
tenant_id    varchar(30),
foreign key(Owner_id) references Owner_Table(userName),
foreign key(tenant_id) references Tenant(userName));

create table rental(
Date_of_Renting  date,
Monthly_rent     int,
Tenant_id      varchar(30),
apartment_no   int,
primary key(Tenant_id),
foreign key(Tenant_id) references Tenant(userName),
foreign key(apartment_no) references apartment(Apartment_no));

insert into signin values('o111', 'owner');
insert into signin values('t001', 'tenant');
insert into signin values('o112', 'owner');
insert into signin values('e010', 'employee');
insert into signin values('t002', 'tenant');
insert into signin values('t003', 'tenant');
insert into signin values('t004', 'tenant');
insert into signin values('t005', 'tenant');
insert into signin values('o113', 'owner');
insert into signin values('o114', 'owner');
insert into signin values('o115', 'owner');
insert into signin values('e020', 'employee');
insert into signin values('e030', 'employee');
insert into signin values('e040', 'employee');
insert into signin values('e050', 'employee');
insert into signin values('e060', 'employee');

insert into tenant values('t001', 'Rahul Sharma', '876019238', 24);
insert into tenant values('t002', 'Aditya Singh', '93756289', 24);
insert into tenant values('t003', 'Neha Patel', '91245698', 21);
insert into tenant values('t004', 'Adrika Shah', '67753298', 32);
insert into tenant values('t005', 'Raj Singhania', '68956201', 53);

alter table Employee1 add phone_no varchar(15);

alter table Owner_Table add phone_no varchar(15);

alter table Tenant add phone_no varchar(20);

insert into building values('1', 'A', 'Drainage problem');
insert into building values('1', 'B', 'Fungus problem');
insert into building values('1', 'C', NULL);

insert into apartment values('Vacant', '703', '3BHK', 7, 'A', 'A-703');
insert into apartment values('Occupied', '2902', '5BHK', 29, 'C', 'C-2902');
insert into apartment values('Occupied', '003', '1BHK', 0, 'A', 'A-003');
insert into apartment values('Vacant', '304', '2BHK', 2, 'B', 'B-304');
insert into apartment values('Vacant', '702', '3BHK', 7, 'A', 'A-702');

insert into owner_table values('o111', 'Kapil Sharma', '2902', '86590321', 'C',NULL);
insert into owner_table values('o112', 'Rahul Raj', '703', '785672912', 'A',NULL);
insert into owner_table values('o113', 'Aryan Shirke', '304', '210967892','B',NULL);
insert into owner_table values('o114', 'Tanmay Gupta', '702', '86590321','A',NULL);
insert into owner_table values('o115', 'Aditya Nair', '003', '121347654', 'A',NULL);
update Owner_Table set phone_no='6408097162' where userName='o111';
update Owner_Table set phone_no='8723456789' where userName='o112';
update Owner_Table set phone_no='9745628750' where userName='o113';
update Owner_Table set phone_no='1209567890' where userName='o114';
update Owner_Table set phone_no='6341546789' where userName='o115';

insert into employee1 values('e010', 'Ram Singh', '20000', '43', 'A',NULL);
insert into employee1 values('e020', 'Hari Lal', '10000', '49', 'A',NULL);
insert into employee1 values('e030', 'Shanti Devi', '30000', '32', 'C',NULL);
insert into employee1 values('e040', 'Ram Lal', '10000', '54', 'B',NULL);
insert into employee1 values('e050', 'Alia Raj', '20000', '33', 'B',NULL);
update Employee1 set phone_no='8564971620' where userName='e010';
update Employee1 set phone_no='7342456789' where userName='e020';
update Employee1 set phone_no='9865628750' where userName='e030';
update Employee1 set phone_no='3321567890' where userName='e040';
update Employee1 set phone_no='2341546789' where userName='e050';

insert into agreement values('o111', 't001');
insert into agreement values('o111', 't002');
insert into agreement values('o112', 't003');
insert into agreement values('o113', 't004');
insert into agreement values('o112', 't005');

update Tenant set phone_no='8008097162' where userName='t001';
update Tenant set phone_no='8123456789' where userName='t002';
update Tenant set phone_no='8234562875' where userName='t003';
update Tenant set phone_no='1234567890' where userName='t004';
update Tenant set phone_no='2341546789' where userName='t005';

insert into rental values(('2022-06-01'), '72000', 't001', '2902');

insert into rental values(('2023-01-10'), '15000', 't002', '003');
insert into rental values(('2022-04-20'), '25000', 't003', '304');
insert into rental values(('2023-01-01'), '35000', 't004', '702');
insert into rental values(('2021-01-01'), '37000', 't005', '703');

select * from Signin;
select * from Tenant;
select * from Owner_Table;
select * from Employee1;
select * from agreement;
select * from apartment;
select * from building;
select * from rental;

select Tenant.*, rental.apartment_no, apartment.building_name from Tenant join rental natural join apartment ;

select tenant.*, rental.apartment_no, apartment.building_name from tenant 
join rental on rental.tenant_id=tenant.userName
join apartment on apartment.Apartment_no = rental.apartment_no;

SELECT a.apartment_no, a.building_name, a.parking_sapce, r.date_of_renting, r.monthly_rent, a.design, a.floor_no
    FROM apartment a
    INNER JOIN rental r ON a.apartment_no = r.apartment_no
    INNER JOIN Tenant t ON r.Tenant_id = t.userName
    WHERE t.userName = 't005';





Go 
create procedure myproc 
	@username varchar(50),
	@password varchar(30) output
	as
	begin
	select @password = pass from Signin where @username = username;
	PRINT @pass;
end

set serveroutput on;
DECLARE @user varchar(50) = 'e050';
DECLARE @pass varchar(30);

EXECUTE myproc @user, @pass;
PRINT @pass;

create procedure myproc2  
@naam varchar(50)
as
begin
print 'Hello';
end;
