# Introduction
The arrangement of containers in a cargo (storage plan) must be made based on various considerations.
https://en.wikipedia.org/wiki/Stowage_plan_for_container_ships
In this exercise, we will focus on a single factor:
for stability reasons, the center of gravity of the containers must be as close as possible to the X and Y center of the ship and 
as low as possible in respect to Z.

Brute Force solution
This term refers to an algorithm that tries all the combinations of available arrangements and extracts the best among them.
This solution is computationally impractical:
The largest MSC ship has a capacity of 24,116 TEU, where a 20DV container corresponds to 1 TEU.
For simplicity, we ignore that there are containers of different sizes (such as 40DV).
The number of possible arrangements is equal to N! And therefore 24116! = 6.584685784 * 10^95212 (1*10^9 is a billion).

# Alternative methods
Since an optimal solution cannot be found with a brute force algorithm, it is necessary to define not the best solution, but an acceptable one.
Acceptable means that the center of gravity is "sufficiently" close to its ideal position.
We simplify the problem in the following way:

a) Containers are cubes of size 'a'

b) The ship is modeled as a parallelepiped-shaped grid having
- NX container on the x axis (width),
- NY container on the y axis (length),
- NZ container on the z axis (height)

c) The ship has no weight

The ideal center of gravity is in the center of the ship's floor.
Along the z axis it will never be possible to reach this value since the containers are all above it.

As an acceptable volume in which the center of gravity falls, a parallelepiped is defined having:
x% around the center of the ship (relative to the width of the ship)
y% around the center of the ship (relative to the length of the ship)
z% above the floor of the ship (relative to the height of the ship)

# The purpose of the Algorithm
Input data:
- a ship that accommodates X*Y*Z containers of size 'a'
- a list of containers (number equal to the number of slots, that is NX*NY*NZ) of different weight
- a target % deviation from the ideal center of gravity (on x, y and z axis)

Identify an algorithm that distributes the containers in the ship’s grid in a way that minimizes the distance of the total center of gravity from the ideal one.
In other words:
- the front part of the ship must have similar weight if compared to the back part 
- the left part of the ship must have similar weight if compared to the right part 
- heavier containers must be at the bottom for obvious stability reasons

It is suggested to proceed to divide the problem:
- first, optimize the distribution on the different floors of the ship (z axis)
- then focus on an optimization on the different planes (x and y direction).

Once the algorithm has been applied, calculate the center of gravity of the ship (assume that the ship has zero weight, 
consider only the weight of the containers when calculating the center of gravity).
Verify that the point of the center of gravity is within the tolerance volume.

# Environment setup
- Install Visual Studio 2022 (community edition, free)
- If not already available, create an account on github (free)
- Fork the repo https://github.com/msc-technology/avogadro-challenge-2024 on your account
- The cloned repository contains the solution container-placement.sln
- The solution contains two projects:
1. ContainerPlacementCalculator: class library where to write the algorithm for container placement in the vessel slots
   This project already contains classes to 
   - generate the vessel slots placement given NX, NY, NZ and a (Vessel class)
   - generate containers with a random weight (given an average weight and a % deviation) (ContainerGenerator class)
   - ContainerAllocator class: it is supposed to contains the method(s) to place container in the vessel slots.
     - It contains the DumbAllocateBySequence method that has a "dumb" logic implementation:  use just the order of the container in the list without considering their weight, that is, it does not try to optimize the center of mass 
     - It contains a SmartAllocate1 method to be implemented (currently returns a NotImplementedException) with a logic that tries to optimize the center of mass
2. ContainerPlacementUnitTests: project that contains the unit tests to test the behavior of the algorithm. 
   it contains unit tests for 
   - Vessel slot generation 
   - ContainerGenerator class 
   - Calculation of ship center of mass, given a container distribution on the slots
   - Check if SmartAllocate1 method, once implemented, is more efficient than the method DumbAllocateBySequence 

- Use Visual studio Test menu -> Test Explorer to run the tests.
See picture run-tests.png

Once the work is completed, make a pull request to the original repository https://github.com/msc-technology/avogadro-challenge-2024

