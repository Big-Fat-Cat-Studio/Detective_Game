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

        menuGraphicsFullscreen = "Volledig scherm";

        menuSoundVolume = "volume";
        menuSoundMusic = "muziek";

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
        commonDoorOpen = "Druk op" + buttonX + "om de deur te openen";
        commonElevator = "Druk op" + buttonX + "om de lift aan te zetten";
        commonRope = "Druk op" + buttonX + "om aan het touw te trekken";
        commonBox = "Druk op" + buttonX + "om de doos te duwen";

        commonKeyPickup = "Druk op" + buttonX + "om de sleutel op te pakken";
        commonKeyPart = "Druk op" + buttonX + "om een deel van een sleutel op te pakken";
        commonKeyDig = "Druk op" + buttonX + "om een deel van een sleutel op te graven";
        commonKeyHuman = "Je pakt een deel van een sleutel op en stopt het in je broekzak";
        commonKeyCombine = "Je combineert alle sleutel delen om er een volledige van te maken";

        // TUTORIAL

        tutorialCommon = "Druk op" + buttonX + "om de uitleg te lezen";

        tutorialPushHeader = "OBJECTEN DUWEN";
        tutorialPushMessageText = "Druk op" + buttonX + "om een object te duwen met Kika" + space + "Voor zwaardere objecten heb je Daigo ook nodig!";

        tutorialNatureHeader = "HOND UITLATEN";
        tutorialNatureMessageText = "Soms moet een hond een plasje plegen"+ dogPee + space + "En ja..." + dogPoo + "doet de rest";

        tutorialSnacksHeader = "HONDEN SNOEPJES";
        tutorialSnacksMessageText = "Druk op" + buttonX + "naast een snoepautomaat voor een honden snoepje" + space + "Deze snoepjes maken Daigo sneller!";

        tutorialUmbrellaHeader = "PARAPLU";
        tutorialUmbrellaMessageText = "Kika kan haar paraplu openen met" + tutUmbrella  + space + "Daigo kan nieuwe hoogtes berereiken door op de paraplu te springen";

        tutorialMoveMessageHeader = "BEWEGING";
        tutorialMoveMessageText = "Gebruik" + tutMove + "om te lopen" + space + "Gebruik" + tutLook + "om rond te kijken" + space + "Druk op" + tutJump + "om te springen";

        tutorialClose = close + "Sluiten";

        // YARD

        yardSnacks = "Druk op" + buttonX + "om een snack te eten";
        yardWrench = "Druk op" + buttonX + "om de moersleutel op te pakken";
        yardFuseUse = "Druk op" + buttonX + "om de elektriciteit in te schakelen";
        yardFuseFix = "De schakelaar is kapot, misschien kan ik hem repareren met een moersleutel";
        yardFuseFixed = "Tof, ik denk dat ik het gerepareerd heb! Misschien werkt de lift nu";

        // CITY

        cityBoxBig = "Druk op" + buttonX + "om de grote doos te duwen";
        cityPoster = "Druk op" + buttonX + "om de poster te bekijken";
        cityDoorHandleMiss = "De deur heeft geen hendel... Misschien is hij ergens anders";

        cityDoorHandleDig = "Druk op" + buttonX + "om de deurhendel op te graven";
        cityDoorHandle = "Druk op" + buttonX + "om de deurhendel op te pakken";

        // DOCKS

        docksToolBox = "Druk op" + buttonX + "om de gereedschapskist op te pakken";
        docksBook = "Druk op" + buttonX + "om het boek te lezen";
        docksVent = "Druk op" + buttonX + "om het rooster te verwijderen";
        docksVentStuck = "Het rooster zit vast! Ik heb gereedschap nodig om het te openen";

        docksPipe = "Druk op" + buttonX + "om de leidingen te repareren";
        docksPipeRotate = "draai pijp" + pipeRotate;
        docksPipeMove = "verplaats pijp" + pipeMove;
        docksPipeSelect = "selecteer pijp" + pipeSelect;
    }

}
