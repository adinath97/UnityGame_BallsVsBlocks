using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClampName : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTemplate;
    [SerializeField] Canvas playerCanvas;
    
    private TextMeshProUGUI scoreInstance;

    public static float playerScore;

    public static bool showPlayerName;

    void Awake()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        playerScore = 15f;
        scoreInstance = Instantiate(scoreTemplate);
        scoreInstance.color = new Color(1f, 1f, 1f, 0f);
        scoreInstance.text = playerScore.ToString();
        //scoreTemplate.enabled = false;
        scoreInstance.transform.parent = playerCanvas.transform;
        scoreInstance.GetComponent<RectTransform>().sizeDelta = scoreTemplate.GetComponent<RectTransform>().sizeDelta;
        scoreInstance.GetComponent<RectTransform>().localScale = scoreTemplate.GetComponent<RectTransform>().localScale;
        scoreInstance.GetComponent<RectTransform>().position = scoreTemplate.GetComponent<RectTransform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if(showPlayerName) {
            this.GetComponent<SpriteRenderer>().enabled = true;
            showPlayerName = false;
            scoreInstance.color = new Color(1f, 1f, 1f, 1f);
        }
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        scoreInstance.transform.position = namePos;
        scoreInstance.text = playerScore.ToString();
    }

    public void DestroyThis() {
        GameObject des = GameObject.Find("PlayerScoreText");
        if(des != null) {
            Destroy(des);
        }
    }
}
