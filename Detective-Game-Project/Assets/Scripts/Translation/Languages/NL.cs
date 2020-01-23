using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NL : Language
{
    void Start()
    {
        menuMainPlay = "Spelen";
        menuMainNewGame = "Nieuw Spel";
        menuMainOptions = "Opties";
        menuMainCredits = "Credits";
        menuMainExit = "Afsluiten";

        menuPlay1 = "Grootvaders tuin";
        menuPlay2 = "Grootvaders kantoor";
        menuPlay3 = "De Loods";

        menuOptionsGraphics = "Grafisch";
        menuOptionsSound = "Geluid";
        menuOptionsControls = "Besturing";
        menuOptionsLanguage = "Taal";

        menuGraphicsVeryLow = "";
        menuGraphicsLow = "";
        menuGraphicsMedium = "";
        menuGraphicsHigh = "";
        menuGraphicsVeryHigh = "";
        menuGraphicsUltra = "";
        menuGraphicsFullscreen = "Volledig scherm";

        // menuSound = "";

        menuControlsController = "Controller";
        menuControlsKeyboard = "Toetsenbord";

        menuConfirmNewGame = "Alle vrijgespeelde levels gaan verloren, weet je het zeker?";
        menuConfirmExit = "Weet je zeker dat je wilt afsluiten?";
        menuConfirmInGame = "Je level progressie gaat verloren, weet je het zeker?";

        menuCommonBack = "Vorige";
        menuCommonYes = "Ja";
        menuCommonNo = "Nee";

        menuResume = "Doorgaan";
        menuRestart = "Herstarten";
        menuMainMenu = "Hoofdmenu";

        // COMMON

        commonDoorLocked = "De deur zit op slot! Ik heb een sleutel nodig om deze te openen";
        commonDoorOpen = "Druk op <sprite=0> / <sprite=1> om de deur te openen";
        commonElevator = "Druk op <sprite=0> / <sprite=1> om de lift aan te zetten";
        commonRope = "Druk op <sprite=0> / <sprite=1> om aan het touw te trekken";
        commonBox = "Druk op <sprite=0> / <sprite=1> om de doos te duwen";

        commonKeyPickup = "Druk op <sprite=0> / <sprite=1> om de sleutel op te pakken";
        commonKeyPart = "Druk op <sprite=0> / <sprite=1> om een deel van een sleutel op te pakken";
        commonKeyDig = "Druk op <sprite=0> / <sprite=1> om een deel van een sleutel op te graven";
        commonKeyHuman = "Je pakt een deel van een sleutel op en stopt het in je broekzak";
        commonKeyCombine = "Je combineert alle sleutel delen om er een volledige van te maken";

        // TUTORIAL

        tutorialCommon = "Druk op <sprite=0> / <sprite=1> om de uitleg te lezen";

        tutorialPushHeader = "Push objects";
        tutorialPushMessageTop = "Press x to push an object with Kika";
        tutorialPushMessageBot = "For heavier objects you need Daigo to push as well!";

        tutorialNatureHeader = "Nature's call";
        tutorialNatureMessageTop = "Sometimes a dog has to take a leak with [button]";
        tutorialNatureMessageBot = "And yes... [button] does the rest";

        tutorialSnacksHeader = "Dog treats";
        tutorialSnacksMessageTop = "Press [x] near a dispenser for a dog treat";
        tutorialSnacksMessageBot = "These treats will make Daigo go faster!";

        tutorialUmbrellaHeader = "Umbrella";
        tutorialUmbrellaMessageTop = "Kika can open her umbrella with [button]";
        tutorialUmbrellaMessageBot = "Daigo can reach new heights by bouncing off the umbrella!";

        tutorialMoveMessageWalk = "Use [button] to walk around";
        tutorialMoveMessageLook = "Use [button] to look around";
        tutorialMoveMessageJump = "Press [button] to jump";

        // YARD

        yardSnacks = "Druk op <sprite=0> / <sprite=1> om een snack te eten";
        yardWrench = "Druk op <sprite=0> / <sprite=1> om de moersleutel op te pakken";
        yardFuseUse = "Druk op <sprite=0> / <sprite=1> om de elektriciteit in te schakelen";
        yardFuseFix = "De schakelaar is kapot, misschien kan ik hem repareren met een moersleutel";
        yardFuseFixed = "Tof, ik denk dat ik het gerepareerd heb! Misschien werkt de lift nu";

        // CITY

        cityBoxBig = "Druk op <sprite=0> / <sprite=1> om de grote doos te duwen";
        cityPoster = "Druk op <sprite=0> / <sprite=1> om de poster te bekijken";
        cityDoorHandleMiss = "De deur heeft geen hendel... Misschien is hij ergens anders";

        cityDoorHandleDig = "Druk op <sprite=0> / <sprite=1> om de deurhendel op te graven";
        cityDoorHandle = "Druk op <sprite=0> / <sprite=1> om de deurhendel op te pakken";

        // DOCKS

        docksToolBox = "Druk op <sprite=0> / <sprite=1> om de gereedschapskist op te pakken";
        docksBook = "Druk op <sprite=0> / <sprite=1> om het boek te lezen";
        docksVent = "Druk op <sprite=0> / <sprite=1> om het rooster te verwijderen";
        docksVentStuck = "Het rooster zit vast! Ik heb gereedschap nodig om het te openen";

        docksPipe = "Druk op <sprite=0> / <sprite=1> om de leidingen te repareren";
        docksPipeRotate = "draai pijp    <sprite=15><sprite=16> / <sprite=8><sprite=9>";
        docksPipeMove = "verplaats pijp    <sprite=12><sprite=21> / <sprite=7><sprite=4>";
        docksPipeSelect = "selecteer pijp    <sprite=14><sprite=18> / <sprite=5><sprite=6>";
    }

}
