using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FR : Language
{
    void Start()
    {
        menuMainPlay = "Jouer";
        menuMainNewGame = "Nouveau jeu";
        menuMainOptions = "Les options";
        menuMainCredits = "Crédits";
        menuMainExit = "Sortie";

        menuPlay1 = "Jardin de grand-père";
        menuPlay2 = "Bureau de grand-père";
        menuPlay3 = "L'entrepôt";

        menuOptionsGraphics = "Graphique";
        menuOptionsSound = "Du son";
        menuOptionsControls = "Contrôles";
        menuOptionsLanguage = "Langue";

        menuGraphicsFullscreen = "Plein écran";

        menuSoundVolume = "Du son";
        menuSoundMusic = "La musique";

        menuControlsController = "Manette";
        menuControlsKeyboard = "Clavier";

        menuConfirmNewGame = "Vous perdrez tous vos niveaux débloqués, êtes-vous sûr?";
        menuConfirmExit = "Êtes-vous sûr de vouloir quitter?";
        menuConfirmInGame = "Votre progression de niveau sera perdue, êtes-vous sûr?";

        menuCommonBack = "Retour";
        menuCommonYes = "Oui";
        menuCommonNo = "Non";

        menuResume = "Reprendre";
        menuRestart = "Redémarrer";
        menuMainMenu = "Menu";

        // COMMON

        commonDoorLocked = "La porte est verrouillée! J'ai besoin d'une clé pour l'ouvrir.";
        commonDoorOpen = "Appuyez sur" + buttonX + "pour ouvrir la porte.";
        commonElevator = "Appuyez sur" + buttonX + "pour déplacer l'ascenseur.";
        commonRope = "Maintenez" + buttonX + "pour tirer la corde.";
        commonBox = "Maintenez" + buttonX + "pour pousser la boîte.";

        commonKeyPickup = "Appuyez sur" + buttonX + "pour récupérer la clé.";
        commonKeyPart = "Appuyez sur" + buttonX + "pour récupérer une partie d'une touche.";
        commonKeyDig = "Appuyez sur" + buttonX + "pour déterrer une partie d'une touche.";
        commonKeyHuman = "Vous avez ramassé une partie d'une clé et l'avez mise dans votre poche.";
        commonKeyCombine = "Vous avez combiné toutes les parties d'une clé en une clé complète.";

        // TUTORIAL

        tutorialCommon = "Appuyez sur" + buttonX + "pour lire le message du didacticiel.";

        tutorialPushHeader = "POUSSER DES OBJECTS"; //ALL CAPS
        tutorialPushMessageText = "Maintenez" + buttonX + "pour pousser un objet avec Kika" + space + "Pour les objets plus lourds, vous devez également pousser Daigo!";

        tutorialNatureHeader = "L'APPEL DE LA NATURE"; //ALL CAPS
        tutorialNatureMessageText = "Parfois, un chien doit prendre une fuite avec" + dogPee + space + "Et oui ..." + dogPoo + "fait le reste";

        tutorialSnacksHeader = "FRIANDISES POUR CHIENS"; //ALL CAPS
        tutorialSnacksMessageText = "Appuyez sur" + buttonX + "près d'un distributeur pour une friandise pour chien" + space + "Ces friandises feront accélérer Daigo!";

        tutorialUmbrellaHeader = "PARAPLUIE"; //ALL CAPS
        tutorialUmbrellaMessageText = "Kika peut ouvrir son parapluie avec" + tutUmbrella  + space + "Daigo peut atteindre de nouveaux sommets en rebondissant sur le parapluie!";

        tutorialMoveMessageHeader = "MOUVEMENT"; //ALL CAPS
        tutorialMoveMessageText = "Utilisez" + tutMove + "pour vous promener" + space + "Utilisez" + tutLook + "pour regarder autour de vous" + space + "Appuyez sur" + tutJump + "pour sauter";

        tutorialClose = close + "Fermer";

        // YARD

        yardSnacks = "Appuyez sur" + buttonX + "pour manger un cookie.";
        yardWrench = "Appuyez sur" + buttonX + "pour ramasser la clé.";
        yardFuseUse = "Appuyez sur" + buttonX + "pour allumer l'électricité.";
        yardFuseFix = "L'interrupteur semble cassé, je peux peut-être le réparer avec une clé";
        yardFuseFixed = "Super, je pense que c'est réparé! Peut-être que l'ascenseur fonctionne maintenant.";

        // CITY

        cityBoxBig = "Maintenez" + buttonX + "pour pousser la grande boîte.";
        cityPoster = "Appuyez sur" + buttonX + "pour regarder l'affiche.";
        cityDoorHandleMiss = "La porte n'a pas de poignée ... Je me demande si je peux la trouver ailleurs.";

        cityDoorHandleDig = "Appuyez sur" + buttonX + "pour déterrer la poignée de porte.";
        cityDoorHandle = "Appuyez sur" + buttonX + "pour saisir la poignée de porte.";

        // DOCKS

        docksToolBox = "Appuyez sur" + buttonX + "pour récupérer la boîte à outils.";
        docksBook = "Appuyez sur" + buttonX + "pour lire le grand livre.";
        docksVent = "Appuyez sur" + buttonX + "pour ouvrir l'évent.";
        docksVentStuck = "L'évent est coincé! Peut-être que si j'avais un outil, je pourrais l'ouvrir.";

        docksPipe = "Appuyez sur" + buttonX + "pour réparer la tuyauterie.";
        docksPipeRotate = "Tournez le tuyau" + pipeRotate;
        docksPipeMove = "Sélectionnez la position" + pipeMove;
        docksPipeSelect = "Sélectionnez le tuyau" + pipeSelect;
    }
}