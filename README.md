# Projective Geometric Algebra for Unity

[![License: MIT](https://img.shields.io/badge/License-MIT-blueviolet.svg)](https://opensource.org/licenses/MIT)

## What is this?

A library for doing Euclidean Plane-Based Geometric Algebra (basically, "Projective Geometric Algebra") in Unity, based on [the bivector.net library](https://bivector.net/tools.html). It includes operator overloading and conversion between Unity-style objects and PGA-style objects, i.e. Unity quaternions and vectors and PGA points, directions, rotors and motors.

## How can I learn Projective Geometric Algebra?

[![Steven De Keninck Lecture](https://img.youtube.com/vi/ichOiuBoBoQ/0.jpg)](https://www.youtube.com/watch?v=ichOiuBoBoQ "Steven De Keninck. Dual Quaternions Demystified")

<!-- ## Example
`
//You want something here
` -->

## Usage

1. Copy the .cs file into your project folder alongside your other .cs files
2. Put the line `using static PGA3D;` at the top of any file you want to use PGA in, and you're good to go!

## Discord

I can recommend the [Bivector Discord](https://discord.gg/q3uRnzxG). You can ask any question, from the most basic to the most advanced, and there should be someone there to help you!

## TODOs. Let me know if you'd like me to get of my arse and implement these!

- There may be a problem with the minus signs of the join and projections. It is very unlikely to affect anyone. This is ongoing research in my opinion
- Conversion to Matrix4x4. This should be easy, I just don't have time.
- Dedicated Dual Quaternion, Bivector, point, plane classes. Add in flector and now we're more typed I guess?
- Perhaps you should even just be able to use unity planes as- is. Not vectors though, there's unavoidable ambiguity about directions vs positions in there
- Arbitrary distance and angle formulae
- Overload some operator to do sandwiching
- More compatibility with FABRIK
- I might be being paranoid to have (~X) rather than just ~X

## Contact

hamish.todd1 at google's email service, or hamish_todd on twitter

## Credits

Aside from writing (the code that generated) the initial version of this library, I am heavily indebted to Steven De Keninck! Indebted too to others who helped me including Pontus Granström, Chris Doran, Anthony John Bell, Charles Gunn, Hugo Hadfield, Eric Lengyel, Simon Fenney, and Martin Roelfs