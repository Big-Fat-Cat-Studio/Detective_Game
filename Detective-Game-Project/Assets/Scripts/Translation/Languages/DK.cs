using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DK : Language
{
    void Start()
    {
        menuMainPlay = "Spil videre";
        menuMainNewGame = "Nyt Spil";
        menuMainOptions = "Indstillinger";
        menuMainCredits = "Anerkendelser";
        menuMainExit = "Afslut";

        menuPlay1 = "Bedstefars have";
        menuPlay2 = "Bedstefars kontor";
        menuPlay3 = "Lageret";

        menuOptionsGraphics = "Grafikindstillinger";
        menuOptionsSound = "Lydindstillinger";
        menuOptionsControls = "Styringsindstillinger";
        menuOptionsLanguage = "Sprog";

        menuGraphicsFullscreen = "Fuld skærm";

        menuSoundVolume = "Lydniveau";
        menuSoundMusic = "Musik";

        menuControlsController = "Controller";
        menuControlsKeyboard = "Tastatur";

        menuConfirmNewGame = "De baner du har gennemført vil blive glemt, er du sikker?";
        menuConfirmExit = "Er du sikker på at du ønsker at afslutte?";
        menuConfirmInGame = "Du vil miste adgang til de baner du har låst op, er du sikker?";

        menuCommonBack = "Tilbage til forrige menu";
        menuCommonYes = "Ja";
        menuCommonNo = "Nej";

        menuResume = "Tilbage til spillet";
        menuRestart = "Genstart";
        menuMainMenu = "Menu";

        // COMMON

        commonDoorLocked = "Døren er låst! Jeg skal bruge en nøgle for at låse den op.";
        commonDoorOpen = "Tryk" + buttonX + "for at åbne døren";
        commonElevator = "Tryk" + buttonX + "for at starte elevatoren";
        commonRope = "Hold" + buttonX + "inde for at trække rebet ned";
        commonBox = "Hold" + buttonX + "inde for at skubbe kassen";

        commonKeyPickup = "Tryk" + buttonX + "for at samle nøglen op";
        commonKeyPart = "Tryk" + buttonX + "for at samle et stykke af en nøgle op";
        commonKeyDig = "Tryk" + buttonX + "for at grave et stykke af en nøgle op";
        commonKeyHuman = "Du har samlet et stykke af en nøgle op og lagt den i din lomme";
        commonKeyCombine = "Du har samlet alle stykkerne sammen til en færdig nøgle";

        // TUTORIAL
        
        tutorialCommon = "Tryk" + buttonX + "for at læse brugervejledningen";

        tutorialPushHeader = "SKUB GENSTANDE"; //ALL CAPS
        tutorialPushMessageText = "Tryk" + buttonX + "for at skubbe en genstand med Kika" + space + "Ved tungere genstande må du få Daigo til at også at skubbe med!";

        tutorialNatureHeader = "NATUREN KALDER"; //ALL CAPS
        tutorialNatureMessageText = "Somme tider skal en hund tisse ved hjælp af" + dogPee + space + "Og ja... " + dogPoo + "klarer resten";

        tutorialSnacksHeader = "HUNDEKIKS"; //ALL CAPS
        tutorialSnacksMessageText = "Tryk" + buttonX + "i nærheden af en kikseautomat for at få en hundekiks" + space + "Disse kiks vil gøre Daigo hurtigere!";

        tutorialUmbrellaHeader = "PARAPLY"; //ALL CAPS
        tutorialUmbrellaMessageText = "Kika kan slå sin paraply ud ved hjælp af" + tutUmbrella  + space + "Daigo kan nå op i større højder ved at hoppe fra paraplyen!";

        tutorialMoveMessageHeader = "Bevægelse"; //ALL CAPS
        tutorialMoveMessageText = "Brug" + tutMove + "for at gå rundt" + space + "Brug" + tutLook + "for at kigge rundt" + space + "Tryk" + tutJump + "for at hoppe";

        tutorialClose = close + "Luk";

        // YARD

        yardSnacks = "Tryk" + buttonX + "for at spise en hundekiks";
        yardWrench = "Tryk" + buttonX + "for at samle skruenøglen op";
        yardFuseUse = "Tryk" + buttonX + "for at kigge på guiden";
        yardFuseFix = "Afbryderen er defekt, jeg kan måske reparere den med en skruenøgle";
        yardFuseFixed = "Sådan, jeg tror at den er ordnet! Måske virker elevatoren nu";

        // CITY

        cityBoxBig = "Hold" + buttonX + "inde for at skubbe en stor kasse";
        cityPoster = "Tryk" + buttonX + "at se på plakaten";
        cityDoorHandleMiss = "Døren mangler et håndtag… Gad vide om jeg kan finde den et andet sted";

        cityDoorHandleDig = "Tryk" + buttonX + "for at grave et dørhåndtag op";
        cityDoorHandle = "Tryk" + buttonX + "for at samle dørhåndtaget op";

        // DOCKS

        docksToolBox = "Tryk" + buttonX + "for at samle værktøjskassen op";
        docksBook = "Tryk" + buttonX + "for at kigge i bogen";
        docksVent = "Tryk" + buttonX + "for at åbne ventilationskanalen";
        docksVentStuck = "Risten sidder fast! Måske kunne jeg åbne den hvis jeg havde et redskab";

        docksPipe = "Tryk" + buttonX + "for at reparere rørsystemet";
        docksPipeRotate = "Vend rør" + pipeRotate;
        docksPipeMove = "Vælg placering" + pipeMove;
        docksPipeSelect = "Vælg rør" + pipeSelect;
    }

}
