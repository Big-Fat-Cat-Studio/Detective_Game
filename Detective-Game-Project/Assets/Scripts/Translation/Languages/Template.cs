using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template : Language
{
    void Start()
    {
        menuMainPlay = "";
        menuMainNewGame = "";
        menuMainOptions = "";
        menuMainCredits = "";
        menuMainExit = "";

        menuPlay1 = "";
        menuPlay2 = "";
        menuPlay3 = "";

        menuOptionsGraphics = "";
        menuOptionsSound = "";
        menuOptionsControls = "";
        menuOptionsLanguage = "";

        menuGraphicsFullscreen = "";

        menuSoundVolume = "";
        menuSoundMusic = "";

        menuControlsController = "";
        menuControlsKeyboard = "";

        menuConfirmNewGame = "";
        menuConfirmExit = "";
        menuConfirmInGame = "";

        menuCommonBack = "";
        menuCommonYes = "";
        menuCommonNo = "";

        menuResume = "";
        menuRestart = "";
        menuMainMenu = "";

        // COMMON

        commonDoorLocked = "";
        commonDoorOpen = "" + buttonX + "";
        commonElevator = "" + buttonX + "";
        commonRope = "" + buttonX + "";
        commonBox = "" + buttonX + "";

        commonKeyPickup = "" + buttonX + "";
        commonKeyPart = "" + buttonX + "";
        commonKeyDig = "" + buttonX + "";
        commonKeyHuman = "";
        commonKeyCombine = "";

        // TUTORIAL

        tutorialCommon = "" + buttonX + "";

        tutorialPushHeader = ""; //ALL CAPS
        tutorialPushMessageText = "" + buttonX + "" + space + "";

        tutorialNatureHeader = ""; //ALL CAPS
        tutorialNatureMessageText = ""+ dogPee + space + "" + dogPoo + "";

        tutorialSnacksHeader = ""; //ALL CAPS
        tutorialSnacksMessageText = "" + buttonX + "" + space + "";

        tutorialUmbrellaHeader = ""; //ALL CAPS
        tutorialUmbrellaMessageText = "" + tutUmbrella  + space + "";

        tutorialMoveMessageHeader = ""; //ALL CAPS
        tutorialMoveMessageText = "" + tutMove + "" + space + "" + tutLook + "" + space + "" + tutJump + "";

        tutorialClose = close + "";

        // YARD

        yardSnacks = "" + buttonX + "";
        yardWrench = "" + buttonX + "";
        yardFuseUse = "" + buttonX + "";
        yardFuseFix = "";
        yardFuseFixed = "";

        // CITY

        cityBoxBig = "" + buttonX + "";
        cityPoster = "" + buttonX + "";
        cityDoorHandleMiss = "";

        cityDoorHandleDig = "" + buttonX + "";
        cityDoorHandle = "" + buttonX + "";

        // DOCKS

        docksToolBox = "" + buttonX + "";
        docksBook = "" + buttonX + "";
        docksVent = "" + buttonX + "";
        docksVentStuck = "";

        docksPipe = "" + buttonX + "";
        docksPipeRotate = "" + pipeRotate;
        docksPipeMove = "" + pipeMove;
        docksPipeSelect = "" + pipeSelect;
    }

}
