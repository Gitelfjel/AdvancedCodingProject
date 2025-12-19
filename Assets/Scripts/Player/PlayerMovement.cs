using UnityEngine;

public class PlayerMovement : IMovement
{
    private Rigidbody _rb;
    private float _speed = 8f;

    // External velocity applied by weapon launches
    private Vector3 _externalVelocity;
    private float _externalVelocityTimer = 0f;
    private float _externalVelocityDuration = 0.1f; // short duration to preserve launch

    public PlayerMovement(Rigidbody rb)
    {
        _rb = rb;
    }

    public void FixedTick()
    {
        float h = ServiceLocator.Input.Horizontal();
        float v = ServiceLocator.Input.Vertical();

        Vector3 dir = (_rb.transform.right * h + _rb.transform.forward * v).normalized;
        Vector3 targetVelocity = dir * _speed;

        Vector3 velocity = _rb.linearVelocity;

        // Apply movement only if external velocity is not active
        if (_externalVelocityTimer <= 0f)
        {
            Vector3 change = targetVelocity - new Vector3(velocity.x, 0, velocity.z);
            _rb.AddForce(change, ForceMode.VelocityChange);
        }

        // Apply external velocity from weapon launches
        if (_externalVelocity.sqrMagnitude > 0.001f)
        {
            _rb.AddForce(_externalVelocity, ForceMode.VelocityChange);
            _externalVelocityTimer = _externalVelocityDuration; // start timer
            _externalVelocity = Vector3.zero;
        }

        // Countdown the external velocity timer
        if (_externalVelocityTimer > 0f)
            _externalVelocityTimer -= Time.fixedDeltaTime;
    }

    // Method for weapon to apply launch
    public void ApplyExternalVelocity(Vector3 v)
    {
        _externalVelocity += v;
    }
}