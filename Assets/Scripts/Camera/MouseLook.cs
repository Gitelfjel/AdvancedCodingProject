using UnityEngine;

public class MouseLook : IMouseLook
{
    private Transform _playerTransform;
    private Transform _cameraTransform;
    private float _xRotation;

    private float _sensitivity;

    public MouseLook(Transform player, Transform camera, float sensitivity = 2f)
    {
        _playerTransform = player;
        _cameraTransform = camera;
        _sensitivity = sensitivity;
    }

    public void Look(float mouseX, float mouseY)
    {
        _xRotation -= mouseY * _sensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _playerTransform.Rotate(Vector3.up * mouseX * _sensitivity);
    }

    public void SetSensitivity(float sensitivity)
    {
        _sensitivity = sensitivity;
    }

    public float GetSensitivity() => _sensitivity;
}