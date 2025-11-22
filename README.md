# AR Treasure Hunt Game

This repository contains the materials for the AR Treasure Hunt Game developed using Unity and Vuforia. The game provides an engaging treasure hunt experience using augmented reality, where players use their device's camera to find and collect virtual treasures.

## Project Overview

The core concept of the game revolves around players using their device's camera to scan image targets in their environment. Upon detecting a target, a 3D object appears, representing a virtual treasure. Each successful detection reveals a hint for the next target, guiding players through the game until all treasures are collected.

## Features

- **Augmented Reality Gameplay**: Utilizes Unity and Vuforia for a seamless AR experience.
- **Intuitive User Interface**: Simple and user-friendly UI, including score display, hints, and buttons for interactions.
- **3D Models**: Custom and asset store 3D models used for virtual treasures.
- **Secure Game Logic**: Managed through custom C# scripts ensuring smooth gameplay and accurate detection.

## Contents

- The full Unity game, including all assets and scripts, can be downloaded from this repo.
- **Image Targets**: A folder containing all image targets used in the game.

## Installation

To run the project locally, follow these steps:

1. **Download the Project**: Download the zip file and extract it or clone the repo.

2. **Unity Setup**:
   - Ensure you have Unity installed (compatible with the project's Unity version 2022.3).
   - Open Unity Hub and add the extracted project. (excluding the image target folder).

3. **Vuforia Setup**:
   - **Create a Local Database**: Use the Vuforia Target Manager to create a local database.
   - **Add Image Targets**: Import the provided image targets into the Vuforia database. Follow Vuforia's documentation to set up and configure the targets within the Unity project.

4. **Run the Game**:
   - Open the project in Unity.
   - Load the main scene and play the game within the Unity editor or build it for your preferred platform.

## How to Play

1. **Start the Game**: Launch the game and read the instructions on the start screen.
2. **Scan Targets**: Use your device's camera to find and scan the image targets.
3. **Collect Treasures**: Collect the virtual treasures by clicking the collect button when a target is detected.
4. **Follow Hints**: Use the hints provided to find the next target.
5. **Complete the Game**: Continue collecting treasures until all are found.

## Contributions

Contributions to the AR Treasure Hunt Game are welcome. Feel free to fork the repository and submit pull requests.
