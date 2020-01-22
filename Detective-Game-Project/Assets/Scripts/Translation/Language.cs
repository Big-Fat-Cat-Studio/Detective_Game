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
    public string menuGraphicsVeryLow, menuGraphicsLow, menuGraphicsMedium, menuGraphicsHigh, menuGraphicsVeryHigh, menuGraphicsUltra, menuGraphicsFullscreen;

    // menuSound = "";
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


    // YARD
    [HideInInspector]
    public string yardWrench, yardBin, yardSnacks, yardElevatorFix, yardElevatorButton, yardEndLevel;
    [HideInInspector]
    public string yardKeyPart, yardKeyDig, yardKeyHuman, yardKeyCombine;

    [HideInInspector]
    public string tutorialCommon;
    [HideInInspector]
    public string tutorialPush, tutorialPushHeader, tutorialPushMessageTop, tutorialPushMessageBot;
    [HideInInspector]
    public string tutorialNature, tutorialNatureHeader, tutorialNatureMessageTop, tutorialNatureMessageBot;
    [HideInInspector]
    public string tutorialSnacks, tutorialSnacksHeader, tutorialSnacksMessageTop, tutorialSnacksMessageBot;
    [HideInInspector]
    public string tutorialUmbrella, tutorialUmbrellaHeader, tutorialUmbrellaMessageTop, tutorialUmbrellaMessageBot;
    [HideInInspector]
    public string tutorialMoveMessageWalk, tutorialMoveMessageLook, tutorialMoveMessageJump;


}
