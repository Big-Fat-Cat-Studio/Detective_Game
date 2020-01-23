﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace Scripts
{
    public class Translator : MonoBehaviour
    {
        [Header("TITLESCREEN")]
        public GameObject menuMainPlay;
        public GameObject menuMainNewGame, menuMainOptions, menuMainCredits, menuMainExit;
        public GameObject menuPlay1, menuPlay2, menuPlay3, menuPlayBack;
        public GameObject menuOptionsGraphics, menuOptionsSound, menuOptionsControls, menuOptionsLanguage, menuOptionsBack;
        public GameObject menuGraphicsFullscreen, menuGraphicsBack;
        public GameObject menuControlsPlayer1, menuControlsPlayer2, menuControlsBack;
        public GameObject menuConfirmNewGame, menuConfirmNewGameYes, menuConfirmNewGameNo;
        public GameObject menuConfirmExit, menuConfirmExitYes, menuConfirmExitNo;

        [Header("INGAMEMENU")]
        public GameObject menuInGameResume;
        public GameObject menuInGameOptions, menuInGameRestart, menuInGameMainMenu;
        public GameObject menuInGameConfirmRestart, menuInGameConfirmRestartYes, menuInGameConfirmRestartNo;
        public GameObject menuInGameConfirmMainMenu, menuInGameConfirmMainMenuYes, menuInGameConfirmMainMenuNo;

        [Header("TUTORIAL")]
        public GameObject tutorialMoveMessageHeader;
        public GameObject tutorialMoveMessageText, tutorialMoveClose;
        public GameObject tutorialPush, tutorialPushHeader, tutorialPushMessageText, tutorialPushClose;
        public GameObject tutorialNature, tutorialNatureHeader, tutorialNatureMessageText, tutorialNatureClose;
        public GameObject tutorialSnacks, tutorialSnacksHeader, tutorialSnacksMessageText, tutorialSnacksClose;
        public GameObject tutorialUmbrella, tutorialUmbrellaHeader, tutorialUmbrellaMessageText, tutorialUmbrellaClose;

        [Header("YARD")]
        public GameObject yardBin;
        public GameObject yardWrench, yardSnacks, yardFuse, yardElevatorButton, yardRope, yardEndLevel;
        public GameObject yardKeyPart1, yardKeyPart2, yardKeyPart3, yardKeyFull;

        [Header("CITY")]
        public GameObject cityBox;
        public GameObject cityBoxBig, cityPoster;
        public GameObject cityKeyPart1, cityKeyPart2, cityKeyPart3, cityKeyFull;
        public GameObject cityDoorBroken, cityDoorHandle, cityDoorEnd;

        [Header("WAREHOUSE")]
        public GameObject docksButton;
        public GameObject docksToolBox, docksVent, docksKey1, docksKey2, docksBook, docksRope;
        public GameObject docksDoorOpen, docksDoorLocked1, docksDoorLocked2;
        public GameObject docksPipe, docksPipeRotate, docksPipeMove, docksPipeSelect;


        Language language;

        void Start()
        {
            string lang = "NL";
            switch (lang)
            {
                // case "EN":
                //     selected = gameObject.GetComponent<EN>();
                //     break;
                case "NL":
                    language = gameObject.GetComponent<NL>();
                    break;
                // case "DK":
                //     selected = gameObject.GetComponent<DK>();
                //     break;
            }
            Translate();
        }

        void OnEnable()
        {
            string lang = "NL";
            switch (lang)
            {
                // case "EN":
                //     selected = gameObject.GetComponent<EN>();
                //     break;
                case "NL":
                    language = gameObject.GetComponent<NL>();
                    break;
                // case "DK":
                //     selected = gameObject.GetComponent<DK>();
                //     break;
            }
            Translate();
        }

        public void Translate()
        {
            int scene = SceneManager.GetActiveScene().buildIndex;

            if (scene == 0)
            {
                menuMainPlay.GetComponentInChildren<TMP_Text>().text = language.menuMainPlay;
                menuMainNewGame.GetComponentInChildren<TMP_Text>().text = language.menuMainNewGame;
                menuMainOptions.GetComponentInChildren<TMP_Text>().text = language.menuMainOptions;
                menuMainCredits.GetComponentInChildren<TMP_Text>().text = language.menuMainCredits;
                menuMainExit.GetComponentInChildren<TMP_Text>().text = language.menuMainExit;

                menuPlay1.GetComponentInChildren<TMP_Text>().text = language.menuPlay1;
                menuPlay2.GetComponentInChildren<TMP_Text>().text = language.menuPlay2;
                menuPlay3.GetComponentInChildren<TMP_Text>().text = language.menuPlay3;
                menuPlayBack.GetComponentInChildren<TMP_Text>().text = language.menuCommonBack;

                menuOptionsGraphics.GetComponentInChildren<TMP_Text>().text = language.menuOptionsGraphics;
                menuOptionsSound.GetComponentInChildren<TMP_Text>().text = language.menuOptionsSound;
                menuOptionsControls.GetComponentInChildren<TMP_Text>().text = language.menuOptionsControls;
                menuOptionsLanguage.GetComponentInChildren<TMP_Text>().text = language.menuOptionsLanguage;
                menuOptionsBack.GetComponentInChildren<TMP_Text>().text = language.menuCommonBack;

                menuGraphicsFullscreen.GetComponentInChildren<TMP_Text>().text = language.menuGraphicsFullscreen;
                menuGraphicsBack.GetComponentInChildren<TMP_Text>().text = language.menuCommonBack;

                menuControlsPlayer1.GetComponent<TMP_Dropdown>().options[0].text = language.menuControlsController;
                menuControlsPlayer1.GetComponent<TMP_Dropdown>().options[1].text = language.menuControlsKeyboard;
                menuControlsPlayer2.GetComponent<TMP_Dropdown>().options[0].text = language.menuControlsController;
                menuControlsPlayer2.GetComponent<TMP_Dropdown>().options[1].text = language.menuControlsKeyboard;
                menuControlsBack.GetComponentInChildren<TMP_Text>().text = language.menuCommonBack;

                menuConfirmNewGame.GetComponentInChildren<TMP_Text>().text = language.menuConfirmNewGame;
                menuConfirmNewGameYes.GetComponentInChildren<TMP_Text>().text = language.menuCommonYes;
                menuConfirmNewGameNo.GetComponentInChildren<TMP_Text>().text = language.menuCommonNo;

                menuConfirmExit.GetComponentInChildren<TMP_Text>().text = language.menuConfirmExit;
                menuConfirmExitYes.GetComponentInChildren<TMP_Text>().text = language.menuCommonYes;
                menuConfirmExitNo.GetComponentInChildren<TMP_Text>().text = language.menuCommonNo;
            }

            if (scene == 1 || scene == 2 || scene == 3)
            {
                menuInGameResume.GetComponentInChildren<Text>().text = language.menuResume;
                menuInGameOptions.GetComponentInChildren<Text>().text = language.menuMainOptions;
                menuInGameRestart.GetComponentInChildren<Text>().text = language.menuRestart;
                menuInGameMainMenu.GetComponentInChildren<Text>().text = language.menuMainMenu;

                menuInGameConfirmRestart.GetComponentInChildren<TMP_Text>().text = language.menuConfirmInGame;
                menuInGameConfirmRestartYes.GetComponentInChildren<TMP_Text>().text = language.menuCommonYes;
                menuInGameConfirmRestartNo.GetComponentInChildren<TMP_Text>().text = language.menuCommonNo;

                menuInGameConfirmMainMenu.GetComponentInChildren<TMP_Text>().text = language.menuConfirmInGame;
                menuInGameConfirmMainMenuYes.GetComponentInChildren<TMP_Text>().text = language.menuCommonYes;
                menuInGameConfirmMainMenuNo.GetComponentInChildren<TMP_Text>().text = language.menuCommonNo;
            }

            if (scene == 1)
            {
                tutorialMoveMessageHeader.GetComponent<TMP_Text>().text = language.tutorialMoveMessageHeader;
                tutorialMoveMessageText.GetComponent<TMP_Text>().text = language.tutorialMoveMessageText;
                tutorialMoveClose.GetComponent<TMP_Text>().text = language.tutorialClose;

                tutorialPush.GetComponent<InteractableObject>().interactMessage = language.tutorialCommon;
                tutorialPushHeader.GetComponent<TMP_Text>().text = language.tutorialPushHeader;
                tutorialPushMessageText.GetComponent<TMP_Text>().text = language.tutorialPushMessageText;
                tutorialPushClose.GetComponent<TMP_Text>().text = language.tutorialClose;

                tutorialNature.GetComponent<InteractableObject>().interactMessage = language.tutorialCommon;
                tutorialNatureHeader.GetComponent<TMP_Text>().text = language.tutorialNatureHeader;
                tutorialNatureMessageText.GetComponent<TMP_Text>().text = language.tutorialNatureMessageText;
                tutorialNatureClose.GetComponent<TMP_Text>().text = language.tutorialClose;

                tutorialSnacks.GetComponent<InteractableObject>().interactMessage = language.tutorialCommon;
                tutorialSnacksHeader.GetComponent<TMP_Text>().text = language.tutorialSnacksHeader;
                tutorialSnacksMessageText.GetComponent<TMP_Text>().text = language.tutorialSnacksMessageText;
                tutorialSnacksClose.GetComponent<TMP_Text>().text = language.tutorialClose;

                tutorialUmbrella.GetComponent<InteractableObject>().interactMessage = language.tutorialCommon;
                tutorialUmbrellaHeader.GetComponent<TMP_Text>().text = language.tutorialUmbrellaHeader;
                tutorialUmbrellaMessageText.GetComponent<TMP_Text>().text = language.tutorialUmbrellaMessageText;
                tutorialUmbrellaClose.GetComponent<TMP_Text>().text = language.tutorialClose;

                yardBin.GetComponent<InteractableObject>().interactMessage = language.commonBox;
                yardWrench.GetComponent<InteractableObject>().interactMessage = language.yardWrench;
                yardSnacks.GetComponent<InteractableObject>().interactMessage = language.yardSnacks;
                yardFuse.GetComponent<InteractableObject>().interactMessage = language.yardFuseUse;
                yardFuse.GetComponent<InteractChangeState>().afterInteractMessage = language.yardFuseFix;
                yardFuse.GetComponent<InteractChangeState>().textFixed = language.yardFuseFixed;
                yardElevatorButton.GetComponent<InteractableObject>().interactMessage = language.commonElevator;
                yardRope.GetComponent<InteractableObject>().interactMessage = language.commonRope;
                yardEndLevel.GetComponent<InteractableObject>().interactMessage = language.commonDoorOpen;
                yardEndLevel.GetComponent<EndLevelWithItem>().afterInteractMessage = language.commonDoorLocked;

                yardKeyPart1.GetComponent<InteractableObject>().interactMessage = language.commonKeyPart;
                yardKeyPart1.GetComponent<Key>().humanKeyPickUpText = language.commonKeyHuman;
                yardKeyPart1.GetComponent<Key>().combineIntoFullItemText = language.commonKeyCombine;

                yardKeyPart2.GetComponent<InteractableObject>().interactMessage = language.commonKeyPart;
                yardKeyPart2.GetComponent<Key>().humanKeyPickUpText = language.commonKeyHuman;
                yardKeyPart2.GetComponent<Key>().combineIntoFullItemText = language.commonKeyCombine;

                yardKeyPart3.GetComponent<InteractableObject>().interactMessage = language.commonKeyDig;
                yardKeyPart3.GetComponent<Key>().humanKeyPickUpText = language.commonKeyHuman;
                yardKeyPart3.GetComponent<Key>().combineIntoFullItemText = language.commonKeyCombine;
                yardKeyPart3.GetComponent<DigKeyItem>().pickUpItemText = language.commonKeyPart;

                yardKeyFull.GetComponent<InteractableObject>().interactMessage = language.commonKeyPickup;
            }

            if (scene == 2)
            {
                cityBox.GetComponent<InteractableObject>().interactMessage = language.commonBox;
                cityBoxBig.GetComponent<InteractableObject>().interactMessage = language.cityBoxBig;
                cityPoster.GetComponent<InteractableObject>().interactMessage = language.cityPoster;

                cityKeyPart1.GetComponent<InteractableObject>().interactMessage = language.commonKeyPart;
                cityKeyPart1.GetComponent<Key>().humanKeyPickUpText = language.commonKeyHuman;
                cityKeyPart1.GetComponent<Key>().combineIntoFullItemText = language.commonKeyCombine;

                cityKeyPart2.GetComponent<InteractableObject>().interactMessage = language.commonKeyPart;
                cityKeyPart2.GetComponent<Key>().humanKeyPickUpText = language.commonKeyHuman;
                cityKeyPart2.GetComponent<Key>().combineIntoFullItemText = language.commonKeyCombine;

                cityKeyPart3.GetComponent<InteractableObject>().interactMessage = language.commonKeyPart;
                cityKeyPart3.GetComponent<Key>().humanKeyPickUpText = language.commonKeyHuman;
                cityKeyPart3.GetComponent<Key>().combineIntoFullItemText = language.commonKeyCombine;

                cityKeyFull.GetComponent<InteractableObject>().interactMessage = language.commonKeyPickup;

                cityDoorBroken.GetComponent<InteractableObject>().interactMessage = language.commonDoorOpen;
                cityDoorBroken.GetComponent<Door>().afterInteractMessage = language.cityDoorHandleMiss;

                cityDoorHandle.GetComponent<InteractableObject>().interactMessage = language.cityDoorHandleDig;
                cityDoorHandle.GetComponent<DigItem>().pickUpItemText = language.cityDoorHandle;

                cityDoorEnd.GetComponent<InteractableObject>().interactMessage = language.commonDoorOpen;
                cityDoorEnd.GetComponent<EndLevelWithItem>().afterInteractMessage = language.commonDoorLocked;
            }

            if (scene == 3)
            {
                docksButton.GetComponent<InteractableObject>().interactMessage = language.commonElevator;
                docksToolBox.GetComponent<InteractableObject>().interactMessage = language.docksToolBox;
                docksBook.GetComponent<InteractableObject>().interactMessage = language.docksBook;
                docksRope.GetComponent<InteractableObject>().interactMessage = language.commonRope;

                docksKey1.GetComponent<InteractableObject>().interactMessage = language.commonKeyPickup;
                docksKey2.GetComponent<InteractableObject>().interactMessage = language.commonKeyPickup;

                docksVent.GetComponent<InteractableObject>().interactMessage = language.docksVent;
                docksVent.GetComponent<DestroyableObject>().afterInteractMessage = language.docksVentStuck;

                docksDoorOpen.GetComponent<InteractableObject>().interactMessage = language.commonDoorOpen;
                docksDoorLocked1.GetComponent<InteractableObject>().interactMessage = language.commonDoorOpen;
                docksDoorLocked1.GetComponent<Door>().afterInteractMessage = language.commonDoorLocked;
                docksDoorLocked2.GetComponent<InteractableObject>().interactMessage = language.commonDoorOpen;
                docksDoorLocked2.GetComponent<Door>().afterInteractMessage = language.commonDoorLocked;

                docksPipe.GetComponent<InteractableObject>().interactMessage = language.docksPipe;
                docksPipeRotate.GetComponentInChildren<TMP_Text>().text = language.docksPipeRotate;
                docksPipeMove.GetComponentInChildren<TMP_Text>().text = language.docksPipeMove;
                docksPipeSelect.GetComponentInChildren<TMP_Text>().text = language.docksPipeSelect;
            }
        }
    }
}
