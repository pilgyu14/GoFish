using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] string parameterName = "";

    public void OnValueChanged()
    {
        Debug.Log(volumeSlider.value);
        audioMixer.SetFloat(parameterName,
        (volumeSlider.value <= volumeSlider.minValue) ? -80f : volumeSlider.value);
    }

}