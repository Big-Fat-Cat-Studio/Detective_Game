using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JP : Language
{
    void Start()
    {
        menuMainPlay = "遊ぶ";
        menuMainNewGame = "新しいゲーム";
        menuMainOptions = "操作";
        menuMainCredits = "エンドロール";
        menuMainExit = "出口";

        menuPlay1 = "お爺さんの庭";
        menuPlay2 = "お爺さんの職場";
        menuPlay3 = "倉庫";

        menuOptionsGraphics = "グラフィックス";
        menuOptionsSound = "サウンド";
        menuOptionsControls = "操作";
        menuOptionsLanguage = "言語";

        menuGraphicsFullscreen = "全画面";

        menuSoundVolume = "ボリューム";
        menuSoundMusic = "音楽";

        menuControlsController = "コントローラー";
        menuControlsKeyboard = "キーボード";

        menuConfirmNewGame = "あなたのロックされていないレベルは全て失われます。本当にやめますか？";
        menuConfirmExit = "本当にやめる？";
        menuConfirmInGame = "あなたの進捗は失われます。本当にやめますか？";

        menuCommonBack = "戻る";
        menuCommonYes = "はい";
        menuCommonNo = "いいえ";

        menuResume = "再開する";
        menuRestart = "戻る";
        menuMainMenu = "メニュー";

        // COMMON

        commonDoorLocked = "ドアには鍵がかかっている！開けるために鍵が必要だ。";
        commonDoorOpen = buttonX + "を押してドアを開ける";
        commonElevator = buttonX + "を押してエレベーターを動かす";
        commonRope = buttonX + "を押してロープを引き下げる";
        commonBox = buttonX + "を押して大きな箱を押す";

        commonKeyPickup = buttonX + "を押して鍵を拾う";
        commonKeyPart = buttonX + "を押して鍵の一部を拾う";
        commonKeyDig = buttonX + "を押して鍵の一部を掘り起こす";
        commonKeyHuman = "あなたは鍵を１つ取って、それをポケットに入れる。";
        commonKeyCombine = "あなたはその全てのパートを組み合わせて1つの鍵を作った。";

        // TUTORIAL

        tutorialCommon = buttonX + "を押して学習用メッセージを読む";

        tutorialPushHeader = "物体を押す";
        tutorialPushMessageText = buttonX + "を押してキカと物体を押す。" + space + "重たい物はダイゴと一緒に押して！";

        tutorialNatureHeader = "本能";
        tutorialNatureMessageText = "たまに" + dogPee + "を押して犬に小便をさせる" + space + "そして、" + dogPoo + "であっちの方も...";

        tutorialSnacksHeader = "ドッグキャンディ";
        tutorialSnacksMessageText = "ドッグキャンディのガチャガチャの近くの" + buttonX + "を押す。" + space + "そのキャンディでダイゴは早く走れる！";

        tutorialUmbrellaHeader = "傘";
        tutorialUmbrellaMessageText = "キカは" + tutUmbrella + "で傘を開くことが出来る" + space + "イゴは傘から飛ぶことで新しい高さに到達出来る";

        tutorialMoveMessageHeader = "動作";
        tutorialMoveMessageText = tutMove + "で歩き回る" + space + tutLook + "で周りを見る" + space + tutJump + "を押してジャンプ";

        tutorialClose = close + "閉じる";

        // YARD

        yardSnacks = buttonX + "を押してドッグキャンディを食べる";
        yardWrench = buttonX + "を押してレンチを拾う";
        yardFuseUse = buttonX + "を押して電気をオンにします";
        yardFuseFix = "この電気のスイッチはロックされているようだ。これを動かすためにレンチが必要だ。";
        yardFuseFixed = "素晴らしい、私はそれが修正されたと思う！ たぶん、エレベーターは今動作します";

        // CITY

        cityBoxBig = buttonX + "を押して大きな箱を押す";
        cityPoster = buttonX + "を押してポスターを見る";
        cityDoorHandleMiss = "ドアにはドアノブがない...どこかで見つけられるのかな。";

        cityDoorHandleDig = buttonX + "を押してドアノブを掘り起こす";
        cityDoorHandle = buttonX + "を押してドアノブを拾う";

        // DOCKS

        docksToolBox = buttonX + "を押して工具箱を拾う";
        docksBook = buttonX + "を押して台帳を読む";
        docksVent = buttonX + "を押して通気口を開ける";
        docksVentStuck = "通気口が塞がっている！もし道具を持っていたら開けられるのに。";

        docksPipe = buttonX + "を押して配管を修理する";
        docksPipeRotate = "配管を回す" + pipeRotate;
        docksPipeMove = "位置を選ぶ" + pipeMove;
        docksPipeSelect = "配管を選ぶ" + pipeSelect;
    }

}
