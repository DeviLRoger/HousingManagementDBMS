select * from Signin;

delete from Signin where pass='o123';

delete from Owner_Table where userName='Owner';

select * from building;

select * from rental;

select * from Employee1;

select * from agreement;

select * from Owner_Table;

select * from apartment;

select * from Tenant;

create table complaint(
complaint_no    int Identity(1,1),
building_name   varchar(20),
Complaint       varchar(30),
Complaint_Status  varchar(20),
primary key(complaint_no),
foreign key(building_name) references building(building_name) on delete cascade on update�cascade);

alter table building drop column complaint;


insert into complaint values ('A','Leakage',NULL);
insert into complaint values ('A','Water Problem',NULL);
insert into complaint values ('B','Fungus',NULL);
insert into complaint values ('C','Termite issues',NULL);
insert into complaint values ('C','Beehive outside gate entrance',NULL);

select * from complaint;

CREATE PROCEDURE UpdateComplaintStatus
  @pcomplaint_no VARCHAR(20),
  @pStatus VARCHAR(30)
AS
BEGIN
  UPDATE complaint
  SET Complaint_status = @pStatus
  WHERE complaint_no = @pcomplaint_no;
END;


GO
	CREATE PROCEDURE GetTenantDetails
    @tenant_id varchar(30)
AS
BEGIN
    SET NOCOUNT ON;

    -- Get the tenant details
    SELECT Tenant_Name, aadhar_ID, age, Phone_no, Apartment_no, Monthly_rent
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
    SELECT a.Apartment_no, a.Building_name, a.occupancy_status
    FROM apartment a
    INNER JOIN rental r ON a.Apartment_no = r.apartment_no
    WHERE r.Tenant_id = @username;
END

drop procedure GetApartmentDetailsOfTenant;

CREATE PROCEDURE GetApartmentDetailsOfTenant
    @username VARCHAR(30)
AS
BEGIN
    SELECT a.Apartment_no, a.Building_name, a.occupancy_status,a.design,a.Floor_no,a.parking_sapce
    FROM apartment a
    INNER JOIN rental r ON a.Apartment_no = r.apartment_no
    WHERE r.Tenant_id = @username;
END

CREATE PROCEDURE GetOwnerDetailsOfTenant
    @username VARCHAR(30)
AS
BEGIN
    SELECT o.Owner_Name, o.aadhar_ID, o.phone_no,o.apartment_no
    FROM Owner_Table o
    INNER JOIN agreement a ON o.userName = a.Owner_id
    WHERE a.Tenant_id = @username;
END

drop procedure getTenantByOwner;

create procedure getTenantByOwner
    @ownerUsername varchar(50)
AS
BEGIN
    SELECT t.*
    FROM Tenant t
    JOIN agreement a ON t.userName = a.tenant_id
    JOIN Owner_Table o ON a.Owner_id = o.userName
    WHERE o.userName = @ownerUsername
END

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
    @pass varchar(30),
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
    
    -- Insert the new user into the Signin table
    INSERT INTO Signin (username, pass)
    VALUES (@username, @pass);
    
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

EXEC InsertNewTenant 
    @username = 't006', 
    @pass = 'tenant', 
    @Tenant_Name = 'Ramya Sharma', 
    @aadhar_ID = '9018278234', 
    @age = 37, 
    @Apartment_no = 304,
    @Owner_id = 'o115',
    @Monthly_rent = 35000,
    @Phone_no = '9876125038',
	@Building_name='B';


drop procedure InsertNewTenant;

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


insert into Signin values('t006','Tenant');
EXEC InsertNewTenant 
    @username = 't006', t99987
    @Tenant_Name = 'Ramya Sharma', 'sdasa'
    @aadhar_ID = '9018278234',  --
    @Apartment_no = 702, 703
    @Owner_id = 'o114', o112
    @Monthly_rent = 35000, --
    @Phone_no = '9876125038', --
	@Building_name='A'; 'A'

