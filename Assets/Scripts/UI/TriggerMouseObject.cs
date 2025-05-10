using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class TriggerMouseObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    GameObject canvas;
    [SerializeField] public Sprite _iconObject;
    [SerializeField] public GameObject _ObjectToAttack;
    GameObject _changeIconHPBar;
    Health _healthObject;
    public bool _triggerObject = false;
    private bool _isNear = false;
    private bool _isAdd = false;

    void Awake()
    {
        _healthObject = GetComponent<Health>();
        GameObject.Find("HPBarObject").GetComponent<HealthBarObject>()._health = _healthObject;
    }
    void Start()
    {
        canvas = GameObject.FindWithTag("HPObject");
        //canvas.SetActive(false);
        canvas.transform.position = new Vector3(-306, 1048);
        _changeIconHPBar = GameObject.FindWithTag("IconObject");
        _ObjectToAttack = GetComponent<GameObject>();

    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject)
            {
                _isNear = true;
            }
            else
            {
                _isNear = false;
            }

        }
    }

    public void OnPointerEnter(PointerEventData _data)
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        //canvas.SetActive(true);
        canvas.transform.position = new Vector3(117, 1048);
        _changeIconHPBar.GetComponent<UnityEngine.UI.Image>().sprite = _iconObject;
        if (_isAdd)
        {
            GameObject.Find("HPBarObject").GetComponent<HealthBarObject>()._health.HealthChanged += GameObject.Find("HPBarObject").GetComponent<HealthBarObject>().OnHealthChanged;
            _isAdd = true;
        }
        _triggerObject = true;
    }

    public void OnPointerClick(PointerEventData _data)
    {

        if (_isNear)
        {
            _healthObject.ChangeHealth(GameObject.Find("Player").GetComponent<PlayerAttack>()._attackDmgPlayer * -1);
        }
    }

    public void OnPointerExit(PointerEventData _data)
    {
        GetComponent<MeshRenderer>().material.color = Color.gray;
        //canvas.SetActive(false);
        canvas.transform.position = new Vector3(-306, 1048);
        _triggerObject = false;
    }
}
