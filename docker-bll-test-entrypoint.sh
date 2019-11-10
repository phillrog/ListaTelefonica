#!/bin/sh

dotnet test --no-restore --test-adapter-path:. --logger:"nunit;LogFilePath=test-result.xml" \
            ./Rodonaves.Billing.Bll.Test/Rodonaves.Billing.Bll.Test.csproj /p:CollectCoverage=true