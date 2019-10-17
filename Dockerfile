FROM mcr.microsoft.com/dotnet/core/aspnet
				
COPY  WebApplication1/bin/Release/netcoreapp2.1/ /app
WORKDIR /app
EXPOSE 80
CMD ["dotnet", "WebApi.dll"]
#gdjewjhjewghvhvhjdfnkwnekfnesrnfre
