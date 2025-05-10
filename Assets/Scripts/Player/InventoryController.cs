using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    InventoryItem[] inventory;
    [SerializeField]
    public int inventoryLength = 10;
    private GameObject _canvas;
   


    void Start()
    {
        inventory = new InventoryItem[10];
        for (int i = 0; i < inventoryLength; i++)
        {
            inventory[i] = TempData.globalInventory[i];
        }
        _canvas = GameObject.FindWithTag("Inventory");
        
    }

    void Update()
    {
        
        
        for (int i = 0; i < inventoryLength; i++)
        {
            try
            {
                inventory[i] = TempData.globalInventory[i];
            }
            catch
            {

            }
        }
        for (int i = 0; i < inventoryLength; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].IsCreating)
                {
                    continue;
                }
                else
                {
                    GameObject imgObj = new GameObject("SellItem" + i);
                    inventory[i].obj = imgObj;
                    imgObj.transform.parent = GameObject.Find("Sell" + i.ToString()).transform;
                    Image img = imgObj.AddComponent<Image>();
                    img.sprite = inventory[i].Item.sprite;
                    RectTransform rt = imgObj.GetComponent<RectTransform>();
                    rt.anchoredPosition = Vector2.zero;
                    rt.sizeDelta = new Vector2(100, 100);
                    inventory[i].IsCreating = true;
                }
                if (inventory[i].obj.name != "SellItem" + i.ToString())
                {
                    inventory[i].IsCreating = false;
                    Destroy(inventory[i].obj);
                }
            }
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        try
        {
            string char1 = gameObject.name[gameObject.name.Length - 1].ToString();
            int indexSell = Int32.Parse(char1);
            if (TempData.itemInCursor != null)
            {
                TakeItem(TempData.itemInCursor, indexSell);
                TempData.itemInCursor = null;
                return;
            }
            if (inventory[indexSell] != null)
            {
                TempData.itemInCursor = inventory[indexSell];
                inventory[indexSell].IsCreating = false;
                Destroy(inventory[indexSell].obj);
                TempData.globalInventory[indexSell] = null;
            }
        }
        catch (Exception e)
        {
            Debug.Log("Чет не то" + e);
        }

    }

    public void OnPointerEnter(PointerEventData _data)
    {
        try
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/UI/InventorySellActive");
        }
        catch (NullReferenceException e)
        {

        }

    }
    public void OnPointerExit(PointerEventData _data)
    {
        try
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/UI/InventorySell");
        }
        catch (NullReferenceException e)
        {

        }
    }



    public void TakeItem(InventoryItem item, int indexSell)
    {
        if (indexSell > inventoryLength - 1)
        {
            return;
        }
        if (inventory[indexSell] != null)
        {
            if (inventory[indexSell].Item.id == item.Item.id)
            {
                if ((inventory[indexSell].Count + item.Count) > item.Item.maxStack)
                {
                    //Перебор по стаку
                    inventory[indexSell].Count = item.Item.maxStack;
                    TempData.globalInventory[indexSell].Count = item.Item.maxStack;
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] == null)
                        {
                            item.Count -= item.Item.maxStack;
                            TakeItem(item, i);
                            return;
                        }
                    }
                }

            }
            else
            {
                TempData.itemInCursor = inventory[indexSell];
            }
        }
        inventory[indexSell] = item;
        TempData.globalInventory[indexSell] = item;

    }

    public void DropItem(InventoryItem item, int indexSell)
    {
        inventory[indexSell] = null;
    }

}



