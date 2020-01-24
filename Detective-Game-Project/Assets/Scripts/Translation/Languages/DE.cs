using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE : Language
{
    void Start()
    {
        menuMainPlay = "Spielen";
        menuMainNewGame = "Neu Spiel";
        menuMainOptions = "Optionen";
        menuMainCredits = "Credits";
        menuMainExit = "Beenden";

        menuPlay1 = "Großvater's Garten";
        menuPlay2 = "Großvater's Büro";
        menuPlay3 = "Der Schuppen";

        menuOptionsGraphics = "Grafik";
        menuOptionsSound = "Klang";
        menuOptionsControls = "Kontrollen";
        menuOptionsLanguage = "Sprachen";

        menuGraphicsFullscreen = "Vollbildmodus";

        menuSoundVolume = "Volumen";
        menuSoundMusic = "Musik";

        menuControlsController = "Controller";
        menuControlsKeyboard = "Tastatur";

        menuConfirmNewGame = "Alle freigeschalteten Levels gehen verloren, bist du sicher?";
        menuConfirmExit = "Bist du sicher dass du aufhören willst?";
        menuConfirmInGame = "Du verlierst deinen Fortschritt, bist du sicher?";

        menuCommonBack = "Zurück";
        menuCommonYes = "Ja";
        menuCommonNo = "Nein";

        menuResume = "Weiter spielen";
        menuRestart = "Neustarten";
        menuMainMenu = "Hauptmenü";

        // COMMON

        commonDoorLocked = "Die Tür ist verschlossen! Ich brauche eine Schlußel die Tür zu öffnen";
        commonDoorOpen = "Drück auf" + buttonX + "um die Tür zu öffnen";
        commonElevator = "Drück auf" + buttonX + "um den Aufzug ein zu schalten";
        commonRope = "Halt" + buttonX + "um an das Seil zu ziehen";
        commonBox = "Halt" + buttonX + "die Kiste zu schieben";

        commonKeyPickup = "Drück auf" + buttonX + "um der Schlüssel auf zu heben";
        commonKeyPart = "Drück auf" + buttonX + "um ein Schlüselstück auf zu heben";
        commonKeyDig = "Drück auf" + buttonX + "um ein Schlüse;stück aus zu graben";
        commonKeyHuman = "Du grabst ein Schlüsselstück und steckt es in deine Tasche";
        commonKeyCombine = "Du hast ein ganze Schlüssel gemacht mit die Schlüsselstücken";

        // TUTORIAL

        tutorialCommon = "Drück auf" + buttonX + "um die Erklärung zu lesen";

        tutorialPushHeader = "OBJEKTE SCHIEBEN"; //ALL CAPS
        tutorialPushMessageText = "Drück auf" + buttonX + "um ein Objekt zu schieben mit Kika" + space + "Für grösere Objekte muss Daigo auch helfen!";

        tutorialNatureHeader = "RUF DER NATUR"; //ALL CAPS
        tutorialNatureMessageText = "Manchmal soll ein Hund Druck ablassen"+ dogPee + space + "Und ja..." + dogPoo + "macht der Rest";

        tutorialSnacksHeader = "HUNDENKUCHEN"; //ALL CAPS
        tutorialSnacksMessageText = "Drück auf" + buttonX + "neben ein Süsigkeitenautomat für ein Hundenkuchen" + space + "Dieser Kuchen machen Daigo schneller!";

        tutorialUmbrellaHeader = "REGENSCHIRM"; //ALL CAPS
        tutorialUmbrellaMessageText = "Kika kann ihr Regenschirm öffnen mit" + tutUmbrella  + space + "Daigo kann neue Höhen erreichen wenn er auf dem Regenschirm springt";

        tutorialMoveMessageHeader = "BEWEGUNG"; //ALL CAPS
        tutorialMoveMessageText = "Nutz" + tutMove + "um zu laufen" + space + "Nutz" + tutLook + "um um sich zu sehen" + space + "Drück auf" + tutJump + "um zu springen";

        tutorialClose = close + "Schließen";

        // YARD

        yardSnacks = "Drück auf" + buttonX + "um ein Snack zu essen";
        yardWrench = "Drück auf" + buttonX + "um der Rollgabelschlüssel auf zu heben";
        yardFuseUse = "Drück auf" + buttonX + "um die Elektrizität ein zu schalten";
        yardFuseFix = "Der Schalter ist kaputt, vielleicht kann ich es reparieren mit ein Rollgabelschlüssel";
        yardFuseFixed = "Geil, ich glaube das es repariert ist! Vielleicht arbeitet der Aufzug jetzt";

        // CITY

        cityBoxBig = "Halt" + buttonX + "um die große Kiste zu schieben";
        cityPoster = "Drück auf" + buttonX + "um das Plakat zu sehen";
        cityDoorHandleMiss = "Die Tür hast keine Klinke... Er soll irgendwo liegen";

        cityDoorHandleDig = "Drück auf" + buttonX + "um die Türklinke aus zu graben";
        cityDoorHandle = "Drück auf" + buttonX + "um die Türklinke auf zu heben";

        // DOCKS

        docksToolBox = "Drück auf" + buttonX + "um der Werkzeugkasten auf zu heben";
        docksBook = "Drück auf" + buttonX + "um das Buch zu lesen";
        docksVent = "Drück auf" + buttonX + "um das Gitterrost zu entfernen";
        docksVentStuck = "Das Gitterrost sitzt fest! Ich brauche Arbeitsgeräte um das Gitterrost zu öffnen";

        docksPipe = "Drück auf" + buttonX + "um die Leitungen zu reparieren";
        docksPipeRotate = "Pfeife drehen" + pipeRotate;
        docksPipeMove = "Pfeife rangieren" + pipeMove;
        docksPipeSelect = "Pfeife selectieren" + pipeSelect;
    }

}
