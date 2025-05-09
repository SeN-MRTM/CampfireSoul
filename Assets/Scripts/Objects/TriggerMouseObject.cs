using UnityEngine;
using UnityEngine.EventSystems;

[DefaultExecutionOrder(100)]
public class TriggerMouseObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

     GameObject canvas;

    void Awake()
    {
        canvas = GameObject.FindWithTag("HPObject");
        
    }

    void Start()
    {
        canvas.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData _data)
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        canvas.SetActive(true);
    }
    public void OnPointerExit(PointerEventData _data)
    {
        GetComponent<MeshRenderer>().material.color = Color.gray;
        canvas.SetActive(false);
    }
}
