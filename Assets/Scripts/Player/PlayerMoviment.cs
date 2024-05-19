using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    private Vector2 moveDirection;
    private Vector2 _lastDirection;

    [SerializeField] float _fowardSpeed = 10f;
    [SerializeField] float _rotationSpeed = 200f;

    [SerializeField] public float _dashInterval = 3f;

    private bool _dashCooldown = false;
    private float _dashTimeCooldown = 0f;

    private float _dashSpeed = 1f;
    Animator animator;
    [SerializeField] GameObject body;


    void Start()
    {
        animator = body.GetComponent<Animator>();
    }

    void Update()
    {
        StartMoviment();
        SetDashTimeCountdown();
    }

    void StartMoviment()
    {
        if (moveDirection.x > 0 || moveDirection.x < 0 || moveDirection.y > 0 || moveDirection.y < 0)
        {

            animator.SetBool("running", true);

            transform.Translate(moveDirection.y * _fowardSpeed * Time.deltaTime * _dashSpeed, 0, 0);
            if (moveDirection.y > 0 || moveDirection.y < 0)
            {
                transform.Rotate(0, moveDirection.x * Time.deltaTime * _rotationSpeed, 0);
            }

            _lastDirection = moveDirection;

        }
        else
        {
            animator.SetBool("running", false);

        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {

        moveDirection = context.ReadValue<Vector2>();


    }

    public void OnDash(InputAction.CallbackContext context)
    {

        if (context.started && !_dashCooldown)
        {
            _dashSpeed = 100f;
            _dashCooldown = true;
            SetDashTimeCooldown();
            Invoke("RemoveDashCooldown", _dashInterval); ;
        }

    }

    void SetDashTimeCooldown()
    {
        _dashTimeCooldown = _dashInterval;

    }

    void SetDashTimeCountdown()
    {
        if (_dashTimeCooldown < _dashInterval && _dashCooldown)
        {
            _dashTimeCooldown += Time.deltaTime;

        }
        else
        {
            _dashSpeed = 1f;
            _dashTimeCooldown = 0;
        }

    }

    public float GetDashTimeCooldown()
    {
        return _dashTimeCooldown;
    }

    void RemoveDashCooldown()
    {
        _dashCooldown = false;
    }

}
