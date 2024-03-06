# CSE 403 - Home Run

## About Home Run:
- [User Manual](https://github.com/abrahampf/CSE403-HomeRun/tree/main/Documentations/users)
- [Developer Manual](https://github.com/abrahampf/CSE403-HomeRun/tree/main/Documentations/developers)

## Introduction
Welcome to Home Run, an immersive 3D baseball game developed as part of the University of Washington's course CSE 403 Software Engineering.

## Project Overview
Home Run offers a thrilling single-player experience set in a vibrant baseball stadium environment. Players engage in dynamic matches against AI opponents, showcasing their batting skills and strategic prowess.

## Key Features
- **Gameplay**: Engage in head-to-head matches against AI opponent.
- **Authentication**: Register, sign-in and logout of thier account securly.
- **Interactive Batting**: Swipe to swing the bat and score runs.
- **LeaderBoard**: Shows players high-scores and achievements.

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
##### Building system in Andriod phone:
- Ensure Unity Hub (latest version) and Unity Editor (preferably 2019 version) are installed.
- Clone the repository to your local machine.
- Open Unity Hub and add the cloned repository.
- Navigate to the repository folder and open it in Unity Editor.
- Connect the computer and you phone via a wire connector.
- Change the settings on your android phone to developer mode.
  
  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/553d05d7-65f0-474a-971b-8a92588ee25b">

- Change the battery setting to Trasfer files (MTP) by sliding down the battery menu.
  
  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/f276bb47-45e5-4a76-b93c-70e3a602de20">

- On Unity go to file-> build setting.

  <img width="440" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/2600008b-e3dc-4a4c-8d8e-07eb9fe7219b">

- On the platform tab of the build setting, change the device to Andriod

  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/c450383d-3686-4649-bcb7-51d5ea50c345">

- On the right tab of the android, in the Run Device setting select all compatible devices and then click on refresh. 

  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/48d4e591-d01f-4318-a5a2-9cb64e47958e">

- Go to the Run device setting again and now your android phone should show up select that and press the build button.

- This should let you save the APK, save it in your desired folder.

- Drag the APK folder in the desired folder in your phone from your computer. 

- Find that APK in your phone (it should be where you placed it from your computer) and then install it. 

- The game should show up on your phone.

##### Building system in Unity:
- Ensure Unity Hub (latest version) and Unity Editor (preferably 2019 version) are installed.
- Clone the repository to your local machine.
- Open Unity Hub and add the cloned repository.
- Navigate to the repository folder and double-click to open it in Unity Editor.


#### How to Test the System:
- Go to Windows -> General -> Test Runner.

  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/38170295-88f9-4677-820e-fdde7d435c5e">
  
- Click on the Play Mode.

  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/569ed0f0-1a44-4750-8fb6-5e15be869d04">
 
- Select and click Run All button to run all the test.

  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/1741208d-1c74-47db-bb59-7d71b6454575">


### Run The System
#### How to Run the System for unity:
- Build the system using the instructions above and save the executable file.
- Navigate to the folder containing the executable file.
- Open the executable file to launch the baseball game.
- On the upper right corner toggle over the game and select layout to 2 by 3
  
  <img width="467" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/00e0c307-f239-46b9-a28c-7796aba9c183">
  
- On the bottom left cornor, click on the drop down menu on Game and select Simulator.

  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/ccb7dac2-8ab8-4b21-b631-8814242d0ffd">

- Select The correct device: Samsung Galaxy S8.

  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/9199e157-9a06-436d-a48d-d5a4f12e02f0">

- Click on the rotate button to make the phone sideways for a better view of the game.

  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/a40523e6-ab44-4c25-a70c-19dc37ffb30b">

- Click on the play on the top.

  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/dd8dd186-e2e6-484f-bce7-f7fee9abaf85">

- The game should look like this in the simulator, now follow on-screen prompts and instructions to register or press start game to  play the game.

  <img width="500" alt="image" src="https://github.com/abrahampf/CSE403-HomeRun/assets/108777737/43b0abf8-1e61-441e-a642-15588f3d8d51">

We are committed to enhancing the Home Run gaming experience. For contributions or further inquiries, please refer to the Git repository linked above.
