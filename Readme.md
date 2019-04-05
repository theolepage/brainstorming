# Brainstorming

Sail through algorithms.

## Objectives

### Short-term

This project is aimed to find efficient algorithms able to manage the trajectory of a sailboat. For the moment, our objective is to create a 2D physic simulation to represent a sailboat in realistic conditions.

### Long-term

This project could be used to build an autonomous sailboat powered mainly by clean energy. Its aim would be to reach a target (or waypoints) set through a user interface.  

A 4 layer algorithm would be required:
1. Strategic long term routing: determines optimal route, according to weather conditions and sea topology, by dividing it into many short legs.
2. Short course routing: determines optimal way to reach each waypoint defined above.
3. Manoeuvre execution: ensures smooth execution of the manoeuvres automatically.
4. Emergency reflexes: overrules the requested actions if there is a threat.

This project answers the problem of short course routing as many solutions already exist for the strategic long term routing.

## Algorithms

We consider that our sailboat has a desired heading angle.
We are looking for the approach to determine the rudder and sail angle to maximizing its speed in this direction.  

Two different approaches to controlling the sails and rudders are presented in the following documents.
1. Strömbec, C (2017). *Modeling, Control and Optimal Trajectory Determination for an Autonomous Sailboat* (Master's thesis).  Department of Automatic Control, Lund University, Sweden. Retrieved from [http://lup.lub.lu.se/luur/download?func=downloadFile&recordOId=8923407&fileOId=8923408](http://lup.lub.lu.se/luur/download?func=downloadFile&recordOId=8923407&fileOId=8923408).
2. Stelzer, R. *Autonomous Sailboat Navigation* (Doctoral dissertation). Centre for Computational Intelligence, De Montfort University, England. Retrieved from [https://www.dora.dmu.ac.uk/bitstream/handle/2086/7364/thesis-optimized-300dpi.pdf](https://www.dora.dmu.ac.uk/bitstream/handle/2086/7364/thesis-optimized-300dpi.pdf).

### The cost based trajectory control

This method will associate a cost for each angle (depending on sensors or predefined data). The following costs are covered: heading cost, velocity polar diagram cost, obstacle cost, action cost, strategic cost, tactical cost, wave cost...  

The algorithm determines which angle to go by finding the angle with the minimum cost.  

It relies on a [proportional–integral–derivative controller](https://en.wikipedia.org/wiki/PID_controller) (or PID controller) to continuously calculates an error value (as the difference between the desired heading and the current heading) and applies a smooth correction.

### The velocity made good strategy

This algorithm is based on the optimisation of the  time-derivative of the distance between boat and target.

![Velocity polar diagram of a Hobie 20](https://raw.githubusercontent.com/thdoteo/brainstorming/master/docs/vpd-hobie20.png)

According to the [velocity made good](https://en.wikipedia.org/wiki/Velocity_made_good) (or VMG) concept, the actual speed a sailboat can reach in a certain direction depends on the windspeed but also on the angle between boat heading and wind direction. While no direct course is possible straight into the wind, the maximum speed for a Hobie 20 is obtained with the wind from the side at about ±90 degrees. A boat-specific velocity polar diagram (or VPD) is created and used by the algorithm to adapt the heading.

Furthermore, the algorithm described in the second documents provides an answer to the question when to tack on upwind courses. However, it does not provide an obstacle avoidance as opposed to the first one.

## To-Do

- Try using a neural network (3 inputs: wind/objective/heading angle, 1 output: rudder angle)
- Create a simulation sandbox to test different algorithms
- Write an implementation for both algorithms
- Create a website hosting sailing tournaments to challenge each user's algorithm
- Develop a complete and efficient solution to our problem