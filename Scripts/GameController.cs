using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject menu, panel;

    public UnityEngine.UI.Button startButton,reloadButton;
    public UnityEngine.UI.Text scoreLabel;
    public int score = 0;
    public bool isGameStarted = false;
    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startButton.onClick.AddListener(delegate
        {
            menu.SetActive(false);
            isGameStarted = true;
            Time.timeScale = 1;
        });
        reloadButton.onClick.AddListener(delegate
        {
            panel.SetActive(false);
            SceneManager.LoadScene("Scene");
            score = 0;
        });
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score:" + score;
        if (!isGameStarted)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
