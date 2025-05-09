using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public string parameter;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float multiplier;

    public void LoadSlider(float _value)
    {
        if (_value >= 0.001f)
            slider.value = _value;
    }

    public void SliderValue(float _value)
    {
        audioMixer.SetFloat(parameter, MathF.Log10(_value) * multiplier);
    }


}
