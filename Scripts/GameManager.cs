using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject finalScoreBox;
    [SerializeField] GameObject highScoreBox;
    [SerializeField] GameObject title;
    [SerializeField] GameObject anyKeyBox;
    [SerializeField] GameObject finalBackground;
    [SerializeField] GameObject finalFade;

    [SerializeField] GameObject startFadeOut;
    [SerializeField] GameObject endFadeIn;

    [SerializeField] GameObject startingTitle;
    [SerializeField] GameObject startingBackground;
    [SerializeField] GameObject startingAnyKeyBox;
    [SerializeField] GameObject startingDescription;
    [SerializeField] GameObject startingBackgroundBlack;

    public static bool gameOver,startGame,allow;

    private bool allowStartClick, allowEndClick;

    void Awake()
    {
        startFadeOut.SetActive(true);
        endFadeIn.SetActive(false);
        gameOver = false;
        startGame = false;
        allow = true;
        title.SetActive(false);
        anyKeyBox.SetActive(false);
        finalBackground.SetActive(false);
        finalScoreBox.SetActive(false);
        highScoreBox.SetActive(false);
        finalFade.SetActive(false);

        startingTitle.GetComponent<Animator>().enabled = false;
        startingBackground.GetComponent<Animator>().enabled = false;
        startingAnyKeyBox.GetComponent<Animator>().enabled = false;
        startingDescription.GetComponent<Animator>().enabled = false;
        startingBackgroundBlack.GetComponent<Animator>().enabled = false;

        startingTitle.SetActive(true);
        startingBackground.SetActive(true);
        startingAnyKeyBox.SetActive(true);
        startingDescription.SetActive(true);
        startingBackgroundBlack.SetActive(true);

        StartCoroutine(StartingROutine2());
    }

    private IEnumerator StartingROutine2()
    {
        yield return new WaitForSeconds(.51f);
        allowStartClick = true;
    }

    void Update()
    {
        if(Input.anyKey && !startGame && allowStartClick) {
            startGame = true;
            StartCoroutine(StartingRoutine());
            BoxInstantiator.startGame = true;
            ClampName.showPlayerName = true;
        }
        
        if(gameOver && Player.playerGameOver) {
            title.SetActive(true);
            anyKeyBox.SetActive(true);
            finalBackground.SetActive(true);
            finalScoreBox.GetComponent<TextMeshProUGUI>().text = "Score: " + ScoreManager.score.ToString();
            finalScoreBox.SetActive(true);
            highScoreBox.GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetFloat("HighScore",0f).ToString();
            highScoreBox.SetActive(true);
            finalFade.SetActive(true);
            StartCoroutine(EndingRoutine2());
        }

        if(gameOver && Player.playerGameOver && Input.anyKey && allowEndClick) {
            allowEndClick = false;
            StartCoroutine(EndingRoutine());
        }
    }

    private IEnumerator EndingRoutine2()
    {
        yield return new WaitForSeconds(.51f);
        allowEndClick = true;
    }

    private IEnumerator EndingRoutine() {
        endFadeIn.SetActive(true);
        yield return new WaitForSeconds(.6f);
        SceneManager.LoadScene(0);
    }

    private IEnumerator StartingRoutine()
    {
        startingTitle.GetComponent<Animator>().enabled = true;
        startingBackground.GetComponent<Animator>().enabled = true;
        startingAnyKeyBox.GetComponent<Animator>().enabled = true;
        startingDescription.GetComponent<Animator>().enabled = true;
        startingBackgroundBlack.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(.6f);
        startingTitle.SetActive(false);
        startingBackground.SetActive(false);
        startingAnyKeyBox.SetActive(false);
        startingDescription.SetActive(false);
        startingBackgroundBlack.SetActive(false);
    }
}
