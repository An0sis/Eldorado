
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public int cpt = 0;
    public int oui = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            nextsong();
        }

    }
    public void nextsong()
    {
        cpt = (cpt + 1) % playlist.Length;
        audioSource.clip = playlist[cpt];
        audioSource.Play();
        if (!audioSource.isPlaying)
        {
            playnextsong();
        }
    }

    void playnextsong()
    {
        oui = (oui + 1) % playlist.Length;
        audioSource.clip = playlist[oui];
        audioSource.Play();
    }
}
