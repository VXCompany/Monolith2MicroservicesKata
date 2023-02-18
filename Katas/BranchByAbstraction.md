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

Step 1: Create an abstraction

Find the boundary of the notification service. Create an abstraction for this boundary. Define the methods in this abstraction which will service the functionality.

Step 2: Change the cliënts of the existing functionality


Step 3: Create a new implementation

Step 3.1: Duplicate the notification logic into the notifications service and make sure the endpoints are working

Step 3.2: Create a new implementation which will call the proper endpoints

Step 4: Switch the abstraction to use the new implementation

If you want to be bold, use a feature toggle to darklaunch the new notification service. You might want to route traffic of al customernumers ending with '1'. This way you can test the load. In an enterprise setting you might decide to 'parallel run' the new service by calling both the old and new functionality and validate the output of each functionality. This is a form of production testing which might help you validate the logic and give control on when to go live.


Step 5: Clean up the old code

Remove the old logic from the monolith. Finish with removing the abstraction.