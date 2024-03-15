# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY . .
# Timezone
RUN apk add tzdata
RUN apk add --no-cache icu-libs
# Globalization
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV LANG pt_BR.UTF-8 \
    LANGUAGE pt_BR.UTF-8 \
    LC_ALL pt_BR.UTF-8

ENTRYPOINT ["dotnet", "API.dll"]
