using UnityEngine;

public class CraftCollisionController : MonoBehaviour
{

    public bool nearCraft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nearCraft = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                nearCraft = true;
            }
            else
            {
                nearCraft = false;
            }
        }
        if (nearCraft) 
        {
            if (Input.GetKey(KeyCode.Tab)) 
            {
                Debug.Log("Open Craft Menu");
            }
        }
    }


}
