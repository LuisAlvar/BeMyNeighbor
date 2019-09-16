#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS BeMyNeighborBuildStage
WORKDIR /aspnetmvc
COPY ["BeMyNeighbor.MVCClient/BeMyNeighbor.MVCClient.csproj", "BeMyNeighbor.MVCClient/"]
# /root/aspnetmvc/BeMyNeighbor.MVCClient -> created this directory based on the previous step
# restore /root/aspnetmvc/BeMyNeighbor.MVCClient/BeMyNeighbor.MVCClient.csproj
RUN dotnet restore BeMyNeighbor.MVCClient/BeMyNeighbor.MVCClient.csproj
COPY . .
WORKDIR /aspnetmvc/BeMyNeighbor.MVCClient
RUN dotnet build BeMyNeighbor.MVCClient.csproj

FROM BeMyNeighborBuildStage AS BeMyNeighborPublishStage
RUN dotnet publish BeMyNeighbor.MVCClient.csproj --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /deploy
COPY --from=BeMyNeighborPublishStage /app .
CMD ["dotnet", "BeMyNeighbor.MVCClient.dll"]
