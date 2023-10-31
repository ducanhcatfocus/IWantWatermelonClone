using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static GameManager Instance => instance;

    int score = 0;
    int melonScore = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Only 1 instance of this");
            return;
        }
        instance = this;
    }


    public void UpdateScore(int newScore)
    {
        score += newScore;
        UIManager.Instance.UpdateScore(score);

    }
    public void UpdateWaterMelonScore()
    {
        melonScore++;
        UIManager.Instance.UpdateWatermelonScore(melonScore);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

}
