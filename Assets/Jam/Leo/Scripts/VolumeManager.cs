using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public void ChangeVolume()
    {
        AudioListener.volume = musicSlider.value;
        AudioListener.volume = sfxSlider.value;
    }
}
