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


