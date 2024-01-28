using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using VInspector;

public class TurnHandler : MonoBehaviour
{
    // Author: Frank Manford
    // Description: A class for handling the players turns

    [SerializeField] PlayerData player1, player2, player3, player4;

    enum Player
    {
        Player_1, Player_2, Player_3, Player_4
    }

    Player currentPlayer = Player.Player_1;

    public delegate void TurnDelegate();
    public delegate void PlayerDataTurnDelegate(PlayerData currentPlayerData);


    public static event TurnDelegate OnTurnChange;
    public static event PlayerDataTurnDelegate OnTurnChangePlayerData;

    void Start()
    {

    }

    //protected override delegate TurnDelegate();

    void Update()
    {

    }

    public PlayerData GetPlayer()
    {
        switch (currentPlayer)
        {
            case Player.Player_1:
                return player1;

            case Player.Player_2:
                return player2;

            case Player.Player_3:
                return player3;

            case Player.Player_4:
                return player4;

            default:
                return null;
        }
    }

    [Button]
    public void ChangeTurn()
    {
        switch (currentPlayer)
        {
            case Player.Player_1:
                currentPlayer = Player.Player_2;
                OnTurnChangePlayerData?.Invoke(player2);
                Debug.Log("Player 2's Turn");
                break;

            case Player.Player_2:
                currentPlayer = Player.Player_3;
                OnTurnChangePlayerData?.Invoke(player3);
                Debug.Log("Player 3's Turn");
                break;

            case Player.Player_3:
                currentPlayer = Player.Player_4;
                OnTurnChangePlayerData?.Invoke(player4);
                Debug.Log("Player 4's Turn");
                break;

            case Player.Player_4:
                currentPlayer = Player.Player_1;
                OnTurnChangePlayerData?.Invoke(player1);
                Debug.Log("Player 1's Turn");
                break;
        }

        OnTurnChange?.Invoke();
    }
}