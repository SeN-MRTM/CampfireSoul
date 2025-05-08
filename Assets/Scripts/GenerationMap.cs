using UnityEngine;

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
            entity.count = Random.Range(entity.minValue, entity.maxValue);
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
        Generate(entityes.data[entityCount].entity);
        generatedObjectCount++;

    }
    //сама генерация 
    public void Generate(GameObject entity)
    {
        Vector3 position = new Vector3(x + Random.Range(minRange, maxRange), transform.position.y, z + Random.Range(minRange, maxRange));
        var cell = Instantiate(entity, position, Quaternion.identity);
    }
}


