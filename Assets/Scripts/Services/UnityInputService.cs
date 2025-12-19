using UnityEngine;
using UnityEngine.InputSystem;

public class UnityInputService : IInputService
{

    public float Horizontal() => Input.GetAxisRaw("Horizontal");
    public float Vertical() => Input.GetAxisRaw("Vertical");
    public bool ShootPressed() => Input.GetMouseButtonDown(0);
    public float HorizontalMouse() => Mouse.current.delta.x.ReadValue();
    public float VerticalMouse() => Mouse.current.delta.y.ReadValue();
    

}
