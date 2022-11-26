using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _anim;
    public CharacterStats characterStats;
    public float jumpForce = 5f;

    private Vector3 _playerVelocity = Vector3.zero;
    private bool _groundedPlayer = true;
    public new GameObject camera = null;

    private PlayerInput _playerInput;
    
    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _jumpAction;
    private InputAction _dashAction;
    private const float gravityValue = -9.81f;
    
    // Start is called before the first frame update
    void Start()
    {
        Enemy.Player = this;

        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();

        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _lookAction = _playerInput.actions["Look"];
        _jumpAction = _playerInput.actions["Jump"];
    }

    // Update is called once per frame
    void Update()
    {
        _groundedPlayer = _controller.isGrounded;

        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0;
        }
        
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.X, 0, moveInput.Y);
        _controller.Move(move * (Time.deltaTime * characterStats.Speed));
        if (_jumpAction.triggered && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravityValue);
        }

        _playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
}
