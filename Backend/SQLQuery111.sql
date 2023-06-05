

use apartmentDB;

create table tenanttable (
username varchar(30),
pass varchar (30)
);

insert into tenanttable values('9999','9999tenantpwd');

create table ownertable (
username varchar(30),
pass varchar (30)
);

insert into ownertable values('9999','9999ownerpwd');

create table employeetable (
username varchar(30),
pass varchar (30)
);

insert into employeetable values('9999','9999employeepwd');


create table nameoo(
DOB date,
naam varchar(20)
);

insert into nameoo values(to_date '2022-10-10','shivam');
