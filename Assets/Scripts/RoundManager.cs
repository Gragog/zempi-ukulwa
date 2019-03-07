using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    #region Singleton
    public static RoundManager Instance
    {
        get;
        private set;
    }
    #endregion

    public byte currentPlayerIndex;

    List<PlayerMove> players = new List<PlayerMove>();

    public RoundManager()
    {
        Instance = this;
    }

    public PlayerMove CurrentPlayer
    {
        get { return players[currentPlayerIndex]; }
        private set { }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerIndex = 0;

        CurrentPlayer.SetActiveTurn(true);
    }

    public void NextTurn()
    {
        CurrentPlayer.SetActiveTurn(false);

        currentPlayerIndex = (byte)((currentPlayerIndex + 1) % players.Count);

        CurrentPlayer.SetActiveTurn(true);
    }

    public void AddPlayer(PlayerMove player)
    {
        players.Add(player);
    }
}
