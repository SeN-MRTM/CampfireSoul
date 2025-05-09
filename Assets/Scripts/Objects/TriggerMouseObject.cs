using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TriggerMouseObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject canvas;
    [SerializeField] public Sprite _iconObject;
    GameObject _changeIconHPBar;
    void Start()
    {
        canvas = GameObject.FindWithTag("HPObject");
        //canvas.SetActive(false);
        canvas.transform.position = new Vector3(-306,1048);
        _changeIconHPBar = GameObject.FindWithTag("IconObject");
    }

    public void OnPointerEnter(PointerEventData _data)
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        //canvas.SetActive(true);
        canvas.transform.position = new Vector3(117, 1048);
        _changeIconHPBar.GetComponent<Image>().sprite = _iconObject;
    }
    public void OnPointerExit(PointerEventData _data)
    {
        GetComponent<MeshRenderer>().material.color = Color.gray;
        //canvas.SetActive(false);
        canvas.transform.position = new Vector3(-306, 1048);
    }
}
