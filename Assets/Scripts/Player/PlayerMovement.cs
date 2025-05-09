using System;
using UnityEngine;

namespace Player
{


    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed = 5;
        [SerializeField] private float _runSpeed = 8;
        [SerializeField] private float _jumpForce = 5;
        [SerializeField] private float _gravity = -9.81f;

        private CharacterController _characterController;
        private Camera _playerCamera;

        private Vector3 _velocity;
        private Vector2 _rotation;
        private Vector2 _direction;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _playerCamera = GetComponentInChildren<Camera>();
        }

        private void Update()
        {
            _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _characterController.Move(_velocity * Time.deltaTime);
            _direction *= Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;

            if (_characterController.isGrounded) _velocity.y = Input.GetKeyDown(KeyCode.Space) ? _jumpForce : -0.1f;
            else _velocity.y += _gravity * Time.deltaTime;

            Vector3 move = Quaternion.Euler(0, _playerCamera.transform.eulerAngles.y, 0) * new Vector3(_direction.x, 0, _direction.y);
            _velocity = new Vector3(move.x, _velocity.y, move.z);
        }
    }
}