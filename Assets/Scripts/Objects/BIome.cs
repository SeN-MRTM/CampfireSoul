using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Biome
{
    public string NameBiome;
    public List<Vector3> TileCoords;

    public Biome(string biome)
    { 
        NameBiome = biome;
        TileCoords = new List<Vector3>();
    }
}




