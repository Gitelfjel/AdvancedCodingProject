using UnityEngine;

public class GroundLaunchWeapon : IWeapon
{
    private Rigidbody _rb;
    private Transform _camera;
    private PlayerMovement _playerMovement;

    private float _floorLaunchForce = 10f; // vertical and horizontal launch strength
    private float _cooldown = 1f;          // seconds between shots
    private float _lastShotTime = -Mathf.Infinity;

    private float _rayDistance = 100f;
    private float _rayRadius = 0.2f;       // spherecast radius for reliable hits

    public GroundLaunchWeapon(Rigidbody rb, Transform camera, PlayerMovement movement)
    {
        _rb = rb;
        _camera = camera;
        _playerMovement = movement;
    }

    public void Tick()
    {
        if (ServiceLocator.Input.ShootPressed() && Time.time >= _lastShotTime + _cooldown)
        {
            Ray ray = new Ray(_camera.position, _camera.forward);

            if (Physics.SphereCast(ray, _rayRadius, out RaycastHit hit, _rayDistance))
            {
                float angle = Vector3.Angle(hit.normal, Vector3.up);

                // Debug info
                Debug.Log($"Hit: {hit.collider.name}, Normal: {hit.normal}, Angle: {angle}");

                if (angle < 45f) // floor
                {
                    // Launch upward
                    _playerMovement.ApplyExternalVelocity(Vector3.up * _floorLaunchForce);
                }
                else // wall
                {
                    // Launch **away from wall**
                    Vector3 launchDir = (_rb.position - hit.point); // from wall hit point to player
                    launchDir.y = 0;                                // horizontal only
                    launchDir.Normalize();

                    _playerMovement.ApplyExternalVelocity(launchDir * _floorLaunchForce);
                }

                // Start cooldown
                _lastShotTime = Time.time;
            }
        }
    }
}