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

    public delegate PlayerData TurnDelegate();
    public delegate void TurnDelegate();

    public static event TurnDelegate OnTurnChange;

    void Start()
    {

    }

    protected override delegate TurnDelegate();

    void Update()
    {

    }

    [Button]
    public void ChangeTurn()
    {
        switch (currentPlayer)
        {
            case Player.Player_1:
                currentPlayer = Player.Player_2;
                OnTurnChange?.Invoke(player2);
                Debug.Log("Player 2's Turn");
                break;

            case Player.Player_2:
                currentPlayer = Player.Player_3;
                OnTurnChange?.Invoke(player3);
                Debug.Log("Player 3's Turn");
                break;

            case Player.Player_3:
                currentPlayer = Player.Player_4;
                OnTurnChange?.Invoke(player4);
                Debug.Log("Player 4's Turn");
                break;

            case Player.Player_4:
                currentPlayer = Player.Player_1;
                OnTurnChange?.Invoke(player1);
                Debug.Log("Player 1's Turn");
                break;
        }
    }
}