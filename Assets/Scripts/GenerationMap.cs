using UnityEngine;

[DefaultExecutionOrder(50000)]
public class GenerationMap : MonoBehaviour
{

    public EntityOnMap entityes;
    private int generatedObjectCount = 0;
    private int entityCount;
    public float minRange, maxRange; //радиус спавна
    public float x, z;

    private void Start()
    {
        entityCount = entityes.data.Count - 1;
        foreach (var entity in entityes.data)
        {
            entity.count = Random.Range(entity.MinValue, entity.MaxValue);
        }
    }

    void Update()
    {
        if (entityCount == -1)
            return;
        if (generatedObjectCount == entityes.data[entityCount].count)
        {
            entityCount--;
            generatedObjectCount = 0;
            return;
        }
        Generate(entityes.data[entityCount].Entity,
            entityes.data[entityCount].Biome);
        generatedObjectCount++;

    }
    //сама генерация 
    public void Generate(GameObject entity, Material biome)
    {
        Biome thisBiome = new Biome("Default");
        thisBiome.TileCoords = new System.Collections.Generic.List<Vector3>();
        thisBiome.TileCoords.Add(new Vector3(260, 2, 260));
        foreach(Biome tempBiome in TempData.biomes) 
        {
            if(biome.name.IndexOf(tempBiome.NameBiome) != -1)
            {
                thisBiome = tempBiome;
            }
        }
        Vector3 position = thisBiome.TileCoords[Random.Range(0, thisBiome.TileCoords.Count)];
        var cell = Instantiate(entity, new Vector3( position.x, 2, position.z), Quaternion.identity);
        cell.AddComponent<EntityCollisionHandler>();
        cell.tag = "Entity";
        cell.AddComponent<Rigidbody>();
        
    }

    
}


