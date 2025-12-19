using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public PlayerRoot playerRoot;       
    public GameObject pausePanel;       
    public Slider sensitivitySlider;    


    private bool _isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        sensitivitySlider.value = playerRoot.MouseSensitivity;
        sensitivitySlider.onValueChanged.AddListener(OnSliderChanged);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void OnSliderChanged(float value)
    {
        playerRoot.MouseSensitivity = value;
    }
}