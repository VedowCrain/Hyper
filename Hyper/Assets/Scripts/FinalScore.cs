using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    public static FinalScore Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public InputField nameInput;
    public Button saveButton;
    public Text finalScore;

    private void Start()
    {
        saveButton.onClick.AddListener(OnSave);
        GetComponent<CanvasGroup>().alpha = 0;
        nameInput.enabled = false;
    }

    public void Show()
    {
        finalScore.text = ScoreManager.Instance.GetScore().ToString();
        GetComponent<CanvasGroup>().alpha = 1;
        nameInput.enabled = true;
        nameInput.text = "";
    }



    void OnSave()
    {
        ScoreManager.Instance.AddHighScore(nameInput.text);
        GetComponent<CanvasGroup>().alpha = 0;
        SceneManager.LoadScene(0);
        
    }

}
