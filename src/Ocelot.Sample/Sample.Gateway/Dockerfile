FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app/sample.gateway
COPY . .
#EXPOSE 80

ENTRYPOINT ["dotnet", "Sample.Gateway.dll"]