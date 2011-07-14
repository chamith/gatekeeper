drop database gatekeeper;
drop user 'app_gatekeeper'@'%';
create database gatekeeper;
create user 'app_gatekeeper'@'%' identified by '1qaz2wsx@';
grant select, execute on *.* to 'app_gatekeeper'@'%';
use gatekeeper;
