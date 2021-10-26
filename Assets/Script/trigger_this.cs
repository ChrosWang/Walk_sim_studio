using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_this : MonoBehaviour
{
    public AudioSource mySoundSource;
    public float audioClipTime;

    public int timeEntered;

    public GameObject target;
    public Transform warpPoint;

    void OnTriggerEnter()
    {
        target.transform.position = warpPoint.transform.position; 
    }

   public void Teleport()
    {
        target.transform.position = warpPoint.transform.position; 
    }
    void OnTriggerExit ()
    {
        //print("I wish for death");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
