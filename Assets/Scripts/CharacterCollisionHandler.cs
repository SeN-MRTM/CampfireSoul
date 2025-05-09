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
        Renderer renderer = hitObject.GetComponent<Renderer>();
        if (hitObject.tag == "Entity")
        {
            Destroy(hitObject);
        }

    }
}
