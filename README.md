# Monolith2MicroservicesKata

## Purpose
Purpose of this kata is to extract microservices from the Monolith. The code is still under construction.

## Setup
- Postgres SQL

## situation
Gilded rose has it's webshop online, so people all over Stormwind city can order from their homes. Due to the high demands the current system is becoming unstable. Scaling the current monolith no longer is a viable option.

At first we split of Product presentation which takes the highest loads, customers browsing through our collection. This gave us some breathing space so we could scale further. However, the next bottleneck is starting to show, which is the basket and checkout and the warehouse.
We decided that we should extract the Basket and checkout service first. We expect that this extraction would reduce load on the monolith as a whole and because of that, the remaining warehouse logic will also improve performance and stability.

As an extra, once we have the basket extracted, we can start adding features to attract more customers without destabilizing our service. Stuff like coupons and discounts.


## Simulation
The kata starts with a running instance of the Monolith.

### Simulated Customer Journey
Simulation code will be running the following customer journey
1. Add 1-3 random item(s) to the basket which is available in stock
1. Checkout the basket which creates an order (the customer gets notified of the order being paid and delivered)
1. Order will be handled by an order picker
1. Goods will delivered to a 3rd party delivery provider (the customer gets notified of the order being )


### Simulation processes
Besides kicking of customerjourneys, the simulation service will execute the following 2 processes.

Every 10 seconds the simulation will kickoff a proces to handle day2day operations. The will simulate handling the created orders. 'employers' will pick the orders and send them off to the customers. This needs to be simulated and it's done in the day2day opretaions call. Also when stock is low, new goods should be ordered. As the industry has moved to sameday delivery, the goods will be delived the next day2day simulation tick.

Every 6 iterations the simulation will kickoff a process which updatesthe quality of the inventory in the warehouse. Goods will perish in time, and will be removed from the warehouse.


### Solution
To help you with the first step of refactoring, some infrastructure is already set in place.
1. Content Router. This one is needed to route traffic coming from the client to the monolith, and based on some rules, will route the traffic to the extraced microservices
1. ...

The solution contains a couple of basic modules and code and is by far complete. The purpose of this Kata is to excercise with extracting code into new services, and get a feeling on some of the possible patterns you could use.

The base code of Gilded rose is added to the solution, so if you would like to just refactor this big ball of mud, go right ahead. However, i would advise you to get the original kata. See credits below for the link.

## Patterns to use in this Kata
1. Strangler Fig
1. Branch by abstraction
1. Content-based-router
1. Parallel run??
1. Change Data Capture

## scratch notes
add migration in warehouse infra project:

run the following command from Monolith.API folder
dotnet ef migrations add add-count-for-inventory  -c WarehouseDbContext -p ..\Monolith.Warehouse.Infra -o Migrations

## Credits 

Code in the warehouse assembly is a direct copy from Emily Bache refactor Kata Gilded Rose. The original code can be found at the following location: https://github.com/emilybache/GildedRose-Refactoring-Kata