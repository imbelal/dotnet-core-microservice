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

