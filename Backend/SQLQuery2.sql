select * 
from Tenant 
where Tenant.userName in (
select tenant_id 
from agreement, Owner_Table 
where Owner_Table.userName='o111');

select * 
from Tenant 
where Tenant.userName in (
select tenant_id 
from agreement, Owner_Table 
where agreement.Owner_id=Owner_Table.userName and Owner_Table.userName='o111');

select * from Signin;

select * from Owner_Table;

select * from apartment;

select * from rental;

select * from agreement;

select * from Tenant;

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

EXEC getTenantByOwner @ownerUsername = 'o111';

select * from Employee1;