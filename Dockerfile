FROM microsoft/dotnet:2.0-runtime

# Default Environment
ENV ASPNETCORE_ENVIRONMENT="Development"

# Args
ARG distFolder=IpInfo.Api/bin/Release/netcoreapp2.0
ARG apiProtocol=http
ARG apiPort=505
ARG appFile=IpInfo.Api.dll

# Copy files to /app
RUN ls
COPY ${distFolder} /app
 
# Expose port for the Web API traffic
ENV ASPNETCORE_URLS ${apiProtocol}://+:${apiPort}
EXPOSE ${apiPort}

# Run application
WORKDIR /app
RUN ls
ENV appFile=$appFile
ENTRYPOINT dotnet $appFile