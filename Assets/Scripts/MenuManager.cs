using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject storePanel;

    public Text magnetLevelText;
    public Text magnetButtonText;

    public Text immortalityLevelText;
    public Text immortalityButtonText;

    public Powerup magnet;
    public Powerup immortality;

    int coins;

    public Text sound;

    void UpdateUI()
    {
        immortalityLevelText.text = immortality.ToString();
        immortalityButtonText.text = immortality.UpgradeCostString();

        magnetLevelText.text = magnet.ToString();
        magnetButtonText.text = magnet.UpgradeCostString();

        if (SoundManager.instance.GetMuted())
        {
            sound.text = "Turn on sound";
        }
        else
        {
            sound.text = "Turn off sound";
        }

    }

    public void SoundButton()
    {
        SoundManager.instance.ToggleMuted();
        UpdateUI();
    }
    public void OpenStore()
    {
        storePanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void CloseStore()
    {
        storePanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void PlayButton() {
        SceneManager.LoadScene("Game");
    
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("coin"))
        {
            coins = PlayerPrefs.GetInt("coin");
        }
        else
        {
            coins = 0;
        }

        UpdateUI();
    }

   void UpgradePowerup(Powerup powerup)
    {
        if(coins >= powerup.GetNextUpgradeCost() &&
            powerup.IsMaxedOut() == false)
        {
            coins -= powerup.GetNextUpgradeCost();
            powerup.Upgrade();
            UpdateUI();
            PlayerPrefs.SetInt("coin", coins);
        }
    }

    public void UpgradeMagnet()
    {
        UpgradePowerup(magnet);
    }
    public void UpgradeImmortality()
    {
        UpgradePowerup(immortality);
    }
}
