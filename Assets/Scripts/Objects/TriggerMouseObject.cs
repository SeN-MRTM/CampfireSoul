using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[DefaultExecutionOrder(100)]
public class TriggerMouseObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    GameObject canvas;
    [SerializeField] private Sprite _icon;
    private UnityEngine.UI.Image _currentIcon;
    void Start()
    {
        canvas = GameObject.FindWithTag("HPObject");
        //canvas.SetActive(false);
        canvas.transform.position = new Vector3(-306,1048);
        _icon = GetComponent<Sprite>();

    }

    public void OnPointerEnter(PointerEventData _data)
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        //canvas.SetActive(true);
        _currentIcon.sprite = _icon;
        canvas.transform.position = new Vector3(117, 1048); 
    }
    public void OnPointerExit(PointerEventData _data)
    {
        GetComponent<MeshRenderer>().material.color = Color.gray;
        //canvas.SetActive(false);
        canvas.transform.position = new Vector3(-306, 1048);
    }
}
