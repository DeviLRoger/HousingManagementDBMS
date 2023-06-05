
create database apartment1DB;

use apartment1DB;


create table Signin(
username varchar(30),
pass     varchar(30),
primary key(username));

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

create table Tenant(
userName varchar(30),
Tenant_Name varchar(30),
aadhar_ID varchar(30),
phone_no varchar(15),
primary key(userName),
foreign key(userName) references Signin(username) on delete cascade on update cascade);

insert into tenant values('t001', 'Rahul Sharma', '876019238', '8008097162');
insert into tenant values('t002', 'Aditya Singh', '93756289', '8123456789');
insert into tenant values('t003', 'Neha Patel', '91245698','8234562875' );
insert into tenant values('t004', 'Adrika Shah', '67753298', '1234567890');
insert into tenant values('t005', 'Raj Singhania', '68956201', '2341546789');

create table building(
Building_name varchar(20),
primary key(Building_name)
);

insert into building values('A');
insert into building values('B');
insert into building values('C');
Insert into building values('D');
Insert into building values('E');
Insert into building values('F');
Insert into building values('G');

create table apartment(
occupancy_status varchar(30),
Apartment_no     int,
design           varchar(20),
Floor_no         int,
Building_name         varchar(20),
parking_sapce    varchar(20),
primary key (Apartment_no),
foreign key (Building_name) references building(Building_name) on delete cascade on update cascade);

insert into apartment values('Vacant', '703', '3BHK', 7, 'A', 'A-703');
insert into apartment values('Occupied', '2902', '5BHK', 29, 'C', 'C-2902');
insert into apartment values('Occupied', '003', '1BHK', 0, 'A', 'A-003');
insert into apartment values('Vacant', '304', '2BHK', 2, 'B', 'B-304');
insert into apartment values('Vacant', '702', '3BHK', 7, 'A', 'A-702');
insert into apartment values('Vacant','514','3BHK',5,'D','D-514');
insert into apartment values('Vacant','114','2BHK',1,'D','D-114');
insert into apartment values('Vacant','501','4BHK',5,'E','E-501');
insert into apartment values('Vacant','211','3BHK',2,'E','E-211');
insert into apartment values('Vacant','221','5BHK',2,'F','F-221');
insert into apartment values('Vacant','601','3BHK',6,'F','F-601');
insert into apartment values('Vacant','115','2BHK',1,'G','G-115');
insert into apartment values('Vacant','412','5BHK',4,'G','G-412');

create table Owner_Table(
userName varchar(30),
Owner_Name varchar(30),
apartment_no  int, 
aadhar_ID varchar(30),
building_name varchar(20),
primary key(userName,apartment_no),
phone_no varchar(15),
foreign key(apartment_no) references apartment(Apartment_no) on delete cascade on update cascade,
foreign key(userName) references Signin(username) on delete cascade on update cascade,
foreign key (Building_name) references building(Building_name));


insert into owner_table values('o111', 'Kapil Sharma', '2902', '86590321', 'C','2341546789');
insert into owner_table values('o111', 'Kapil Sharma', '514', '86590321', 'E','2341546789');
insert into owner_table values('o111', 'Kapil Sharma', '501', '86590321', 'C','2341546789');
insert into owner_table values('o112', 'Rahul Raj', '703', '785672912', 'A','8723456789');
insert into owner_table values('o112', 'Rahul Raj', '114', '785672912', 'D','8723456789');
insert into owner_table values('o112', 'Rahul Raj', '211', '785672912', 'E','8723456789');
insert into owner_table values('o113', 'Aryan Shirke', '304', '210967892','B','9745628750');
insert into owner_table values('o113', 'Aryan Shirke', '221', '210967892','F','9745628750');
insert into owner_table values('o113', 'Aryan Shirke', '115', '210967892','G','9745628750');
insert into owner_table values('o113', 'Aryan Shirke', '601', '210967892','F','9745628750');
insert into owner_table values('o114', 'Tanmay Gupta', '702', '86590321','A','1209567890');
insert into owner_table values('o114', 'Tanmay Gupta', '412', '86590321','G','1209567890');
insert into owner_table values('o115', 'Aditya Nair', '003', '121347654', 'A','6341546789');

create table Employee1(
userName  varchar(30),
Emp_name  varchar(30),
Salary    int,
Building_name varchar(20),
phone_no varchar(15),
primary key(userName),
foreign key(Building_name) references building(Building_name));

insert into employee1 values('e010', 'Ram Singh', '20000','A','8564971620');
insert into employee1 values('e020', 'Hari Lal', '10000','A','7342456789');
insert into employee1 values('e030', 'Shanti Devi', '30000','C','9865628750');
insert into employee1 values('e040', 'Ram Lal', '10000','B','3321567890');
insert into employee1 values('e050', 'Alia Raj', '20000','B','2341546789');

create table agreement(
Owner_id     varchar(30),
tenant_id    varchar(30),
apartment_no int,
primary key(Owner_id,tenant_id),
foreign key(Owner_id,apartment_no) references Owner_Table(userName,apartment_no) ,
foreign key(tenant_id) references Tenant(userName) on delete cascade on update cascade);

select * from apartment;

select * from Owner_Table;

select * from Tenant;

update apartment set occupancy_status='Occupied' where Apartment_no in ('304','702','703');

insert into agreement values('o111', 't001','2902');
insert into agreement values('o115', 't002','003');
insert into agreement values('o113', 't003','304');
insert into agreement values('o114', 't004','702');
insert into agreement values('o112', 't005','703');

create table rental(
Date_of_Renting  date,
Monthly_rent     int,
Tenant_id      varchar(30),
apartment_no   int,
primary key(Tenant_id,apartment_no),
foreign key(Tenant_id) references Tenant(userName) on delete cascade on update cascade,
foreign key(apartment_no) references apartment(Apartment_no) on delete cascade on update cascade);

insert into rental values('2022-06-01', '72000', 't001', '2902');
insert into rental values('2023-01-10', '15000', 't002', '003');
insert into rental values('2022-04-20', '25000', 't003', '304');
insert into rental values('2023-01-01', '35000', 't004', '702');
insert into rental values('2021-01-01', '37000', 't005', '703');

create table complaint(
complaint_no    int Identity(1,1),
building_name   varchar(20),
Complaint       varchar(30),
Complaint_Status  varchar(20),
primary key(complaint_no),
foreign key(building_name) references building(building_name) on delete cascade on update cascade);

insert into complaint values ('A','Leakage',NULL);
insert into complaint values ('A','Water Problem',NULL);
insert into complaint values ('B','Fungus',NULL);
insert into complaint values ('C','Termite issues',NULL);
insert into complaint values ('C','Beehive outside gate entrance',NULL);

alter table Employee1 ADD CONSTRAINT fk_empSignin foreign key(userName) references Signin(username);

-- owner_table pk(userName,apartment_no)
-- agreement add apartment_no int

select * from employee1;

select * from Owner_Table;
select * from apartment;
update Owner_Table set building_name = 'E' where apartment_no=501;
update Owner_Table set building_name = 'D' where apartment_no=514;


select * from Signin;

select * from agreement;

insert into Signin values('e999','employee');

insert into Employee1 values('e999','Shivam',50000,'C','9867434006');

/*create procedure getTenantByOwner
    @ownerUsername varchar(50)
AS
BEGIN
    SELECT t.*
    FROM Tenant t
    JOIN agreement a ON t.userName = a.tenant_id
    JOIN Owner_Table o ON a.Owner_id = o.userName
    WHERE o.userName = @ownerUsername
END*/
drop procedure getTenantByOwner;

create procedure getTenantByOwner
    @ownerUsername varchar(50)
AS
BEGIN
    select t.* 
	from Tenant t
	where t.userName in (select tenant_id from agreement where Owner_id=@ownerUsername);
END

select t.* 
from Tenant t
where t.userName in (select tenant_id from agreement where Owner_id='o111');

/*select * from Tenant;
select * from agreement;
select * from Owner_Table;
SELECT t.*
    FROM Tenant t
	JOIN Owner_Table o ON a.Owner_id = o.userName
    JOIN agreement a ON t.userName = a.tenant_id
    
    WHERE o.userName = 'o111';

execute getTenantByOwner 'o111';
*/

CREATE PROCEDURE GetApartmentDetailsofOwner
  @pUserName VARCHAR(30)
AS
BEGIN
  SELECT a.occupancy_status, a.Apartment_no, a.design, a.Floor_no, a.Building_name, a.parking_sapce
  FROM Apartment a
  INNER JOIN Owner_Table t ON a.Apartment_no = t.apartment_no
  WHERE t.userName = @pUserName;
END;

GO
CREATE PROCEDURE InsertNewTenant
    @username varchar(30),
    @Tenant_Name varchar(30),
    @aadhar_ID varchar(30),
    @Apartment_no int,
    @Owner_id varchar(30),
    @Monthly_rent int,
    @Phone_no varchar(30),
	@building_name varchar(10)
AS
BEGIN
    SET NOCOUNT ON;
    
    
    -- Insert the new tenant into the Tenant table
    INSERT INTO Tenant (userName, Tenant_Name, aadhar_ID, Phone_no)
    VALUES (@username, @Tenant_Name, @aadhar_ID, @Phone_no);
    
    -- Update the occupancy status of the apartment to "occupied"
    UPDATE apartment
    SET occupancy_status = 'occupied'
    WHERE Apartment_no = @Apartment_no and building_name=@building_name;
    
    -- Update the rental table with the new tenant's information
    INSERT INTO rental (Date_of_Renting, Monthly_rent, Tenant_id, apartment_no)
    VALUES (GETDATE(), @Monthly_rent, @username, @Apartment_no);
    
    -- Update the agreement table with the new tenant's and owner's information
    INSERT INTO agreement (Owner_id, tenant_id)
    VALUES (@Owner_id, @username);
END

-- Admin >> Owner details
SELECT o.Owner_Name, o.aadhar_ID, COUNT(*) as no_of_apartments 
FROM Owner_Table o, apartment a 
where o.apartment_no = a.Apartment_no AND o.building_name = a.Building_name 
GROUP BY o.Owner_Name, o.aadhar_ID


-- Tenant >> my details
GO
	CREATE PROCEDURE GetTenantDetails
    @tenant_id varchar(30)
AS
BEGIN
    SET NOCOUNT ON;

    -- Get the tenant details
    SELECT Tenant_Name, aadhar_ID, Phone_no, rental.Apartment_no, Monthly_rent
    FROM Tenant
    INNER JOIN rental ON Tenant.userName = rental.Tenant_id
    INNER JOIN agreement ON Tenant.userName = agreement.tenant_id
    WHERE Tenant.userName = @tenant_id;
END
execute GetTenantDetails 't001';

CREATE PROCEDURE GetApartmentDetailsOfTenant
    @username VARCHAR(30)
AS
BEGIN
    SELECT a.Apartment_no, a.Building_name, a.occupancy_status,a.design,a.Floor_no,a.parking_sapce
    FROM apartment a
    INNER JOIN rental r ON a.Apartment_no = r.apartment_no
    WHERE r.Tenant_id = @username;
END
execute GetApartmentDetailsOfTenant 't001';

CREATE PROCEDURE GetOwnerDetailsOfTenant
    @username VARCHAR(30)
AS
BEGIN
    SELECT top 1 o.Owner_Name, o.aadhar_ID, o.phone_no
    FROM Owner_Table o
    INNER JOIN agreement a ON o.userName = a.Owner_id
    WHERE a.Tenant_id = @username;
END

SELECT o.Owner_Name, o.aadhar_ID, o.phone_no
    FROM Owner_Table o
    INNER JOIN agreement a ON o.userName = a.Owner_id
    WHERE a.Tenant_id = 't001';

select * from Owner_Table;

drop procedure GetOwnerDetailsOfTenant;
-- if wanna see only count of apartments then we can add count so only
execute GetOwnerDetailsOfTenant 't001';

select * from signin;

CREATE PROCEDURE UpdateComplaintStatus
  @pcomplaint_no VARCHAR(20),
  @pStatus VARCHAR(30)
AS
BEGIN
  UPDATE complaint
  SET Complaint_status = @pStatus
  WHERE complaint_no = @pcomplaint_no;
END;
-- execute UpdateComplaintStatus ;

select * from Tenant;

select * from Signin;

update Tenant set aadhar_ID='87601923' where userName='t001';

select * from complaint;



drop procedure InsertNewTenant;

update Tenant set Tenant_Name='Shivam Mishra' where userName='t006';

GO
CREATE PROCEDURE InsertNewTenant
    @username varchar(30),
    @Tenant_Name varchar(30),
    @aadhar_ID varchar(30),
    @Apartment_no int,
    @Owner_id varchar(30),
    @Monthly_rent int,
    @Phone_no varchar(30),
	@building_name varchar(10)
AS
BEGIN
    SET NOCOUNT ON;
    
    
    -- Insert the new tenant into the Tenant table
    INSERT INTO Tenant (userName, Tenant_Name, aadhar_ID, Phone_no)
    VALUES (@username, @Tenant_Name, @aadhar_ID, @Phone_no);
    
    -- Update the occupancy status of the apartment to "occupied"
    UPDATE apartment
    SET occupancy_status = 'occupied'
    WHERE Apartment_no = @Apartment_no and building_name=@building_name;
    
    -- Update the rental table with the new tenant's information
    INSERT INTO rental (Date_of_Renting, Monthly_rent, Tenant_id, apartment_no)
    VALUES (GETDATE(), @Monthly_rent, @username, @Apartment_no);
    
    -- Update the agreement table with the new tenant's and owner's information
    INSERT INTO agreement (Owner_id, tenant_id,apartment_no)
    VALUES (@Owner_id, @username,@Apartment_no);
END

select * from agreement;
select * from rental;
select * from tenant;
select * from apartment;
select * from Owner_Table;

insert into Signin values('t007','tenant');

EXEC InsertNewTenant 
    @username = 't007', 't008'
    @Tenant_Name = 'Yatharth Srivastava', 'Nishka Kulshreshtha'
    @aadhar_ID = '90188234',  '98234984'
    @Apartment_no = 114, '601'
    @Owner_id = 'o112', 'o113'
    @Monthly_rent = 5000, 10000
    @Phone_no = '9876125038', '2437823476'
	@Building_name='D'; 'F' 
	+

delete from complaint where complaint_no='6';
delete from employee1 where userName='e060';
update complaint set building_name='E' where complaint_no=2;
update apartment set occupancy_status='Vacant' where Apartment_no in ('114');

insert into apartment values('Vacant','901','2BHK',1,'A','A-901');
insert into apartment values('Vacant','902','3BHK',3,'B','B-902');
insert into apartment values('Vacant','903','1BHK',10,'D','D-903');
insert into apartment values('Vacant','905','5BHK',5,'F','F-905');