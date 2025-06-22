

**Practical work 1 Extraordinary call**

**Rubén Tapia Blanco**

**GRADO EN INGENIERÍA INFORMÁTICA**

**CURSO ACADÉMICO 2024-25**

**22-06-2025**

**Contents**

[1 Introduction 1](#_Toc198924547)

[2 Description 1](#_Toc198924548)

[2.1 Class diagram 2](#_Toc198924549)

[3 Problems 2](#_Toc198924550)

[4 Conclusions 2](#_Toc198924551)

# Introduction

This document provides a comprehensive overview of the development and implementation of a train station simulation. The project models various real-world components including trains (passenger and freight), platforms, and a station manager that coordinates their interactions.

The purpose of the document is to explain the solution to the given problem, including a class diagram to understand the solution. A problems section in which the problems that happened during the development of the solution and a conclusion.

# Description

For starters, given the instructions I decided to implement the abstract train class and its inherited classes, freight train and passenger train. As these classes were very simple and their behavior was stated in the instructions, only attributes, a class constructor and different getter and setter methods were to be implemented. On the other hand, to model the simulation of a real train station, the advance tick method was required, which only had to check that the train status was enroute and its arrival time was greater than 0 and if both requirements were met, the arrival time of the train was reduced by 15 minutes. Then the platform class was due, which only had attributes and their getter and setter methods. To model the functionality of a real train station, a new method was required, the advance tick method which checks if the platform status is occupied and the docking ticks remaining is greater than 0, in which case the docking tick is reduced by one and if it is 0, the train is docked in the platform and the status of the platform is changed to free. The station has two lists, one of trains and one of platforms, a class constructor and the advance tick method, which calls for the platform and train advance tick methods and then checks if the current train has a waiting status and if the platform is free, then the train is to be docked. Finally the program class displays a menu of 4 options, the first one is to load the trains from a file with a specific format, the second one simulates the functionality of the station, the third one displays the information of the station and the last ends the program.

## Class diagram
![Class Diagram](/images/classDiagram.jpg)

# Problems

The main problem for me was to convert the hours to mins, it took me a while to realize that the conversion was actually quite simple, as 15 minutes is a fourth of an hour. The other thing that was hard for me was to implement the functionality of the solution. Because as the methods weren’t all given to us, I had to decide how to correctly implement everything to make the program mimic real life train station functionality.

# Conclusions

The implementation of a modular structure, composed of trains, platforms, and a central station, enabled me to clearly separate responsibilities across classes, making the system easier to understand, maintain, and extend. One of the most significant takeaways was the importance of handling state transitions correctly, particularly for trains as they moved through various phases from en route to docked. I also faced several challenges, including managing dynamic interactions between trains and platforms and ensuring the time-based simulation logic aligned with the intended behavior. Overcoming these issues helped reinforce the need for thorough planning, consistent testing, and thoughtful class design.
