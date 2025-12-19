using UnityEngine;

public interface IMouseLook
{
    void Look(float mouseX, float mouseY);


    void SetSensitivity(float sensitivity);
    float GetSensitivity();
}

