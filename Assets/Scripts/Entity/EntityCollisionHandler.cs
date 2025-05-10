using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class EntityCollisionHandler : MonoBehaviour
{
    private GameObject entity;
    private bool _isGrounded = false;
    public float speedEntity = 2f;
    private Rigidbody _rb;
    private int _tickRate = 0;
    Vector3 _waitPoint;
    Vector3[] waypoints;
    [SerializeField] Health _health;
    private bool _isNear = false;
    private int _tickFight = 120;

    void Start()
    {
        entity = this.gameObject;
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _rb = entity.GetComponent<Rigidbody>();
        _rb.useGravity = true;
        waypoints = new Vector3[] {
            new Vector3(transform.position.x + 5, 1, transform.position.z + 5),
         new Vector3(transform.position.x, 1, transform.position.z + 5),
         new Vector3(transform.position.x, 1, transform.position.z),
         new Vector3(transform.position.x + 5, 1, transform.position.z )
        };
    }

    private void FixedUpdate()
    {
        if (_isGrounded)
            _rb.useGravity = false;
        else
            _rb.useGravity = true;
        if (gameObject.tag != "Item")
        {
            if (_tickRate == 0)
            {
                _tickRate = 600;
                _waitPoint = waypoints[UnityEngine.Random.Range(0, waypoints.Length)];
            }
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Player"))
                {
                    _waitPoint = new Vector3(hitCollider.transform.position.x,
                        1,
                        hitCollider.transform.position.z);
                }

            }
            if (_isNear)
            {
                if (_tickFight == 0)
                {
                    _health.ChangeHealth(-10);
                    _tickFight = 120;
                }
                else
                {
                    _tickFight -= 1;
                }
            }
            else
            {
                _tickFight = 120;
            }
            transform.position = Vector3.MoveTowards(transform.position, _waitPoint, speedEntity * Time.deltaTime);
        }
        _tickRate -= 1;
        
    }

    private void onVisible()
    {

    }

    void OnCollisionStay(Collision collision)
    {
        // Проверяем по тегу или слою
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            _isNear = true;
            if(gameObject.tag == "Item")
            {
                InventoryController inventory = GameObject.Find("Sell1").GetComponent<InventoryController>();
                InventoryItem inventoryItem = new InventoryItem();
                Item item = new Item();
                item.name = gameObject.name;
                item.maxStack = 1;
                item.description = "1";
                item.id = 1;
                item.sprite = Resources.Load<Sprite>("Sprites/Items/" + gameObject.name) ;
                inventoryItem.Item = item;
                inventoryItem.Count = 1;
                inventory.TakeItem(inventoryItem, 0);
                Destroy(gameObject);
            }
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            _isNear = false;
        }
    }


    void OnCollisionEnter(Collision collision)
    {

    }


}

