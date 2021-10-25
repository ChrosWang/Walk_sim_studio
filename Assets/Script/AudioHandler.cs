using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioHandler : MonoBehaviour
{
    AudioSource playingAudio;
    public UnityEvent onFinished;
    float delay_time;
    // Start is called before the first frame update
    void Start()
    {
        playingAudio = GetComponent<AudioSource>();
        delay_time = 2.2f + playingAudio.clip.length;
        Debug.Log(delay_time);
        
    }

    public void startInteract() 
    {
        Invoke("audioFinished", delay_time);
    }

    void audioFinished() 
    {
        onFinished.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
