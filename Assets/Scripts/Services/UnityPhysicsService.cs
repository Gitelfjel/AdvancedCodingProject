using UnityEngine;

public class UnityPhysicsService : IPhysicsService
{
    public bool Raycast(Ray ray, out RaycastHit hit, float distance)
    {
        return Physics.Raycast(ray, out hit, distance);
    }
}
