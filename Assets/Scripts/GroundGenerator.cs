
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[DefaultExecutionOrder(11)]
public class GroundGenerator : MonoBehaviour
{

    public int width;
    public int height;
    public int roomCount;
    public int minRoomSize;
    public int maxRoomSize;
    public GameObject floorPrefab;
    public Material roadBiomMaterial;
    public Material spawnBiomMaterial;
    public Material waterBiomMaterial;
    public Material[] biomesMaterials;


    private BiomeTile[,] maze;
    private List<Material> usedMaterial = new List<Material>();
    private List<RectInt> rooms = new List<RectInt>();
    private int globalX, globalY;

     void Start()
    {
        globalX = width / 2;
        globalY = height / 2;
        GenerateDungeon();
    }

     void GenerateDungeon()
    {
        maze = new BiomeTile[width * 2 + 1, height * 2 + 1];
        for (int x = 0; x < width * 2 + 1; x++)
        {
            for (int y = 0; y < height * 2 + 1; y++)
            {
                maze[x, y] = new BiomeTile(false, waterBiomMaterial);
            }
        }


        // 1. Генерация комнат


        for (int i = 0; i < roomCount; i++)
        {
            int _x = Random.Range(0, width - maxRoomSize - 1);
            int _y = Random.Range(0, height - maxRoomSize - 1);
            CreateRoom(SelectBiome(), _x, _y);
        }

        // 2. Соединение комнат коридорами
        for (int i = 1; i < rooms.Count; i++)
        {
            ConnectRooms(rooms[i - 1], rooms[i]);
        }
        FirstRoom();
        // 3. Визуализация
        VisualizeMaze();
    }

    void FirstRoom()
    {
        CreateRoom(spawnBiomMaterial, globalX - minRoomSize / 2, globalY - minRoomSize / 2);
    }

    void CreateRoom(Material biom, int _x, int _y)
    {
        int roomWidth = Random.Range(minRoomSize, maxRoomSize);
        int roomHeight = Random.Range(minRoomSize, maxRoomSize);


        RectInt newRoom = new RectInt(_x, _y, roomWidth, roomHeight);


        rooms.Add(newRoom);
        CarveRoom(newRoom, biom);

    }

    Material SelectBiome()
    {
        bool isUsed = false;
        Material output = biomesMaterials[Random.Range(0, biomesMaterials.Length)];
        if (usedMaterial.Count == biomesMaterials.Length)
        {
            usedMaterial.Clear();
        }
        foreach (Material mat in usedMaterial)
        {
            if (mat == output)
            {
                isUsed = true;
                break;
            }
        }
        if (!isUsed)
        {
            usedMaterial.Add(output);
            return output;
        }
        else
        {
            return SelectBiome();
        }
    }

    void CarveRoom(RectInt room, Material material)
    {
        for (int x = room.x; x < room.x + room.width; x++)
        {
            for (int y = room.y; y < room.y + room.height; y++)
            {
                maze[x, y] = new BiomeTile(true, material); // true = проходимая клетка
            }
        }
    }

    void ConnectRooms(RectInt roomA, RectInt roomB)
    {
        Vector2Int pointA = new Vector2Int(
            Random.Range(roomA.x + 1, roomA.x + roomA.width - 1),
            Random.Range(roomA.y + 1, roomA.y + roomA.height - 1));

        Vector2Int pointB = new Vector2Int(
            Random.Range(roomB.x + 1, roomB.x + roomB.width - 1),
            Random.Range(roomB.y + 1, roomB.y + roomB.height - 1));

        // Горизонтальный коридор
        for (int x = Mathf.Min(pointA.x, pointB.x); x <= Mathf.Max(pointA.x, pointB.x); x++)
        {
            maze[x, pointA.y] = new BiomeTile(true, roadBiomMaterial);
        }

        // Вертикальный коридор
        for (int y = Mathf.Min(pointA.y, pointB.y); y <= Mathf.Max(pointA.y, pointB.y); y++)
        {
            maze[pointB.x, y] = new BiomeTile(true, roadBiomMaterial);
        }
    }

    void VisualizeMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x, 0, y);
                if (maze[x, y] == null)
                    continue;
                if (maze[x, y].isFloor)
                {
                    Biome thisBiome = null;
                    foreach (Biome biome in TempData.biomes)
                    {
                        if (biome != null)
                        {
                            if (biome.NameBiome == maze[x, y].biomMaterial.name)
                            {

                                thisBiome = biome;
                            }
                        }
                    }
                    if (thisBiome != null)
                    {
                        thisBiome.TileCoords.Add(pos);
                    }
                    else
                    {
                        thisBiome = new Biome(maze[x, y].biomMaterial.name);
                        TempData.biomes.Add(thisBiome);
                        thisBiome.TileCoords.Add(pos);
                    }

                    var floorTile = Instantiate(floorPrefab, pos, Quaternion.identity);
                    floorTile.tag = "Ground";
                    Renderer renderer = floorTile.GetComponent<Renderer>();
                    renderer.material = maze[x, y].biomMaterial;
                }

            }
        }
    }


}
