FROM mcr.microsoft.com/dotnet/core/aspnet
				
COPY  WebApplication1/bin/Release/netcoreapp2.1/publish /app
WORKDIR /app
EXPOSE 80
CMD ["dotnet", "WebApi.dll"]
#gdjewjhjewhjekkndcjwnsjnwjnw
