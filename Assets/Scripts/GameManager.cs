using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject restart;

    public bool inGame;

    public float worldScrollingSpeed = 0.2f;

    public Text scoreText;
    float score;

    public Text coinText;
    int coins;


    public Immortality immortality;
    public Magnet magnet;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        InitializeGame();
    }

    void InitializeGame()
    {
        inGame = true;
        if (PlayerPrefs.HasKey("coin"))
        {
            coins = PlayerPrefs.GetInt("coin");
        }
        else
        {
            coins = 0;
        }
        coinText.text = coins.ToString();

        immortality.isActive = false;
        magnet.isActive = false;
    }

    public void GameOver()
    {
        inGame = false;
        restart.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    void FixedUpdate()
    {
        if (GameManager.instance.inGame == false) { return; }

        score += worldScrollingSpeed;
        scoreText.text = score.ToString("0");
    }

    public void CoinCollected(int points = 1)
    {
        coins += points;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("coin", coins);
    }

    public void ImmortalityCollected()
    {
        if (immortality.isActive)
        {
            CancelImmortality();
            CancelInvoke("CancelImmortality");

        }

        immortality.isActive = true;
        Invoke("CancelImmortality", immortality.GetDuration());
    }

    void CancelImmortality()
    {
        immortality.isActive = false;
    }

    public void MagnetCollected()
    {
        if (magnet.isActive)
        {
            CancelMagnet();
            CancelInvoke("CancelMagnet");
        }

        magnet.isActive = true;
        Invoke("CancelMagnet", magnet.GetDuration());
    }
    void CancelMagnet()
    {
        magnet.isActive = false;
    }
}
