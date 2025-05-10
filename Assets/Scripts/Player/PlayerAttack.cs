using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] public float _attackDmgPlayer = 20;
    [SerializeField] public float _attackSpeedPlayer = 10;
    [SerializeField] public float _attackDistancePlayer = 1.5f;
    private float _tickRate = 60;
    Health _healthObject;
    bool isNear = false;

    TriggerMouseObject _triggerMouseObject;

   // private void Start()
    //{
      //  _triggerMouseObject = GetComponent<TriggerMouseObject>();
      //  _healthObject = _triggerMouseObject._ObjectToAttack.GetComponent<Health>();
   // }

   // private void Update()
   // {
   //     Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
   //     foreach (var hitCollider in hitColliders)
   //     {
   //         if (hitCollider.gameObject)
   //         {
   //             isNear = true;
   //         }
   //         else
   //         {
   //             isNear = false;
   //         }
   //
   //     }
   //
   //     if (Input.GetMouseButtonDown(1)  &&
   //         _triggerMouseObject._triggerObject &&
   //         (isNear))
   //     {
   //         _healthObject.ChangeHealth(_attackDmgPlayer);  
   //     }
   // }
}
