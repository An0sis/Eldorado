using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Linq;
public class Setsound : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetSound(float volume)
    {
        audioMixer.SetFloat("Sound", volume);
    }
}
