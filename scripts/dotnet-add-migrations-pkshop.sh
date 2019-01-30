#!/bin/bash
MIGRATION_NAME=""

cd src
cd PKShop.Struct.WriteData

    echo ========================================================
    echo Added migration PKShopContext
    echo ========================================================

dotnet ef migrations add $MIGRATION_NAME --startup-project ../PKShop.Web/PKShop.Web.csproj --context PKShopContext