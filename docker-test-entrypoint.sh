#!/bin/sh

dotnet test --no-restore --test-adapter-path:. --logger:"nunit;LogFilePath=test-result.xml" \
            ./Rodonaves.Billing.Test/Rodonaves.Billing.Test.csproj /p:CollectCoverage=true \
            /p:MergeWith="./billing-bll-test-coverage.json" /p:CoverletOutputFormat=\"opencover,cobertura\"