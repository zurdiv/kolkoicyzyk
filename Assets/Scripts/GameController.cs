using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Button button;
    public Image panel;
    public Text text;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour {

    public GameObject gameOverPanel, restartButton, startInfo;
    public Text gameOverText;
    public Text[] buttonList;
    public Player playerX, playerO;
    public PlayerColor activePlayerColor, inactivePlayerColor;

    private string playerSide;
    private int moveCount;
    private bool gameFinished; //Jeden case remisu. 1 3 9 7 4 2 6 8 5


    private void Awake()
    {
        moveCount = 0;
        SetGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        gameFinished = false;
    }
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }
    public void SetStartingSide (string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
        StartGame();
    }
    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }
    public string GetPlayerSide()
    {
        return playerSide;
    }
    void SetPlayerButtons (bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }
    public void EndTurn()
    {
        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            gameFinished = true;
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            gameFinished = true;
            GameOver(playerSide);
        }

        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            gameFinished = true;
            GameOver(playerSide);
        }

        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            gameFinished = true;
            GameOver(playerSide);    
        }

        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            gameFinished = true;
            GameOver(playerSide);
        }

        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            gameFinished = true;
            GameOver(playerSide);
        }

        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            gameFinished = true;
            GameOver(playerSide);
        }

        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            gameFinished = true;
            GameOver(playerSide);  
        }
        ChangeSide();
        if (moveCount >= 9)
        {
            GameOver("remis");
        }      
    }
    void ChangeSide()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
    }
    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }
    void SetPlayerColorsInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);

        //Nie rozumiem dlaczego to nie działa
        //if (winningPlayer == "remis" && gameFinished == false)
        //{
        //    SetGameOverText("Remis!");
        //}

        if (winningPlayer == "remis") 
        {
            if (gameFinished == false)
            {
                SetGameOverText("Remis!");
                SetPlayerColorsInactive();
            }
        }
        else
        {
            SetGameOverText(winningPlayer + " Wygrywa!");
        }
        restartButton.SetActive(true);
    }
    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }
    public void RestartGame()
    {
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        gameFinished = false;
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
        startInfo.SetActive(true);
    }
    void SetBoardInteractable (bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}

