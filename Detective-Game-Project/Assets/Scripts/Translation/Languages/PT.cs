using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT : Language
{
    void Start()
    {
        menuMainPlay = "Jogar";
        menuMainNewGame = "Novo Jogo";
        menuMainOptions = "Opções";
        menuMainCredits = "Créditos";
        menuMainExit = "Sair";

        menuPlay1 = "O Jardim do Avô";
        menuPlay2 = "O Escritório do Avô";
        menuPlay3 = "O Armazém";

        menuOptionsGraphics = "Gráficos";
        menuOptionsSound = "Som";
        menuOptionsControls = "Controlos";
        menuOptionsLanguage = "Idioma";

        menuGraphicsFullscreen = "Ecrã Inteiro";

        menuSoundVolume = "Volume";
        menuSoundMusic = "Música";

        menuControlsController = "Controlador";
        menuControlsKeyboard = "Teclado";

        menuConfirmNewGame = "Irás perder todo o teu progresso em todos os níveis, tens mesmo a certeza?";
        menuConfirmExit = "Tens mesmo a certeza de que queres sair?";
        menuConfirmInGame = "O teu progresso no nível será perdido, queres mesmo sair?";

        menuCommonBack = "Voltar";
        menuCommonYes = "Sim";
        menuCommonNo = "Não";

        menuResume = "Continuar";
        menuRestart = "Reiniciar";
        menuMainMenu = "Menu Principal";

        // COMMON

        commonDoorLocked = "A porta está trancada! Eu preciso de uma chave para abrir isto...";
        commonDoorOpen = "Pressiona o botão" + buttonX + "para abrir a porta.";
        commonElevator = "Pressiona o botão" + buttonX + "para ligar o elevador.";
        commonRope = "Mantém premido o botão" + buttonX + "para baixar a corda.";
        commonBox = "Mantém premido o botão" + buttonX + "para empurrar a caixa.";

        commonKeyPickup = "Pressiona o botão" + buttonX + "para pegar na chave.";
        commonKeyPart = "Pressiona o botão" + buttonX + "para pegar numa parte de uma chave.";
        commonKeyDig = "Pressiona o botão" + buttonX + "para escavar uma parte de uma chave.";
        commonKeyHuman = "Pegaste numa parte de uma chave e colocaste-a no bolso.";
        commonKeyCombine = "Juntaste todas as partes numa só chave!";

        // TUTORIAL

        tutorialCommon = "Pressiona o botão" + buttonX + "para ler o tutorial.";

        tutorialPushHeader = "EMPURRARO OBJETOS";
        tutorialPushMessageText = "Pressiona o botão" + buttonX + "para empurrar um objeto com a Kika." + space + "Para objetos mais pesados, também vais precisar da ajuda do Daigo!";

        tutorialNatureHeader = "O CHAMAMENTO DA NATUREZA";
        tutorialNatureMessageText = "Às vezes, um cão tem de fazer as necessidades com o botão" + dogPee + space + "E sim... O botão" + dogPee + "faz o resto do trabalho...";

        tutorialSnacksHeader = "BISCOITOS DE CÃO";
        tutorialSnacksMessageText = "Pressiona o botão" + buttonX + "perto de um doseador para receber um biscoito de cão." + space + "Estes biscoitos fazem o Daigo correr mais rápido!";

        tutorialUmbrellaHeader = "GUARDA-CHUVA";
        tutorialUmbrellaMessageText = "A Kika pode abrir o seu guarda-chuva com o botão" + tutUmbrella + space + "O Daigo pode alcançar novas alturas ao saltar do guarda-chuva!";

        tutorialMoveMessageHeader = "MOVIMENTAÇÃO";
        tutorialMoveMessageText = "Utiliza o botão" + tutMove + "para andar." + space + "Utiliza o botão" + tutLook + "para olhar ao teu redor." + space + "Pressiona o botão" + tutJump + "para saltar.";

        tutorialClose = close + "Fechar";

        // YARD

        yardSnacks = "Pressiona o botão" + buttonX + "para comer uma biscoito de cão.";
        yardWrench = "Pressiona o botão" + buttonX + "para pegar na chave inglesa.";
        yardFuseUse = "Pressiona o botão" + buttonX + "para ligar a eletricidade.";
        yardFuseFix = "O interruptor parece estar estragado… Talvez o consiga compor com uma chave inglesa.";
        yardFuseFixed = "Ótimo! Acho que já está resolvido! Pode ser que o elevador já funcione.";

        // CITY

        cityBoxBig = "Mantém premido o botão" + buttonX + "para empurrar a caixa grande.";
        cityPoster = "Pressiona o botão" + buttonX + "para ver o poster.";
        cityDoorHandleMiss = "A porta não tem uma maçaneta... Será que a consigo encontrar algures?";

        cityDoorHandleDig = "Pressiona o botão" + buttonX + "para escavar o puxador.";
        cityDoorHandle = "Pressiona o botão" + buttonX + "para pegar no puxador.";

        // DOCKS

        docksToolBox = "Pressiona o botão" + buttonX + "para pegar na caixa de ferramentas.";
        docksBook = "Pressiona o botão" + buttonX + "para ler o livro.";
        docksVent = "Pressiona o botão" + buttonX + "para abrir o respiro.";
        docksVentStuck = "O respiro está encravado! Se eu tivesse alguma ferramenta, talvez conseguisse abri-lo.";

        docksPipe = "Pressiona o botão" + buttonX + "para reparar os canos.";
        docksPipeRotate = "Rodar o cano" + pipeRotate;
        docksPipeMove = "Escolher a posição" + pipeMove;
        docksPipeSelect = "Escolher o cano" + pipeSelect;
    }
}
