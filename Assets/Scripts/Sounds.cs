using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// I need to actually get the sounds a lot of this logic is from Brick buster
public class Sounds : MonoBehaviour
{
    public AudioClip GameStartSound;
    public AudioClip GameLoseSound;
    public AudioClip LoseCardSound;
    public static Sounds Instance;
    
    private AudioSource audioSource;
    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    public void PlayStart()
    {
        audioSource.PlayOneShot(GameStartSound);
    }
    
    public void PlayLose()
    {
        audioSource.PlayOneShot(GameLoseSound);
    }
    
    public void PlayLoseCard()
    {
        audioSource.PlayOneShot(LoseCardSound);
    }

   
}

