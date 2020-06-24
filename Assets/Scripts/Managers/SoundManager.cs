using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    
    public static SoundManager GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<SoundManager>();
        }
        return instance;
    }

    public AudioSource actSound;
    public AudioSource fireSound;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
