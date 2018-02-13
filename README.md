
# **DeliverIT** [![Awesome](https://cdn.rawgit.com/sindresorhus/awesome/d7305f38d29fed78fa85652e3a63e154dd8e8829/media/badge.svg)](https://github.com/sindresorhus/awesome)
### **Team 4** --- Telerik Academy Alpha High Quality Code & Design Patterns Teamwork Project


## Table of Contents
- **Task**
- **Description**
- **Class Diagrams**
- **Team Members**
- **Git Repo Link**
- **License**

## Task
Our task is to design and implement application by choice, following:
- The **OOP** principles (where applicable)
  - Inheritance
  - Encapsulation
  - Abstraction
  - Polymorphism
- The **SOLID** principles (where applicable)
  - Single responsibility
  - Open/closed
  - Liskov substitution
  - Interface segregation
  - Dependency inversion
- Dependency inversion container (using Autofac)
  - Favor composition over inheritance
  - Introduce object lifetime management
  - Introduce convention based binding
- Unit tests
  - Introduced unit tests that use **both**:
     - **MSTest** (or other testing framework)
     - **Moq** (or other mocking framework)


## Description
DeliverIT is a simple console application used for managing orders' delivery. 
The application has the following list of commands: 
>- Add client
>   - Adds client (sender or receiver) to list of clients
>- Add courier
>   - Adds new courier to list of couriers
>- Place order for client
>   - Places order for client in specified list of orders 
>- List all clients
>   - Shows all clients in list
>- List all couriers
>   - Shows all couriers in list
>- List all orders
>   - Shows all order in the list of orders
>- List all delivery locations
>   - Shows all delivery location in each country

## Class Diagrams
- ## DeliverIT.Core
![DeliverIt.Core class diagram](https://github.com/Infra1515/DeliverIT/blob/master/imgs/DeliverITCore.png)

- ## DeliverIT.Data
![DeliverIT class diagram](https://github.com/Infra1515/DeliverIT/blob/master/imgs/DeliverITData.png)

- ## DeliverIT.Utilities
![DeliverIT class diagram](https://github.com/Infra1515/DeliverIT/blob/master/imgs/DeliverITUtilities.png)
## Team Members

* [Ivan Gargov](https://github.com/igargov)
* [Lyubomir Yonchev](https://github.com/Infra1515)
* [Irina Hristova](https://github.com/ihristova11)

## Git Repo
https://github.com/Infra1515/DeliverIT

## License
This project is licensed under the MIT License - see the LICENSE.md file for details
