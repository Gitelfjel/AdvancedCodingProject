using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    public IMovement CreateMovement(Rigidbody rb)
    {
        return new PlayerMovement(rb);
    }

    public IWeapon CreateWeapon(Rigidbody rb, Transform camera, PlayerMovement movement)
    {
        
        return new GroundLaunchWeapon(rb, camera, movement);
    }
}