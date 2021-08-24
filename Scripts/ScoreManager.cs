using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject scoreBox;
    private TextMeshProUGUI scoreText;

    public static float score;
   
    void Awake()
    {
        score = 0f;
        scoreText = scoreBox.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        if(score > PlayerPrefs.GetFloat("HighScore",0f)) {
            PlayerPrefs.SetFloat("HighScore",score);
        }
    }
}
