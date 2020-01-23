using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES : Language
{
    void Start()
    {
        menuMainPlay = "Jugar";
        menuMainNewGame = "Juego Nuevo";
        menuMainOptions = "Opciones";
        menuMainCredits = "Creditos";
        menuMainExit = "Terminar";

        menuPlay1 = "El jardín del abuelo";
        menuPlay2 = "La oficina del abuelo";
        menuPlay3 = "El almacén";

        menuOptionsGraphics = "Gráficos";
        menuOptionsSound = "Sonido";
        menuOptionsControls = "Controls";
        menuOptionsLanguage = "Idioma";

        menuGraphicsFullscreen = "Pantalla completa";

        menuSoundVolume = "Volumen";
        menuSoundMusic = "Musica";

        menuControlsController = "Controlador";
        menuControlsKeyboard = "Teclado";

        menuConfirmNewGame = "Vas a perder todos tu niveles desbloqueados, estas seguro?";
        menuConfirmExit = "Estas seguro que quieres terminar?";
        menuConfirmInGame = "El progreso de tu nivel se va a perder, estas seguro?";

        menuCommonBack = "De Vuelta";
        menuCommonYes = "Si";
        menuCommonNo = "No";

        menuResume = "Continuar";
        menuRestart = "Reanudar";
        menuMainMenu = "Menu";

        // COMMON

        commonDoorLocked = "La puerta esta cerrada! Necesito una llave para abrir eso.";
        commonDoorOpen = "Presionar" + buttonX + "abrir la puerta";
        commonElevator = "Presionar" + buttonX + "encender el elevador";
        commonRope = "Presionar" + buttonX + "jalar la cuerda hacia abajo.";
        commonBox = "Presionar" + buttonX + "empujar la caja.";

        commonKeyPickup = "Presionar" + buttonX + "recoger la llave";
        commonKeyPart = "Presionar" + buttonX + "recoger una parte de la llave.";
        commonKeyDig = "Presionar" + buttonX + "desenterrar una parte de la llave";
        commonKeyHuman = "Has recogido una parte de una llave y lo has metido en tu bolsillo";
        commonKeyCombine = "Has combinado todas las partes de una llave en una llave entera";

        // TUTORIAL

        tutorialCommon = "Presionar" + buttonX + "leer el mensaje tutorial";

        tutorialPushHeader = "EMPUJAR LOS OBJETOS"; //ALL CAPS
        tutorialPushMessageText = "Presionar" + buttonX + "empujar un objeto con Kika" + space + "Para objetos mas pesados Daigo necesita empujar también!";

        tutorialNatureHeader = "LLAMADA DE LA NATURALEZA"; //ALL CAPS
        tutorialNatureMessageText = "De vez en cuando un perro debe de tomar una fuga con" + dogPee + space + "Y si..." + dogPoo + "hacer el resto!";

        tutorialSnacksHeader = "GALLETAS DE PERRO"; //ALL CAPS
        tutorialSnacksMessageText = "Presionar" + buttonX + "cerca un dispensador para una galleta de perro" + space + "Estas galletas de perro hacen Daigo ir mas rápido";

        tutorialUmbrellaHeader = "PARAGUAS"; //ALL CAPS
        tutorialUmbrellaMessageText = "Kika puede abrir sus paraguas con" + tutUmbrella  + space + "Daigo puede llegar a nuevas alturas rebotando las paraguas!";

        tutorialMoveMessageHeader = "MOVIMIENTO"; //ALL CAPS
        tutorialMoveMessageText = "Utiliza" + tutMove + "para caminar" + space + "Utiliza" + tutLook + "mirar a tu alrededor" + space + "Presionar" + tutJump + "saltar";

        tutorialClose = close + "Cerrar";

        // YARD

        yardSnacks = "Presionar" + buttonX + "comer una galleta de perro";
        yardWrench = "Presionar" + buttonX + "recoger la llave inglesa";
        yardFuseUse = "Presionar" + buttonX + "encender la electricidad.";
        yardFuseFix = "El interruptor parece roto, tal vez pueda arreglarlo con una llave inglesa";
        yardFuseFixed = "Excelente, ¡Creo que está arreglado! Tal vez el elevador funcione ahora.";

        // CITY

        cityBoxBig = "Presionar" + buttonX + "empujar la caja grande";
        cityPoster = "Presionar" + buttonX + "para mirar el poster";
        cityDoorHandleMiss = "La puerta no tiene manija de puerta... Me pregunto si puedo encontrar en otro sitio.";

        cityDoorHandleDig = "Presionar" + buttonX + "desenterrar la manija de puerta";
        cityDoorHandle = "Presionar" + buttonX + "recoger la manija de puerta";

        // DOCKS

        docksToolBox = "Presionar" + buttonX + "recoger la caga de herramienta.";
        docksBook = "Presionar" + buttonX + "leer el libro mayor";
        docksVent = "Presionar" + buttonX + "abrir el respiradero.";
        docksVentStuck = "El respiradero esta atorado! A lo mejor si tendría una herramienta lo podría abrir.";

        docksPipe = "Presionar" + buttonX + "reparar las tuberias.";
        docksPipeRotate = "Gira el tubo" + pipeRotate;
        docksPipeMove = "Seleccione posición" + pipeMove;
        docksPipeSelect = "Seleccione un tubo" + pipeSelect;
    }

}
