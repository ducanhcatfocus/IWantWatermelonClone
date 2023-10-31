using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    static UIManager instance;

    public static UIManager Instance => instance;

   
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI waterMelonScoreText;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Only 1 instance of this");
            return;
        }
        instance = this;
    }


    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateWatermelonScore(int score)
    {
        waterMelonScoreText.text = score.ToString();
    }
}
