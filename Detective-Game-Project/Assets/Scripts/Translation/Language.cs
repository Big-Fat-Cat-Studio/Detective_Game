using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Language : MonoBehaviour
{
    // MENU
    [HideInInspector]
    public string menuMainPlay, menuMainNewGame, menuMainOptions, menuMainCredits, menuMainExit;
    [HideInInspector]
    public string menuPlay1, menuPlay2, menuPlay3;
    [HideInInspector]
    public string menuOptionsGraphics, menuOptionsSound, menuOptionsControls, menuOptionsLanguage;
    [HideInInspector]
    public string menuGraphicsFullscreen;

    [HideInInspector]
    public string menuSoundVolume, menuSoundMusic, menuSoundSound;

    [HideInInspector]
    public string menuControlsController, menuControlsKeyboard;

    // menuLanguage = ""; //ALL LANGUAGES WRITTEN IN LANGUAGE OF ORIGIN
    [HideInInspector]
    public string menuConfirmNewGame, menuConfirmExit, menuConfirmInGame;
    [HideInInspector]
    public string menuCommonBack, menuCommonYes, menuCommonNo;

    // MENUINGAME
    [HideInInspector]
    public string menuResume, menuRestart, menuMainMenu;

    //COMMON
    [HideInInspector]
    public string commonDoorLocked, commonDoorOpen, commonElevator, commonRope, commonBox;
    [HideInInspector]
    public string commonKeyPickup, commonKeyPart, commonKeyDig, commonKeyHuman, commonKeyCombine;

    //TUTORIAL
    [HideInInspector]
    public string tutorialCommon, tutorialClose;
    [HideInInspector]
    public string tutorialPush, tutorialPushHeader, tutorialPushMessageText;
    [HideInInspector]
    public string tutorialNature, tutorialNatureHeader, tutorialNatureMessageText;
    [HideInInspector]
    public string tutorialSnacks, tutorialSnacksHeader, tutorialSnacksMessageText;
    [HideInInspector]
    public string tutorialUmbrella, tutorialUmbrellaHeader, tutorialUmbrellaMessageText, tutorialUmbrellaMessageBot;
    [HideInInspector]
    public string tutorialMoveMessageHeader, tutorialMoveMessageText;

    // YARD
    [HideInInspector]
    public string yardWrench, yardSnacks, yardFuseUse, yardFuseFix, yardFuseFixed;

    // CITY
    [HideInInspector]
    public string cityBoxBig, cityPoster;
    [HideInInspector]
    public string cityDoorHandleMiss, cityDoorHandleDig, cityDoorHandle;

    // DOCKS

    [HideInInspector]
    public string docksToolBox, docksBook, docksVent, docksVentStuck;
    [HideInInspector]
    public string docksPipe, docksPipeRotate, docksPipeMove, docksPipeSelect;

    [HideInInspector]
    public string space = "<br><br>";
    [HideInInspector]
    public string buttonX = " <sprite=13> / <sprite=0> ";
    [HideInInspector]
    public string pipeRotate = "    <sprite=15><sprite=16> / <sprite=8><sprite=9>";
    [HideInInspector]
    public string pipeMove = "    <sprite=12><sprite=21> / <sprite=7><sprite=4>";
    [HideInInspector]
    public string pipeSelect = "    <sprite=14><sprite=18> / <sprite=5><sprite=6>";
    [HideInInspector]
    public string dogPee = " <sprite=17> / <sprite=9> ";
    [HideInInspector]
    public string dogPoo = " <sprite=22> / <sprite=1> ";
    [HideInInspector]
    public string tutMove = " <sprite=12><sprite=21><sprite=14><sprite=18> / <sprite=10> ";
    [HideInInspector]
    public string tutLook = " <sprite=23> / <sprite=11> ";
    [HideInInspector]
    public string tutJump = " <sprite=20> / <sprite=2> ";
    [HideInInspector]
    public string tutUmbrella = " <sprite=22> / <sprite=1> ";
    [HideInInspector]
    public string close = " <sprite=19> / <sprite=3> ";
}
