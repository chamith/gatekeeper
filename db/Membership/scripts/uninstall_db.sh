echo generating the tables.sql file

cat uninstall/tables/*.sql > tables.sql

echo done generating the tables.sql file

echo generating the constraints.sql file

cat uninstall/constraints/*.sql > constraints.sql

echo done generating the constraints.sql file

echo generating the sprocs.sql file

# cat ../sprocs/business/*.sql ../sprocs/crud/*.sql  > sprocs.sql

#echo done generating the sprocs.sql file

echo generating the all_install.sql file

cat constraints.sql tables.sql > all_uninstall.sql

echo done generating the all_uninstall.sql file

echo deleting tables.sql constraints.sql

rm tables.sql constraints.sql

echo done deleting tables.sql constraints.sql

echo Creating the tables, constraints, sprocs in DB

mysql -f -v -u root -p Membership < all_uninstall.sql

echo deleting all_uninstall.sql

rm all_uninstall.sql

echo done deleting all_uninstall.sql

echo Done... 

