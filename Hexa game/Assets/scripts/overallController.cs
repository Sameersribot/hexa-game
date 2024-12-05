using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class overallController : MonoBehaviour
{
    public Image nextImg;
    public Sprite[] images;
    public GameObject canvasPause, openCanvas;
    public AudioSource btnClick;
    public int randomGen, nextGen;
    public int score;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        nextGen = Random.Range(0, 5);
        nextImg.sprite = images[nextGen];
    }
    private void Update()
    {
        scoreText.text = "Score - " + score.ToString();
}
    public int getRandomInt()
    {
        randomGen = nextGen;
        nextGen = Random.Range(0,5);
        nextImg.sprite = images[nextGen];
        return randomGen;
    }

    public void onclickPause()
    {
        btnClick.Play();
        openCanvas.SetActive(false);
        canvasPause.SetActive(true);
    }
    public void restart()
    {
        btnClick.Play();
        SceneManager.LoadScene(0);
    }
    public void pause()
    {
        btnClick.Play();
        openCanvas.SetActive(true);
        canvasPause.SetActive(false);
    }
    public void soundBtn()
    {

    }
}
