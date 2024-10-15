using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isGameActive;
    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = FindAnyObjectByType<GameManager>();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable() 
    {
        EventManager.instance.OnScoreIncremented += IncrementScore;
    }

    private void OnDisable() 
    {
        EventManager.instance.OnScoreIncremented -= IncrementScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        score = 0;
        isGameActive = true;
        Debug.Log("Game Started");
    }

    public void EndGame()
    {
        isGameActive = false;
    }

    private void IncrementScore(int value)
    {
        score += value;
        UIManager.instance.UpdateScoreText();
    }

    public int getScore()
    {
        return score;
    }


}
