using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    bool muted;
    AudioSource music;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        music = GetComponent<AudioSource>();
    }

  public void ToggleMuted()
    {
        muted = !muted;
        music.mute = muted;
    }
    public bool GetMuted()
    {
        return muted;
    }
}
