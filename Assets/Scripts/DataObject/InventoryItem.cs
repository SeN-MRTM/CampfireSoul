using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class InventoryItem
{
    public Item Item { get; set; }
    public int Count { get; set; }

    public bool IsCreating { get; set; }
    public GameObject obj { get; set; }
}
