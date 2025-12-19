using UnityEngine;

public interface IPlayerFactory
{
    IMovement CreateMovement(Rigidbody rb);

    IWeapon CreateWeapon(Rigidbody rb, Transform camera, PlayerMovement movement);
}