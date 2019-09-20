using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button playButton;
    public Button Exit;


    // Use this for initialization
    void Start()
    {
        playButton.onClick.AddListener(OnPlay);
        Exit.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            OnPlay();
        }
    }

    void OnPlay()
    {
        GameMannger.gameState = GameState.Playing;
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void ToggleMusic()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleMute();
        }
    }
}
