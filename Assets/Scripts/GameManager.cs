using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject knife;
    public Image[] knifeIcons;
    public int noOfKnives;

    public int scoreCount;
    public Text score;

    public ParticleSystem knifeEffect;
    public AudioSource knifeSound;

    public string levelToLoad;

    public Canvas gameWon;
    public Canvas gameLost;

    private void Start()
    {
       // noOfKnives = 4;
        scoreCount = 0;
        gameLost.enabled = false;
        gameWon.enabled = false;
    }

    private void Update()
    {
        /*if(noOfKnives==0)
        {
            //GameWon Canvas
            Debug.Log("GameWon");
        }*/
        score.text = "" + scoreCount;
    }

    public void newKnife()
    {
        if (noOfKnives != -1)
        {
            knifeEffect.Play();
            knifeSound.Play();
           // Debug.Log("newKnifeCalled");
            scoreCount++;
            if (noOfKnives != 0)
                Instantiate(knife, new Vector3(0f, -2.8f,-5.1f), Quaternion.identity);
          //  Debug.Log("KnifeCalled");
            knifeIcons[noOfKnives].color = new Color32(89, 89, 89, 255);
            noOfKnives--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="knife")
        {
            //GameOver Canvas
            Debug.Log("GameLost");
        }
    }

    public void GameWon(int hitCount)
    {
        Debug.Log(hitCount);
        if(hitCount==(noOfKnives+1))
        {
            gameWon.enabled = true;
            Debug.Log("GameWon");
        }
    }
    public void GameLost()
    {
        gameLost.enabled = true;
        Debug.Log("GameLost");
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Continue()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
