#!/bin/bash
MIGRATION_NAME=""

cd src
cd PKShop.Common.Identity

    echo ========================================================
    echo Added migration ApplicationDbContext
    echo ========================================================

dotnet ef migrations add $MIGRATION_NAME --startup-project ../PKShop.Web/PKShop.Web.csproj --context ApplicationDbContext