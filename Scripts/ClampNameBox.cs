using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClampNameBox : MonoBehaviour
{
    private GameObject scoreTemplate0;
    private GameObject playerCanvas0;

    public int counter;
    private Block thisBlockScript;

    private Canvas playerCanvas;
    private TextMeshProUGUI scoreTemplate;

    private TextMeshProUGUI scoreInstance;

    void Awake()
    {
        scoreTemplate0 = GameObject.Find("PlayerScoreText");
        playerCanvas0 = GameObject.Find("PlayerCanvas");

        scoreTemplate = scoreTemplate0.GetComponent<TextMeshProUGUI>();
        playerCanvas = playerCanvas0.GetComponent<Canvas>();

        scoreInstance = Instantiate(scoreTemplate);
        scoreInstance.transform.parent = playerCanvas.transform;
        scoreInstance.GetComponent<RectTransform>().sizeDelta = scoreTemplate.GetComponent<RectTransform>().sizeDelta;
        scoreInstance.GetComponent<RectTransform>().localScale = scoreTemplate.GetComponent<RectTransform>().localScale;
        scoreInstance.GetComponent<RectTransform>().position = scoreTemplate.GetComponent<RectTransform>().position;
        
        thisBlockScript = this.GetComponent<Block>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreInstance.name != counter.ToString()) {
            scoreInstance.name = counter.ToString();
        }
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        scoreInstance.transform.position = namePos;

        scoreInstance.text = thisBlockScript.damage.ToString();
    }

    public void SetCounter(int counterX) {
        this.counter = counterX;
    }

    public void DestroyThis() {
        GameObject des = GameObject.Find(counter.ToString());
        if(des != null) {
            Destroy(des);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<BoxCollider2D>().isTrigger = false;
        if(other.gameObject.tag == "SetColor") {
            scoreInstance.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
