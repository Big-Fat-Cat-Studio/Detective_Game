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

        // YARD

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


        yardBin = "Druk op <sprite=0> / <sprite=1> om de doos te duwen";
        yardSnacks = "Druk op <sprite=0> / <sprite=1> om een snack te eten";
        yardWrench = "Druk op <sprite=0> / <sprite=1> om de moersleutel op te pakken";
        yardFuseUse = "Druk op <sprite=0> / <sprite=1> om de elektriciteit in te schakelen";
        yardFuseFix = "De schakelaar is kapot, misschien kan ik hem repareren met een moersleutel";
        yardElevatorButton = "Druk op <sprite=0> / <sprite=1> om de lift aan te zetten";
        yardRope = "Druk op <sprite=0> / <sprite=1> om aan het touw te trekken";
        yardEndLevel = "De deur zit op slot! Ik heb een sleutel nodig om deze te openen";

        yardKeyUse = "Druk op <sprite=0> / <sprite=1> om de deur te openen";
        yardKeyPart = "Druk op <sprite=0> / <sprite=1> om een deel van een sleutel op te pakken";
        yardKeyDig = "Druk op <sprite=0> / <sprite=1> om een deel van een sleutel op te graven";
        yardKeyHuman = "Je pakt een deel van een sleutel op en stopt het in je broekzak";
        yardKeyCombine = "Je combineert alle sleutel delen om er een volledige van te maken";


    }

}
