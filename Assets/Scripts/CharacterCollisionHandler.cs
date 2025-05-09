using System;
using UnityEngine;

public class CharacterCollisionHandler : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] Health _health;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        _health = GetComponent<Health>();
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        var hitObject = hit.gameObject;
        if (hitObject.name.IndexOf("enemy") != -1)
        {
            Destroy(hitObject);
            _health.ChangeHealth(-10);
        }
    }
}
