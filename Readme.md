docker sql server commands

install sql server container
docker pull mcr.microsoft.com/mssql/server

running container
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password123" -p 1433:1433 --name sql_server_container -d mcr.microsoft.com/mssql/server
