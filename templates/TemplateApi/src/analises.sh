#!/bin/bash

APPLICATION="teste2"
SONAR_TOKEN="sqp_82ab2ad36f5bb913da89c81a487c97af078c855e"

echo "Iniciando as Análises do Sonar e do Coverlat..."

# dotnet tool install dotnet-sonarscanner -g
# dotnet tool install dotnet-reportgenerator-globaltool -g

echo "Iniciando Sonar..."

dotnet sonarscanner begin -k:$APPLICATION -d:sonar.host.url="http://localhost:9000" -d:sonar.token=$SONAR_TOKEN

echo "Compilando a aplicação..."
dotnet build

echo "Removendo o relatorio de teste anterior..."
rm -R ./.coverage

echo "Rodando os testes do projeto..."
dotnet test --collect:"XPlat Code Coverage" --results-directory:"./.coverage"

echo "Gerando o novo relatório dos testes..."
reportgenerator "-reports:.coverage/**/*.cobertura.xml" "-targetdir:.coverage-report/" "-reporttypes:HTML;"

dotnet sonarscanner end -d:sonar.token=$SONAR_TOKEN

echo "Fim das análises!!!"

start ./.coverage-report/index.html