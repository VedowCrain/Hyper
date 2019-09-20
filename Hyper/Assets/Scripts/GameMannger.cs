using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu,Playing,GameOver
}

public class GameMannger : MonoBehaviour
{
    public static GameState gameState;

    // Use this for initialization
    void Start()
    {
        gameState = GameState.Menu;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
