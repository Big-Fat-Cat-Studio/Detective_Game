using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UK : Language
{
    void Start()
    {
        menuMainPlay = "Play";
        menuMainNewGame = "New Game";
        menuMainOptions = "Options";
        menuMainCredits = "Credits";
        menuMainExit = "Exit";

        menuPlay1 = "Grandpa's garden";
        menuPlay2 = "Grandpa's office";
        menuPlay3 = "The warehouse";

        menuOptionsGraphics = "Graphics";
        menuOptionsSound = "Sound";
        menuOptionsControls = "Controls";
        menuOptionsLanguage = "Language";

        menuGraphicsFullscreen = "Fullscreen";

        menuSoundVolume = "Volume";
        menuSoundMusic = "Music";

        menuControlsController = "Controller";
        menuControlsKeyboard = "Keyboard";

        menuConfirmNewGame = "You will lose all your unlocked levels, are you sure?";
        menuConfirmExit = "Are you sure you want to exit?";
        menuConfirmInGame = "Your level progress will be lost, are you sure?";

        menuCommonBack = "Back";
        menuCommonYes = "Yes";
        menuCommonNo = "No";

        menuResume = "Resume";
        menuRestart = "Restart";
        menuMainMenu = "Main Menu";

        // COMMON

        commonDoorLocked = "The door is locked! I need a key to open this";
        commonDoorOpen = "Press" + buttonX + "to open the door";
        commonElevator = "Press" + buttonX + "to turn on the elevator";
        commonRope = "Press" + buttonX + "to pull down the rope";
        commonBox = "Press" + buttonX + "to push the box";

        commonKeyPickup = "Press" + buttonX + "to pick up the key";
        commonKeyPart = "Press" + buttonX + "to pick up a part of a key";
        commonKeyDig = "Press" + buttonX + "to dig up a part of a key";
        commonKeyHuman = "You picked up a part of a key and put it in your pocket";
        commonKeyCombine = "You combined all the parts of a key into a full key";

        // TUTORIAL

        tutorialCommon = "Press" + buttonX + "to read the tutorial";

        tutorialPushHeader = "PUSH OBJECTS";
        tutorialPushMessageText = "Press" + buttonX + "to push an object with Kika" + space + "For heavier objects you need Daigo to push as well!";

        tutorialNatureHeader = "NATURE'S CALL";
        tutorialNatureMessageText = "Sometimes a dog has to take a leak with"+ dogPee + space + "And yes..." + dogPoo + "does the rest";

        tutorialSnacksHeader = "DOG TREATS";
        tutorialSnacksMessageText = "Press" + buttonX + "near a dispenser for a dog treat" + space + "These treats will make Daigo go faster!";

        tutorialUmbrellaHeader = "UMBRELLA";
        tutorialUmbrellaMessageText = "Kika can open her umbrella with" + tutUmbrella  + space + "Daigo can reach new heights by bouncing off the umbrella";

        tutorialMoveMessageHeader = "MOVEMENT";
        tutorialMoveMessageText = "Use" + tutMove + "to walk around" + space + "Use" + tutLook + "to look around" + space + "Press" + tutJump + "to jump";

        tutorialClose = close + "close";

        // YARD

        yardSnacks = "Press" + buttonX + "to eat a cookie";
        yardWrench = "Press" + buttonX + "to pick up the wrench";
        yardFuseUse = "Press" + buttonX + "to turn on the electricity";
        yardFuseFix = "The switch seems broken, maybe I can fix it with a wrench";
        yardFuseFixed = "Great, I think it's fixed! Maybe the elevator works now";

        // CITY

        cityBoxBig = "Press" + buttonX + "to push the big box";
        cityPoster = "Press" + buttonX + "to look at the poster";
        cityDoorHandleMiss = "The door has no handle... I wonder if I can find it somewhere else";

        cityDoorHandleDig = "Press" + buttonX + "to dig up the door handle";
        cityDoorHandle = "Press" + buttonX + "to pick up the door handle";

        // DOCKS

        docksToolBox = "Press" + buttonX + "to pick up the toolbox";
        docksBook = "Press" + buttonX + "to read the book";
        docksVent = "Press" + buttonX + "to open the vent";
        docksVentStuck = "The vent is stuck! Maybe if I had a tool I could open it";

        docksPipe = "Press" + buttonX + "to repair the pipework";
        docksPipeRotate = "Turn pipe" + pipeRotate;
        docksPipeMove = "Select position" + pipeMove;
        docksPipeSelect = "Select pipe" + pipeSelect;
    }

}
