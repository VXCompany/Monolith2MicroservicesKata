# Pattern: Branch by Abstraction

With the strangler fig pattern, we intercepte traffic on the perimeter of our system and moved it to a new microservice. In this Kata we used the ApiGateway to do this routing for us.

However, if we want to extract a piece of logic into a service which isn't at the perimeter of our system, then we need another pattern.
Branch by Abstraction is a pattern which can help extract internal logic.

Branch by abstraction roughly works as follows:
1. Create an abstraction for the logic you want to extract.
1. Change the cliënts of the existing functionality to use the new abstraction
1. Create a new implementation replacing the old functionality
1. Switch the abstraction to use the new implementation
1. Clean up the abstraction and remove the old implementation

## Exercise: extract Notification service 

The owner of the 