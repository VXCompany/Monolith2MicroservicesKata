# Monolith2MicroservicesKata

## Purpose
Purpose of this kata is to extract microservices from the Monolith. The code is still under construction.


## scratch notes
add migration in warehouse infra project:

run the following command from Monolith.API folder
dotnet ef migrations add add-count-for-inventory  -c WarehouseDbContext -p ..\Monolith.Warehouse.Infra -o Migrations

## Credits 

Code in the warehouse assembly is a direct copy from Emily Bache refactor Kata Gilded Rose. The original code can be found at the following location: https://github.com/emilybache/GildedRose-Refactoring-Kata