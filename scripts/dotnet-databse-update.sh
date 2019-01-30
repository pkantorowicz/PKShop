#!/bin/bash
cd src
cd PKShop.Struct.WriteData

    echo ========================================================
    echo Update EventStoreContext
    echo ========================================================

dotnet ef database update --startup-project ../PKShop.Web/PKShop.Web.csproj --context EventStoreContext

    echo ========================================================
    echo Update PKShopContext
    echo ========================================================

dotnet ef database update --startup-project ../PKShop.Web/PKShop.Web.csproj --context PKShopContext

cd ..
cd PKShop.Common.Identity

    echo ========================================================
    echo Update ApplicationDbContext
    echo ========================================================

dotnet ef database update --startup-project ../PKShop.Web/PKShop.Web.csproj --context ApplicationDbContext