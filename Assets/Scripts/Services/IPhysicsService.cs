using UnityEngine;

public interface IPhysicsService
{
        bool Raycast(Ray ray, out RaycastHit hit, float distance);

}
