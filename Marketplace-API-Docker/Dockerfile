FROM mysql:5.7.22
EXPOSE 3306
COPY ./Marketplace-API/db/backup /home/database
COPY ./Marketplace-API/ci /docker-entrypoint-initdb.d/init_database.sh