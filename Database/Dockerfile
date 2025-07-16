FROM mysql/mysql-server:latest

# this is necessary, otherwise the initial seeding with insert cities cannot handle czech characters, as it thinks, that the script is in ascii, not in utf-8 
ENV LANG=C.UTF-8

# for setting up the czech collation, so it can handle czech characters
COPY my.cnf /etc/mysql/conf.d/my.cnf
COPY 01-init-schema.sql 02-insert-cities.sql 03-StateOfItem.sql 04-Categories.sql 05-ListingProperties.sql 06-ListingPropertyValues.sql 07-CategoryListingProperty.sql /docker-entrypoint-initdb.d/