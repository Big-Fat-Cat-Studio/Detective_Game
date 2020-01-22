using System.Collections;
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

        [Header("YARD")]
        public GameObject yardBin;
        public GameObject yardWrench, yardSnacks, yardFuse, yardElevatorButton, yardRope, yardEndLevel;
        public GameObject yardKeyPart1, yardKeyPart2, yardKeyPart3, yardKeyFull;
        public GameObject tutorialMoveMessageWalk, tutorialMoveMessageLook, tutorialMoveMessageJump;
        public GameObject tutorialPush, tutorialPushHeader, tutorialPushMessageTop, tutorialPushMessageBot;
        public GameObject tutorialNature, tutorialNatureHeader, tutorialNatureMessageTop, tutorialNatureMessageBot;
        public GameObject tutorialSnacks, tutorialSnacksHeader, tutorialSnacksMessageTop, tutorialSnacksMessageBot;
        public GameObject tutorialUmbrella, tutorialUmbrellaHeader, tutorialUmbrellaMessageTop, tutorialUmbrellaMessageBot;

        [Header("CITY")]
        public GameObject cityBox;
        public GameObject cityKeyPart1, cityKeyPart2, cityKeyPart3, cityKeyFull;
        public GameObject cityDoorBroken, cityDoorHandle, cityDoorEnd;

        [Header("WAREHOUSE")]


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
            // Debug.Log(scene);
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
                // tutorialMoveMessageWalk.GetComponent<Text>().text = "";
                // tutorialMoveMessageLook.GetComponent<Text>().text = "";
                // tutorialMoveMessageJump.GetComponent<Text>().text = "";

                tutorialPush.GetComponent<InteractableObject>().interactMessage = language.tutorialCommon;
                // tutorialPushHeader.GetComponent<Text>().text = "";
                // tutorialPushMessageTop.GetComponent<Text>().text = "";
                // tutorialPushMessageBot.GetComponent<Text>().text = "";

                tutorialNature.GetComponent<InteractableObject>().interactMessage = language.tutorialCommon;
                // tutorialNatureHeader.GetComponent<Text>().text = "";
                // tutorialNatureMessageTop.GetComponent<Text>().text = "";
                // tutorialNatureMessageBot.GetComponent<Text>().text = "";

                tutorialSnacks.GetComponent<InteractableObject>().interactMessage = language.tutorialCommon;
                // tutorialSnacksHeader.GetComponent<Text>().text = "";
                // tutorialSnacksMessageTop.GetComponent<Text>().text = "";
                // tutorialSnacksMessageBot.GetComponent<Text>().text = "";

                tutorialUmbrella.GetComponent<InteractableObject>().interactMessage = language.tutorialCommon;
                // tutorialUmbrellaHeader.GetComponent<Text>().text = "";
                // tutorialUmbrellaMessageTop.GetComponent<Text>().text = "";
                // tutorialUmbrellaMessageBot.GetComponent<Text>().text = "";

                yardBin.GetComponent<InteractableObject>().interactMessage = language.yardBin;
                yardWrench.GetComponent<InteractableObject>().interactMessage = language.yardWrench;
                yardSnacks.GetComponent<InteractableObject>().interactMessage = language.yardSnacks;
                yardFuse.GetComponent<InteractableObject>().interactMessage = language.yardFuseUse;
                yardFuse.GetComponent<InteractChangeState>().afterInteractMessage = language.yardFuseFix;
                yardFuse.GetComponent<InteractChangeState>().textFixed = language.yardFuseFixed;
                yardElevatorButton.GetComponent<InteractableObject>().interactMessage = language.yardElevatorButton;
                yardRope.GetComponent<InteractableObject>().interactMessage = language.yardRope;
                yardEndLevel.GetComponent<InteractableObject>().interactMessage = language.yardKeyUse;
                yardEndLevel.GetComponent<EndLevelWithItem>().afterInteractMessage = language.yardEndLevel;

                yardKeyPart1.GetComponent<InteractableObject>().interactMessage = language.yardKeyPart;
                yardKeyPart1.GetComponent<Key>().humanKeyPickUpText = language.yardKeyHuman;
                yardKeyPart1.GetComponent<Key>().combineIntoFullItemText = language.yardKeyCombine;

                yardKeyPart2.GetComponent<InteractableObject>().interactMessage = language.yardKeyPart;
                yardKeyPart2.GetComponent<Key>().humanKeyPickUpText = language.yardKeyHuman;
                yardKeyPart2.GetComponent<Key>().combineIntoFullItemText = language.yardKeyCombine;

                yardKeyPart3.GetComponent<InteractableObject>().interactMessage = language.yardKeyDig;
                yardKeyPart3.GetComponent<Key>().humanKeyPickUpText = language.yardKeyHuman;
                yardKeyPart3.GetComponent<Key>().combineIntoFullItemText = language.yardKeyCombine;
                yardKeyPart3.GetComponent<DigKeyItem>().pickUpItemText = language.yardKeyPart;

                yardKeyFull.GetComponent<InteractableObject>().interactMessage = language.yardKeyFull;
            }

            if (scene == 2)
            {
                cityBox.GetComponent<InteractableObject>().interactMessage = language.yardBin;

                cityKeyPart1.GetComponent<InteractableObject>().interactMessage = language.yardKeyPart;
                cityKeyPart1.GetComponent<Key>().humanKeyPickUpText = language.yardKeyHuman;
                cityKeyPart1.GetComponent<Key>().combineIntoFullItemText = language.yardKeyCombine;

                cityKeyPart2.GetComponent<InteractableObject>().interactMessage = language.yardKeyPart;
                cityKeyPart2.GetComponent<Key>().humanKeyPickUpText = language.yardKeyHuman;
                cityKeyPart2.GetComponent<Key>().combineIntoFullItemText = language.yardKeyCombine;

                cityKeyPart3.GetComponent<InteractableObject>().interactMessage = language.yardKeyPart;
                cityKeyPart3.GetComponent<Key>().humanKeyPickUpText = language.yardKeyHuman;
                cityKeyPart3.GetComponent<Key>().combineIntoFullItemText = language.yardKeyCombine;

                cityKeyFull.GetComponent<InteractableObject>().interactMessage = language.yardKeyFull;

                cityDoorBroken.GetComponent<InteractableObject>().interactMessage = language.cityDoorOpen;
                cityDoorBroken.GetComponent<Door>().afterInteractMessage = language.cityDoorHandleMiss;

                cityDoorHandle.GetComponent<InteractableObject>().interactMessage = language.cityDoorHandleDig;
                cityDoorHandle.GetComponent<DigItem>().pickUpItemText = language.cityDoorHandle;

                cityDoorEnd.GetComponent<InteractableObject>().interactMessage = language.cityDoorOpen;
                cityDoorEnd.GetComponent<EndLevelWithItem>().afterInteractMessage = language.cityDoorLocked;
            }
        }
    }
}
