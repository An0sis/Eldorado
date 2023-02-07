using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    [SerializeField] private Slider VolumeSlider;

    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
    }
}
