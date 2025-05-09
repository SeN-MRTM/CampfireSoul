using UnityEngine;

public class CharacterCollisionHandler : MonoBehaviour
{
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        var hitObject = hit.gameObject;
        if (hitObject.name.IndexOf("enemy") != -1)
        {
            Destroy(hitObject);
        }

    }
}
