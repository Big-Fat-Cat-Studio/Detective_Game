using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KR : Language
{
    void Start()
    {
        menuMainPlay = "시작하기";
        menuMainNewGame = "새 게임";
        menuMainOptions = "옵션";
        menuMainCredits = "크레딧";
        menuMainExit = "출구";

        menuPlay1 = "할아버지의 정원";
        menuPlay2 = "할아버지의 사무실";
        menuPlay3 = "창고";

        menuOptionsGraphics = "그래픽";
        menuOptionsSound = "소리";
        menuOptionsControls = "제어장치";
        menuOptionsLanguage = "언어";

        menuGraphicsFullscreen = "전체 화면";

        menuSoundVolume = "음량";
        menuSoundMusic = "음악";

        menuControlsController = "컨트롤러";
        menuControlsKeyboard = "키보드";

        menuConfirmNewGame = "당신의 잠금해제한 레벨을 잃게 됩니다, 정말 종료하시겠습니까?";
        menuConfirmExit = "종료하시겠습니까?";
        menuConfirmInGame = "경험치를 잃게 됩니다, 정말 종료하시겠습니까?";

        menuCommonBack = "뒤로가기";
        menuCommonYes = "예";
        menuCommonNo = "아니오";

        menuResume = "다시하기";
        menuRestart = "재시작";
        menuMainMenu = "메인 메뉴";

        // COMMON

        commonDoorLocked = "문이 잠겨있어! 이걸  열기 위해서는 열쇠가 필요해.";
        commonDoorOpen = "문을 열려면" + buttonX + "를 누르세요.";
        commonElevator = "엘레베이터의 전원을 켜려면" + buttonX + "를 누르세요.";
        commonRope = "밧줄을 끌어 내리려면" + buttonX + "를 계속 누르고 있으세요.";
        commonBox = "상자를 밀려면" + buttonX + "를 계속 누르고 있으세요.";

        commonKeyPickup = "열쇠를 집어 올리려면" + buttonX + "를 누르세요.";
        commonKeyPart = "열쇠를 집어 올리려면" + buttonX + "를 누르세요.";
        commonKeyDig = "열쇠의 일부를 캐내려면" + buttonX + "를 누르세요.";
        commonKeyHuman = "열쇠의 일부를 집어서 포켓에 넣으세요.";
        commonKeyCombine = "열쇠의 일부들을 하나의 전체 열쇠로 결합했습니다.";

        // TUTORIAL

        tutorialCommon = "튜토리얼 메세지를 읽으려면" + buttonX + "를 누르세요.";

        tutorialPushHeader = "물체 밀기";
        tutorialPushMessageText = "키카가 물체를 밀기 위해서" + buttonX + "를 누르세요" + space + "무거운 물체를 밀기 위해서는 다이고도 필요합니다!";

        tutorialNatureHeader = "자연의 부름";
        tutorialNatureMessageText = "가끔씩 "+ dogPee + "을 눌러 강아지가 소변을 보도록 해야합니다." + space + "그렇습니다... " + dogPoo + "은 휴식을 하도록 합니다.";

        tutorialSnacksHeader = "강아지용 쿠키";
        tutorialSnacksMessageText = "강아지용 쿠키 디스펜서 근처의" + buttonX + "를 누르세요" + space + "강아지용 쿠키는 다이고가 더 빠르게 이동하도록 합니다!";

        tutorialUmbrellaHeader = "우산";
        tutorialUmbrellaMessageText = "키카는 " + tutUmbrella + "을 사용하여 우산을 펼칠 수 있습니다." + space + "다이고는 우산을 튕겨서 새로운 높이에 도달할 수 있습니다.";

        tutorialMoveMessageHeader = "이동";
        tutorialMoveMessageText = tutMove + "을 사용하여 걸으세요" + space + tutLook + "을 사용하여 둘러보세요" + space + tutJump + "을 눌러 점프 하세요";

        tutorialClose = close + "종료";

        // YARD

        yardSnacks = "쿠키를 먹으려면" + buttonX + "를 누르세요.";
        yardWrench = "렌치를 들어 올리려면" + buttonX + "를 누르세요.";
        yardFuseUse = "전원을 켜려면" + buttonX + "를 누르세요.";
        yardFuseFix = "스위치가 고장난 것 같아, 렌치로 고칠 수 있을 것 같아.";
        yardFuseFixed = "좋아, 고쳐진거같아! 이제 엘레베이터가 작동할거야.";

        // CITY

        cityBoxBig = "큰 상자를 밀려면" + buttonX + "를 계속 누르고 있으세요.";
        cityPoster = "포스터 읽으려면" + buttonX + "를 누르세요.";
        cityDoorHandleMiss = "문에 손잡이가 없어...  어디 다른곳에서 그것을 찾을수 있을까";

        cityDoorHandleDig = "문 손잡이를 파내려면" + buttonX + "를 누르세요.";
        cityDoorHandle = "문 손잡이를 집어 올리려면" + buttonX + "를 누르세요.";

        // DOCKS

        docksToolBox = "도구 상자를 들어 올리려면" + buttonX + "를 누르세요.";
        docksBook = "장부를 읽으려면" + buttonX + "를 누르세요.";
        docksVent = "통풍구를 열려면" + buttonX + "를 누르세요.";
        docksVentStuck = "통풍구가 갇혀있어! 통풍구를 열 수 있는 도구가 있다면 그것을 열수있을거야.";

        docksPipe = "파이프들을 수리하려면" + buttonX + "를 누르세요.";
        docksPipeRotate = "파이프 돌리기" + pipeRotate;
        docksPipeMove = "포지션 선택" + pipeMove;
        docksPipeSelect = "파이프 선택" + pipeSelect;
    }

}
