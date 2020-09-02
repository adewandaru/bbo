using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip WinAudio;
    public AudioClip DiceAudio;
    public AudioClip CorrectAudio;

    void Start()
    {

    }

    public void WinSound()
    {
        AudioSource.PlayClipAtPoint(WinAudio, transform.position);
    }

    public void DiceSound()
    {
        AudioSource.PlayClipAtPoint(DiceAudio, transform.position);
    }

    public void CorrectSound()
    {
        AudioSource.PlayClipAtPoint(CorrectAudio, transform.position);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
