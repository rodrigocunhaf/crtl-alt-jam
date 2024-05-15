using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    private Vector2 moveDirection;
    private Vector2 _lastDirection;

    [SerializeField] float _fowardSpeed = 10f;
    [SerializeField] float _rotationSpeed = 200f;

    [SerializeField] float _dashInterval = 3f;

    private bool _dashCooldown = false;
    private float _dashTimeCooldown = 0f;


    void Update()
    {
        StartMoviment();
        SetDashTimeCountdown();
    }

    void StartMoviment()
    {
        if (moveDirection.x > 0 || moveDirection.x < 0 || moveDirection.y > 0 || moveDirection.y < 0)
        {

            transform.Translate(moveDirection.y * _fowardSpeed * Time.deltaTime, 0, 0);
            if (moveDirection.y > 0 || moveDirection.y < 0)
            {
                transform.Rotate(0, moveDirection.x * Time.deltaTime * _rotationSpeed, 0);
            }
            _lastDirection = moveDirection;

        }
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    void OnDash(InputAction.CallbackContext context)
    {
        if (context.started && !_dashCooldown)
        {

            transform.Translate(_lastDirection.x + 5f, 0, 0);

            _dashCooldown = true;
            SetDashTimeCooldown();
            Invoke("RemoveDashCooldown", _dashInterval);
        }

    }

    void SetDashTimeCooldown()
    {
        _dashTimeCooldown = _dashInterval;
    }

    void SetDashTimeCountdown()
    {
        if (_dashTimeCooldown > 0)
        {

            _dashTimeCooldown -= Time.deltaTime;
        }
    }

    public float GetDashTimeCooldown()
    {
        return _dashTimeCooldown;
    }

    void RemoveDashCooldown()
    {
        _dashCooldown = false;
        print("Dash Unlocked");
    }

}
