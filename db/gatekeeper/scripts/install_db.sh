echo generating the tables.sql file

cat install/tables/*.sql > tables.sql

echo done generating the tables.sql file

echo generating the constraints.sql file

cat install/constraints/*.sql > constraints.sql

echo done generating the constraints.sql file

echo generating the sprocs.sql file

cat ../sprocs/business/*.sql ../sprocs/crud/*.sql  > sprocs.sql

echo done generating the sprocs.sql file

echo generating the all_install.sql file

cat tables.sql constraints.sql sprocs.sql > all_install.sql

echo done generating the all_install.sql file

echo deleting tables.sql constraints.sql sprocs.sql

rm tables.sql constraints.sql sprocs.sql

echo done deleting tables.sql constraints.sql sprocs.sql

echo Creating the tables, constraints, sprocs in DB

mysql -f -v -u root -p gatekeeper < all_install.sql

echo deleting all_install.sql

rm all_install.sql

echo done deleting all_install.sql

echo Done... 

