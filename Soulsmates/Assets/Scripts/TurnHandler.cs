using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    // Author: Frank Manford
    // Description: A class for handling the players turns

    [SerializeField] PlayerData player1, player2, player3, player4;

    [SerializeField] Timer timer;

    public delegate void TurnDelegate(PlayerData playerData);

    public static event TurnDelegate OnTurnChange;


    void Start()
    {
        
    }

    void Update()
    {

    }

    enum Player
    {
        Player_1, Player_2, Player_3, Player_4
    }


    public void ChangeTurn()
    {

    }
}