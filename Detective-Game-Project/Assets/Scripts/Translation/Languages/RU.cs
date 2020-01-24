using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RU : Language
{
    void Start()
    {
        menuMainPlay = "Играть";
        menuMainNewGame = "Новая игра";
        menuMainOptions = "Опции";
        menuMainCredits = "Кредиты";
        menuMainExit = "Выход";

        menuPlay1 = "Дедушкин сад";
        menuPlay2 = "Дедушкин офис";
        menuPlay3 = "Склад";

        menuOptionsGraphics = "Графика";
        menuOptionsSound = "Звук";
        menuOptionsControls = "Управление";
        menuOptionsLanguage = "Язык";

        menuGraphicsFullscreen = "Полный экран";

        menuSoundVolume = "Громкость";
        menuSoundMusic = "Звук";

        menuControlsController = "Контроллер";
        menuControlsKeyboard = "Клавиатура";

        menuConfirmNewGame = "Вы потеряете все открывшиеся уровни. Вы уверены?";
        menuConfirmExit = "Вы уверены, что хотите выйти?";
        menuConfirmInGame = "Прогресс Вашего уровня будет утерян. Вы уверены?";

        menuCommonBack = "Назад";
        menuCommonYes = "Да";
        menuCommonNo = "Нет";

        menuResume = "Продолжить";
        menuRestart = "Перезапустить";
        menuMainMenu = "Главное меню";

        // COMMON

        commonDoorLocked = "Дверь заперта! Мне нужен ключ чтобы ее открыть.";
        commonDoorOpen = "Нажмите" + buttonX + "чтобы открыть дверь.";
        commonElevator = "Нажмите" + buttonX + "чтобы активировать лифт.";
        commonRope = "Удерживайте" + buttonX + "чтобы тянуть верёвку вниз.";
        commonBox = "Удерживайте" + buttonX + "чтобы толкать ящик.";

        commonKeyPickup = "Нажмите" + buttonX + "чтобы подобрать ключ.";
        commonKeyPart = "Нажмите" + buttonX + "чтобы подобрать часть ключа.";
        commonKeyDig = "Нажмите" + buttonX + "чтобы откопать часть ключа.";
        commonKeyHuman = "Вы подобрали часть ключа и положили его в карман.";
        commonKeyCombine = "Вы совместили все части ключа в целый ключ.";

        // TUTORIAL

        tutorialCommon = "Нажмите" + buttonX + "прочесть обучающее сообщение.";

        tutorialPushHeader = "Толкать объекты"; //ALL CAPS
        tutorialPushMessageText = "Нажмите" + buttonX + "чтобы толкать объект вместе с Кикой" + space + "Чтобы толкать объекты потяжелее Вам нужна помощь Дайго!";

        tutorialNatureHeader = "Зов природы"; //ALL CAPS
        tutorialNatureMessageText = "Иногда собаке нужно сходить по-маленькому с помощью"+ dogPee + space + "И да…" + dogPoo + "работает и для других нужд";

        tutorialSnacksHeader = "Лакомства для собак"; //ALL CAPS
        tutorialSnacksMessageText = "Удерживайте" + buttonX + "возле диспенсера чтобы получить лакомство для собак" + space + "Эти лакомства помогут Дайго бежать быстрее!";

        tutorialUmbrellaHeader = "Зонтик"; //ALL CAPS
        tutorialUmbrellaMessageText = "Кика может открыть ее зонтик с помощью" + tutUmbrella  + space + "Дайго может прыгать выше, отскакивая от зонтика!";

        tutorialMoveMessageHeader = "Движение"; //ALL CAPS
        tutorialMoveMessageText = "Используйте" + tutMove + "чтобы передвигаться" + space + "Используйте" + tutLook + "чтобы смотреть по сторонам" + space + "Используйте" + tutJump + "чтобы прыгать";

        tutorialClose = close + "Закрыть";

        // YARD

        yardSnacks = "Нажмите" + buttonX + "чтобы съесть печеньку.";
        yardWrench = "Нажмите" + buttonX + "чтобы подобрать гаечный ключ.";
        yardFuseUse = "Нажмите" + buttonX + "чтобы включить электричество.";
        yardFuseFix = "Переключатель, кажется, сломан, может я могу его починить с помощью гаечного ключа.";
        yardFuseFixed = "Здорово! Думаю, он исправлен! Может быть, лифт теперь работает.";

        // CITY

        cityBoxBig = "Удерживайте" + buttonX + "чтобы толкать большой ящик.";
        cityPoster = "Нажмите" + buttonX + "чтобы посмотреть на постер.";
        cityDoorHandleMiss = "У двери нет ручки… Может быть я могу найти ее в другом месте.";

        cityDoorHandleDig = "Нажмите" + buttonX + "откопать ручку от двери.";
        cityDoorHandle = "Нажмите" + buttonX + "подобрать ручку от двери.";

        // DOCKS

        docksToolBox = "Нажмите" + buttonX + "чтобы подобрать ящик с инструментами.";
        docksBook = "Нажмите" + buttonX + "чтобы прочесть книгу";
        docksVent = "Нажмите" + buttonX + "чтобы открыть вентиляционное отверстие.";
        docksVentStuck = "Вентиляционное отверстие заело! Может быть я могла бы его открыть с помощью подходящего инструмента.";

        docksPipe = "Нажмите" + buttonX + "чтобы починить трубопровод.";
        docksPipeRotate = "Поверните трубу" + pipeRotate;
        docksPipeMove = "Выберите позицию" + pipeMove;
        docksPipeSelect = "Выберите трубу" + pipeSelect;
    }

}
