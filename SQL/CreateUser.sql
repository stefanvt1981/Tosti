CREATE USER TostiDbUser WITH PASSWORD = 'Tosti123!';

ALTER ROLE db_datawriter ADD MEMBER TostiDbUser

ALTER ROLE db_owner ADD MEMBER TostiDbUser