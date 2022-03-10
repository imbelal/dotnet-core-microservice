# DOT NET Core microservice with onion architechture 
This project has been developed with a simple goal. Having multiple microservices with a seperate database for each.
We also have a central getway web api to make easy communication between client application and backend micro services.
<br>
Okay, lets understand onion architecture by comparing it with N-Layer architecture from below diagram.

<table>
  <tr>
    <th width="320">N-Layer</th>
    <th width="320">Onion</th>
  </tr>
</table>
<p float="left">
  <img src="https://github.com/belal55/dotnet-core-microservice/blob/master/Docs/N-Layer-Architecture.png" height="330" alt="N-Layer-Architecture.png" />
<img src="https://github.com/belal55/dotnet-core-microservice/blob/master/Docs/onionArchitecture.png" height="330" alt="onionArchitecture.png" />
</p>
<br>

To understand the advantage with onion architecture over n-layer, we have understand the issues with n-layer architecutre. As we can see from above diagram, in N-Layer architecture everything is havily dependent on database. It means database is the core of the architecutre. Its a great issue when we want to develop a scalable application for real world business. Becasue we have to develope an application which has to focus on the business domain to automate the business. It means our application has to be focused on business domain. And obhously in future we can change our database technologoy. As a result we have to develop our application in such a way that we change technology like database or user interface whenever needed without changing business domain. That's the why reason modern architecutre are highly depended on [DDD (Domain-driven design)](https://en.wikipedia.org/wiki/Domain-driven_design). Onion architecutre is also based on DDD. 
<br>
Well, well, well
<br>
## Why microservice?
As like before lets compare microservice with monolith architecture 


<table>
  <tr>
    <th width="380">Monolith</th>
    <th width="600">Microservice</th>
  </tr>
</table>
<p float="left">
<img src="https://github.com/belal55/dotnet-core-microservice/blob/master/Docs/monolith-architecutre.png" height="330" alt="monolith-architecutre.png" />
<img src="https://github.com/belal55/dotnet-core-microservice/blob/master/Docs/microservice-architecture.png" height="330" width="600" alt="microservice-architecture.png" />
</p>
<br>
In a simple language, in monolith architecture layeriing means creating sub-folders in a single solution. It means whatever layering we applied, at the end we are in a single a solution. Its easy deploy and easy to maintain. That's why it so popular. But there are some great issues also which can make more pain in the long run. For example a single change in a monolith application will end up deploying whole application which means the whole application will go through the testing phases again. It's hideous  situation for a devops team. Aslo maintaing monolith lage domain application is painful for developers. 
<br>
Now let's understand how micorservice help us to overcome the issues we face in monolith architecture. Microservice means dividing our large application in smaller pieces according to [BoundedContext of DDD](https://martinfowler.com/bliki/BoundedContext.html) and develop an application for those smaller part. For example, we can imagine a ecommerce application where we can divide the whole ecommerce application in smaller pieces like Inventory, Order Processing, Delivery and Customer management. So we will develop different smaller application for Inventory, Order Processing, Delivery and Customer management module and those applications togather serve as a whole ecommerce application. I hope its clear now.

### What we'll build?
Well, to understand microservice and onion architecture we will build a simple application. There is two part Product and Order microservice. And we'll have a central gateway web api to make smoother communication with client applicatoin. We'll use [Ocelot](https://www.nuget.org/packages/Ocelot/) for router redirection in central gateway. And [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) with [MediatR](https://www.nuget.org/packages/MediatR/) in every microservice. To communicate from one microservice to another microservice we will use [RabbitMQ](https://www.rabbitmq.com/) message broker.

### Our project architecture 

<p float="left">
<img src="https://github.com/belal55/dotnet-core-microservice/blob/master/Docs/project-architecture1.png" height="200" width="230" alt="project-architecture1.png" />
<img src="https://github.com/belal55/dotnet-core-microservice/blob/master/Docs/project-architecture2.png" height="200" width="230" alt="project-architecture2.png" />
<img src="https://github.com/belal55/dotnet-core-microservice/blob/master/Docs/project-architecture3.png" height="200" width="230" alt="project-architecture3.png" />
<img src="https://github.com/belal55/dotnet-core-microservice/blob/master/Docs/project-architecture4.png" height="200" width="230" alt="project-architecture4.png" />
</p>
<br>
As we can see, in the root folder there is a folder "Microservices" which contain two microservice "Order" and "Product". And in the root folder there is a central gateway web api project which is responsible for route direction betweel client and microservices. Each microservice has three folder "Core", "Infrastructure" and "Presentation" according to onion architecture. Inside core there is two project, "Domain" which is a standard C# class library project and "Application" which is a standard .NET Core  class library project. Domain project contains all the entities which is the core of the application. Application project contain interfaces and CQRS commands which will be used by Infrastructure and Presentation layer. Inside Infrastructure folder there is a project "Persistence" which is a database for the specific microservice. We can use same database with multiple microservice also. And finally inside Presentation folder there is a Web API project to communicate with client. 

### Internal communication between microservices 
To communicate between Order and Product mircorservice we've used [RabbitMQ](https://www.rabbitmq.com/) message broker. We have used [MassTransit](https://masstransit-project.com/). MassTransit is a .NET Friendly abstraction over message-broker technologies like RabbitMQ. It makes it easier to work with RabbitMQ by providing a lots of dev-friendly configurations. It essentially helps developers to route messages over Messaging Service Buses, with native support for RabbitMQ.
<br>
To communicate through a message broker we need a message publisher which is responsible for publishing messages and cosumer to consume those messages. In our Order Microservice Web API project, inside OrderController there is a method to create an order from where we have published a message to OrderQueue with the information of latest created order. See below snapshot

<img src="https://github.com/belal55/dotnet-core-microservice/blob/master/Docs/Code-snap-1.png" height="300" alt="Code-snap-1.png" />

<br>
After publish message we need to consume the message from another microservice. We have a folder "Consumer" inside Product Web API projct under Persentation layer of prodcut microservic. There is a class "OrderConsumer.cs". Inside the class there is a method Consume where we will found the information we have passed from Order microservice through OrderQueue. see below snapshot 
<img src="https://github.com/belal55/dotnet-core-microservice/blob/master/Docs/Code-snap-2.png" height="300" alt="Code-snap-2.png" />
