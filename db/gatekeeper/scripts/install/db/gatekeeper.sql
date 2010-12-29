create database gatekeeper;
create user 'app_gatekeeper'@'%' identified by '1qaz2wsx@';
grant select, execute on *.* to 'app_gatekeeper'@'%';
use gatekeeper;
