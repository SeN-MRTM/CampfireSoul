
using UnityEngine;


[System.Serializable]
public class EntityWithInt
{
    public GameObject Entity;
    public Material Biome;
    public int MinValue;
    public int MaxValue;
    public int count { get; set; }

  
}

public class EntityOnMap : MonoBehaviour
{
    public System.Collections.Generic.List<EntityWithInt> data = new System.Collections.Generic.List<EntityWithInt>();
}
