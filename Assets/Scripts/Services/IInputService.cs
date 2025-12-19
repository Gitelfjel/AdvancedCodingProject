using UnityEngine;

public interface IInputService 
{

    float Horizontal();
    float Vertical();
    bool ShootPressed();

    float HorizontalMouse();
    float VerticalMouse();

}
