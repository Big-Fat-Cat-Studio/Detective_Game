using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK : Language
{
    void Start()
    {
        menuMainPlay = "Oyna";
        menuMainNewGame = "Yeni Oyun";
        menuMainOptions = "Seçenekler";
        menuMainCredits = "Kreditler";
        menuMainExit = "Cikis";

        menuPlay1 = "Dedenin bahçesi";
        menuPlay2 = "Dedenin ofisi";
        menuPlay3 = "Depo";

        menuOptionsGraphics = "Grafikler";
        menuOptionsSound = "Ses";
        menuOptionsControls = "Ayarlar";
        menuOptionsLanguage = "Dil";

        menuGraphicsFullscreen = "Tam ekran";

        menuSoundVolume = "Ses";
        menuSoundMusic = "Müzik";

        menuControlsController = "Kontrolor";
        menuControlsKeyboard = "Klavye";

        menuConfirmNewGame = "Bütün kilitlenmemiş seviyelerin kaybolacak, emin misin?";
        menuConfirmExit = "Cikmak istediğine emin misin?";
        menuConfirmInGame = "Seviye ilerlemen kaybolmuş olacak, emin misin?";

        menuCommonBack = "Geri";
        menuCommonYes = "Evet";
        menuCommonNo = "Hayir";

        menuResume = "Devam et";
        menuRestart = "Yeniden başlat";
        menuMainMenu = "Menü";

        // COMMON

        commonDoorLocked = "Kapı kilitlendi! Bunu acmak icin bir anahtara ihtiyacım var.";
        commonDoorOpen = "Pres" + buttonX + "kapıyı acmak icin";
        commonElevator = "Pres" + buttonX + "asansörü calistirmak icin";
        commonRope = "Pres" + buttonX + "ipi çekmek icin";
        commonBox = "Pres" + buttonX + "kutuyu itmek icin";

        commonKeyPickup = "Pres" + buttonX + "anahtarı almak icin";
        commonKeyPart = "Pres" + buttonX + "anahtarın bir parcasını almak icin";
        commonKeyDig = "Pres" + buttonX + "anahtarın bir parcasını aramak icin";
        commonKeyHuman = "Anahtarın bir kısmini alıp, cebine koydun";
        commonKeyCombine = "Anahtarın bütün parçalarını birleştirip, bir anahtar haline getirdin";

        // TUTORIAL

        tutorialCommon = "Pres" + buttonX + "öğretici mesajı okumak icin";

        tutorialPushHeader = "ITME OBJECTLERI"; //ALL CAPS
        tutorialPushMessageText = "Pres" + buttonX + "bir objeyi Kikayla itmek icin" + space + "Daha ağır objeler icin Daigonun yardımına ihtiyacın olacaktır!";

        tutorialNatureHeader = "DOĞANIN CARISI"; //ALL CAPS
        tutorialNatureMessageText = "Bazen bir köpeğin bir sizinki" + dogPee + space + "Ve evet…" + dogPoo + "gerisini yapıyor";

        tutorialSnacksHeader = "Kopek tehlikeleri"; //ALL CAPS
        tutorialSnacksMessageText = "Bir dagilicinin yakınında oldugunda" + buttonX + "tusuna bas, bir kopek tehlikesi yaklastiginda" + space + "Bu tehlikeler Daigoyu daha hızlı yapacaktır";

        tutorialUmbrellaHeader = "SEMSIYE"; //ALL CAPS
        tutorialUmbrellaMessageText = "Kika şemsiyesini" + tutUmbrella + "acabilir" + space + "Daigo şemsiyenin uzerine atlayarak yeni yüksekliklere ulaşabilir!";

        tutorialMoveMessageHeader = "HAREKETLER"; //ALL CAPS
        tutorialMoveMessageText = "Kullan" + tutMove + "yürümek icin" + space + "Kullan" + tutLook + "etrafa bakmak icin" + space + "Pres" + tutJump + "atlamak icin";

        tutorialClose = close + "Kapat";

        // YARD

        yardSnacks = "Pres" + buttonX + "bisküvi yemek icin";
        yardWrench = "Pres" + buttonX + "ingiliz anahtarını almak icin";
        yardFuseUse = "Pres" + buttonX + "Elektrigi acmak icin";
        yardFuseFix = "Düğme sanırsam bozulmuş, belki ingiliz anahtarıyla tamir edebilirim.";
        yardFuseFixed = "Harika, sanırım düzeldi! Belki asansör calisir simdi.";

        // CITY

        cityBoxBig = "Pres" + buttonX + "büyük kutuyu itmek icin";
        cityPoster = "Pres" + buttonX + "Postere bakmak icin";
        cityDoorHandleMiss = "Kapının kulpu yok…acaba başka bir yerde bulabilir miyim";

        cityDoorHandleDig = "Pres" + buttonX + "kapı kulunu kazmak icin";
        cityDoorHandle = "Pres" + buttonX + "kapı kulunu almak icin";

        // DOCKS

        docksToolBox = "Pres" + buttonX + "araç kutusunu almak icin";
        docksBook = "Pres" + buttonX + "ana defteri okumak icin";
        docksVent = "Pres" + buttonX + "havalandırmaya acmak icin";
        docksVentStuck = "Havalandırma sikismis. Aracım olsaydı açardım.";

        docksPipe = "Pres" + buttonX + "boruyu tamir etmek icin";
        docksPipeRotate = "Boruyu çevir" + pipeRotate;
        docksPipeMove = "Pozisyonu seç" + pipeMove;
        docksPipeSelect = "Boruyu seç" + pipeSelect;
    }
}