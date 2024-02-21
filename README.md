# CSE 403 - Home Run

## Learn about Home Run:
- [User manual](https://github.com/abrahampf/CSE403-HomeRun/tree/main/Documentations/users) <br>
- [Developer manual](https://github.com/abrahampf/CSE403-HomeRun/tree/main/Documentations/developers)

## Introduction
Welcome to Home Run, an interactive Android-based mobile baseball game project for University of Washington's course CSE 403 Software Engineering.

## Project Overview
Home Run is a single-player game that combines skill, strategy, and fun in a baseball-themed environment. Players can challenge AI to engage in a dynamic and interactive game of pitch and bat.

## Key Features
- Gameplay: Compete against AI player in an exciting head-to-head match.
- Various Pitch Styles: Choose from different pitching styles to challenge your opponent.
- Interactive Batting: Simply swipe to bat and score runs.
- Customization: Personalize players, balls, bats, and scenery.

## Goals
- To create an engaging and interactive mobile gaming experience.
- To maintain high standards of design and functionality consistent with Android applications.

## Team members & roles
| Team Member             | Role                                 | Responsibilities                                                     |
|-------------------------|--------------------------------------|----------------------------------------------------------------------|
| Abraham Pasillas-Flores | Backend (Framework Design)           | Developing the game's backend architecture.                          |
| Azucena Solano-Gonzalez | Backend (Data Management and Server) | Managing server-side operations and data handling.                   |
| Nathan                  | Frontend + Design                    | Designing user interface and handling frontend development.          |
| Hinal                   | Frontend + Design                    | Assisting in frontend development and design elements.               |
| Tian                    | Frontend (Game Logic)                | Implementing game logic and interactive elements.                    |

## Development Process
### Software Toolset
- Unity with C#: Central to game development, handling both front-end and core game mechanics.
- Android Studio: For additional Android-specific features and testing.
- Java and Python: For backend services, including server logic and web services.
- Database: For real-time data management  and syncing.
- Unity APIs and Google Play Services: For integrating in-app purchases, leaderboards, and Android functionalities.
- Third-Party SDKs: For ads, analytics, and social media features.


## Risks
- Unity Learning Curve: The team has limited Unity experience, presenting a high impact risk due to Unity's complexity. 
- Google Play Store Compliance: Adhering to Google Play Store guidelines is a risk because the team lacks app deployment experience. 
- Krita-Unity Integration: Integrating Krita animations into Unity poses a high impact risk due to unfamiliarity with both tools. 



## Requirements
### Non-functional Requirements
- Low loading time ensuring gaming experience that can take place in anytime, anywhere.
- The game should run at 60 FPS for a smooth experience.
- Design for minimal and efficient user interactions.


### External Requirements
- Robust error handling.
- Easy installation and play.

## Repo Layout
- Divided by front and back end work.
    - Within the front and backend, different components will have their own sub directories for modularity.
       - For example, data management and the framework components will each have their own sub directories within the backend directory.

# Instructions
## Build System
### How to build system: 
-  1. Must have these Downalds to start off
      - Unity hub( latest Version)
      - Unity editor(best case 2019 version)
- 2. Clone our current repo in your local machine with git clone
- 3. Open unity hub 
- 4. Click on the add file in the top right corner
- 5. Go into the folder where you cloned the repo file
- 6. Select and open
- 7. It is now in unity hub 
- 8. Click on the file to open it in Unity editor
- 9. Select File in the upper left corner and Select Build settings(File>Build Settings).
- 10. Select your platform of choice.
- 11. Finally click on Build to create the file and choose where you would like to place it
### How to test the system:
- 1. Open project/build
- 2. Test various mechanics in the first login scene.
        - Able to input user name 
        - Able to input password
        - Creating an account with those inputs that has a unique username
        - Able to sign in with a account that has been successfully created
- 3. Testing the mechanics after the click of the Sign-in button 
        - Does it let you enter the first scene/game.
        - Can you swipe and hit the ball?

## Run The System
### How to run the system:
- 1. Needs to build the system using the instructions above and save the executable file in a folder
- 2. Navigate to the folder where the executable file was created.
- 3. Open the executable file to launch the baseball game/build.
- 4. Use the on-screen prompts and instructions to sign in and play the game.

------------

We look forward to developing an engaging and enjoyable gaming experience with Home Run. For more information or to contribute to the project, please refer to the Git repository linked above.
