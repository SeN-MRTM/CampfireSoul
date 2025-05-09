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
    private Rigidbody _rb;


    void Start()
    {
        entity = this.gameObject;
        _rb = entity.GetComponent<Rigidbody>();
        _rb.useGravity = true;
    }

    private void Update()
    {
        if (_isGrounded)
            _rb.useGravity = false;
        else
            _rb.useGravity = true;
    }

    void OnCollisionStay(Collision collision)
    {
        // Проверяем по тегу или слою
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        
    }


}

