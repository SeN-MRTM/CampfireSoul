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
        Renderer renderer = hitObject.GetComponent<Renderer>();
        if (hitObject.tag == "Entity")
        {
            Destroy(hitObject);
            _health.ChangeHealth(-10);
        }
    }
}
