using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{

    //Handles the player panel ui
    //Handles the gametime
    public GameObject player1Panel, player2Panel, player3Panel, player4Panel;
    public Color normalColor, player1Color, player2Color, player3Color, player4Color;
    public Text timeText;

    void Start()
    {
        player2Panel.SetActive(false);
        player3Panel.SetActive(false);
        player4Panel.SetActive(false);

        AddPlayer(0);
        if (GameController.controller.cars.Count > 1) { AddPlayer(1); }
        if (GameController.controller.cars.Count > 2) { AddPlayer(2); }
        if (GameController.controller.cars.Count > 3) { AddPlayer(3); }

        player1Panel.GetComponent<Image>().color = new Color(player1Color.r, player1Color.g, player1Color.b, 100f / 255f);
        player2Panel.GetComponent<Image>().color = new Color(player2Color.r, player2Color.g, player2Color.b, 100f / 255f);
        player3Panel.GetComponent<Image>().color = new Color(player3Color.r, player3Color.g, player3Color.b, 100f / 255f);
        player4Panel.GetComponent<Image>().color = new Color(player4Color.r, player4Color.g, player4Color.b, 100f / 255f);
    }

    void Update()
    {
        timeText.text = " " +GameController.controller.GetGameLength(true);
    }
    public void AddPlayer(int number)
    {
        GameObject panel = player1Panel;

        switch (number)
        {
            case 0:
                panel = player1Panel;
                break;
            case 1: //add player 2
                panel = player2Panel;
                break;
            case 2:
                panel = player3Panel;
                break;
            case 3:
                panel = player4Panel;
                break;
        }
        GameController.controller.cars[number].upButton = panel.GetComponentsInChildren<Image>()[1];
        GameController.controller.cars[number].downButton = panel.GetComponentsInChildren<Image>()[2];
        GameController.controller.cars[number].leftButton = panel.GetComponentsInChildren<Image>()[3];
        GameController.controller.cars[number].rightButton = panel.GetComponentsInChildren<Image>()[4];
        panel.SetActive(true);
    }
    public int GetPlayerNumber(Car c)
    {
        return c.GetComponent<Player>().playerNumber;
    }

    public Color GetPlayerColor(Car c)
    {
        if (c == null) return normalColor;
        switch (GetPlayerNumber(c))
        {
            case 0: return player1Color;
            case 1: return player2Color;
            case 2: return player3Color;
            case 3: return player4Color;
        }
        return normalColor;
    }
    public void UpdatePanel(int playerNumber)
    {
        switch (playerNumber)
        {
            case 0: UpdatePanel(player1Panel, GameController.controller.players[0].playerName, GameController.controller.players[0].numberOfCrystals, GameController.controller.players[0].numberOfMushrooms, GameController.controller.players[0].score); break;
            case 1: UpdatePanel(player2Panel, GameController.controller.players[1].playerName, GameController.controller.players[1].numberOfCrystals, GameController.controller.players[1].numberOfMushrooms, GameController.controller.players[1].score); break;
            case 2: UpdatePanel(player3Panel, GameController.controller.players[2].playerName, GameController.controller.players[2].numberOfCrystals, GameController.controller.players[2].numberOfMushrooms, GameController.controller.players[2].score); break;
            case 3: UpdatePanel(player4Panel, GameController.controller.players[3].playerName, GameController.controller.players[3].numberOfCrystals, GameController.controller.players[3].numberOfMushrooms, GameController.controller.players[3].score); break;
        }
    }

    void UpdatePanel(GameObject panel, string name, int crystals, int mushrooms, int score)
    {
        Text[] texts = panel.GetComponentsInChildren<Text>();
        texts[0].text = name;
        texts[1].text = crystals + "";
        texts[2].text = mushrooms + "";
        texts[3].text = score + "";
    }
}
