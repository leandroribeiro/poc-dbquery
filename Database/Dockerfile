FROM mcr.microsoft.com/mssql/server

USER root

ENV CHECK_POLICY=OFF
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Dev123456789
ENV MSSQL_PID=Developer

CMD ["/opt/mssql/bin/sqlservr"]
