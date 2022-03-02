using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] soundtrack;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source.loop = false;
    }
    
    private AudioClip GetRandomTrack()
    {
        return soundtrack[Random.Range(0, soundtrack.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            source.clip = GetRandomTrack();
            source.Play();
        }
    }
}
