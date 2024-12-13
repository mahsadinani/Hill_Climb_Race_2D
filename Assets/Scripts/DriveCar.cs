using UnityEngine;

public class DriveCar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _FrontTireRB;
    [SerializeField] private Rigidbody2D _BackTireRB;
    [SerializeField] private Rigidbody2D _CarRB;

    [SerializeField] private float _Speed = 150f;
    [SerializeField] private float _RotationSpeed = 300f;

    private float _moveInput;
    private void Update() // update is called once per secound(frame)
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        _FrontTireRB.AddTorque(-_moveInput * _Speed * Time.fixedDeltaTime);
        _BackTireRB.AddTorque(-_moveInput * _Speed * Time.fixedDeltaTime);
        _CarRB.AddTorque(-_moveInput * _RotationSpeed * Time.fixedDeltaTime);

    }
}
