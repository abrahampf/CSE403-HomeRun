# CSE 403 - Home Run

## About Home Run:
- [User Manual](https://github.com/abrahampf/CSE403-HomeRun/tree/main/Documentations/users)
- [Developer Manual](https://github.com/abrahampf/CSE403-HomeRun/tree/main/Documentations/developers)

## Introduction
Welcome to Home Run, an immersive 3D baseball game developed as part of the University of Washington's course CSE 403 Software Engineering.

## Project Overview
Home Run offers a thrilling single-player experience set in a vibrant baseball stadium environment. Players engage in dynamic matches against AI opponents, showcasing their batting skills and strategic prowess.

## Key Features
- **Gameplay**: Engage in head-to-head matches against AI opponents.
- **Pitch Variety**: Choose from various pitching styles to challenge your skills.
- **Interactive Batting**: Swipe to swing the bat and score runs.
- **Customization**: Personalize players, balls, bats, and stadium for a unique experience.

## Objectives
- Deliver an immersive and interactive 3D gaming experience.
- Maintain high standards of design and functionality consistent with modern gaming applications.

## Team Members & Roles
| Team Member             | Role                                 | Responsibilities                                                     |
|-------------------------|--------------------------------------|----------------------------------------------------------------------|
| Abraham Pasillas-Flores | Backend (Framework Design)           | Develop the game's backend architecture.                            |
| Azucena Solano-Gonzalez | Backend (Data Management and Server) | Manage server-side operations and data handling using SQL and PHP.  |
| Nathan                  | Frontend + Design                    | Design user interface and handle frontend development.             |
| Hinal                   | Frontend + Design                    | Assist in frontend development and design elements.                 |
| Tian                    | Frontend (Game Logic)                | Implement game logic and interactive elements.                      |

## Development Process
### Software Toolset
- **Unity with C#**: Core for game development and handling front-end and core game mechanics.
- **Android Studio**: Additional Android-specific features and testing.
- **SQL and PHP**: Backend services, including server logic, database management, and web services.
- **Unity APIs and Google Play Services**: Integration of in-app purchases, leaderboards, and Android functionalities.
- **Third-Party SDKs**: Incorporation of ads, analytics, and social media features.

## Risks
- Unity Learning Curve: Limited team experience with Unity presents a significant risk.
- Google Play Store Compliance: Adhering to Google Play Store guidelines is challenging due to lack of deployment experience.

## Requirements
### Non-functional Requirements
- Low loading time ensuring gaming experience that can take place in anytime, anywhere.
- The game should run smoothly on various devices.
- Design for minimal and efficient user interactions.

### External Requirements
- Robust error handling.
- Easy installation and play.

## Repository Structure
- The repository is organized into frontend and backend components.
  - Each component has subdirectories for modularity.
    - For example, data management and framework components have separate directories within the backend directory.

## Instructions
### Build System
#### How to Build the System:
- Ensure Unity Hub (latest version) and Unity Editor (preferably 2019 version) are installed.
- Clone the repository to your local machine.
- Open Unity Hub and add the cloned repository.
- Navigate to the repository folder and open it in Unity Editor.
- Select "File > Build Settings" and choose your platform.
  ![image](https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/a2b2452e-69fc-42b5-a623-70157b1b790e)
  
- In the Unity Hub Projects section, click Add and choose the ./HomeRun directory
  
  ![image](https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/a670aa9e-7eb5-47da-b460-6d548be14868)
- Click "Build" to create the executable file and specify its location.

#### How to Test the System:
- Open the project/build folder.
- Test various mechanics in the login scene:
  - Input username and password.
  - Create an account with unique credentials.
  - Sign in with the created account.
- Test mechanics after signing in:
  - Ensure smooth transition to the game scene.
  - Verify functionality of swiping to hit the ball.

### Run The System
#### How to Run the System:
- Build the system using the instructions above and save the executable file.
- Navigate to the folder containing the executable file.
- Open the executable file to launch the baseball game.
- Follow on-screen prompts and instructions to sign in and play the game.

We are committed to enhancing the Home Run gaming experience. For contributions or further inquiries, please refer to the Git repository linked above.
