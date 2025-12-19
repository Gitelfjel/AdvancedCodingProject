using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    public PlayerRoot playerRoot; // assign in inspector
    public Slider slider;

    void Start()
    {
        slider.value = playerRoot.MouseSensitivity;
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float value)
    {
        playerRoot.MouseSensitivity = value;
    }
}