using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcduralCave : MonoBehaviour
{

    public int width;
    public int height;
    public int smoothCycles;

    public int[,] cavePoints;

    public int fillPercent;  
    public GameObject stone;
    public GameObject player;
    public GameObject wall;
    public GameObject Ladder;
    private void Awake()
    {
        Generate();
    }

    void Start()
    {
        PlaceGrid();
    }
    

    private void Generate()
    {
        bool lad = false;
        cavePoints = new int[width, height];

        int seed = Random.Range(0, 100000);
        System.Random randChoice = new System.Random(seed.GetHashCode());
       
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                {
                    cavePoints[x, y] = 1;
                }
                else if (randChoice.Next(0, 100) < fillPercent)
                {
                  
                    cavePoints[x, y] = 1;//wall
                }
                else
                {
                    cavePoints[x, y] = 0;
                    

                }
            }
        }
      //usuwanie przestrzeni bez przejscia
        for (int i = 0; i < 80; i++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int neighboringWalls = GetNeighbors(x, y);

                    if (neighboringWalls > 4)
                    {
                        cavePoints[x, y] = 1;
                    }
                    else if (neighboringWalls < 4)
                    {
                        cavePoints[x, y] = 0;
                    }
                }
            }
        }
        for (int x = 22; x < 27; x++)
        {
            for (int y = 22; y <27; y++)
            {
                cavePoints[x, y] = 0;
            }
        }
        //wstawianie drabiny
        while (!lad) {
            int x=randChoice.Next(3, 45);
            int y = randChoice.Next(3, 45);
            print("ladder "+x+" y "+y);
            if (cavePoints[x, y] == 0)
            {
                cavePoints[x, y] = 3;
                lad = true;

            }

        }
    }

    private int GetNeighbors(int pointX, int pointY)
    {

        int wallNeighbors = 0;

        for (int x = pointX - 1; x <= pointX + 1; x++)
        {
            for (int y = pointY - 1; y <= pointY + 1; y++)
            {
                if (x >= 0 && x < width && y >= 0 && y < height)
                {
                    if (x != pointX || y != pointY)
                    {
                        if (cavePoints[x, y] == 1)
                        {
                            wallNeighbors++;
                        }
                    }
                }
                else
                {
                    wallNeighbors++;
                }
            }
        }

        return wallNeighbors;
    }
    //sprites
    private void PlaceGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (cavePoints[x, y] == 1)
                {
                    Instantiate(wall, new Vector2(x, y), Quaternion.identity);
                }
                if (cavePoints[x, y] == 0)
                {
                    Instantiate(stone, new Vector2(x, y), Quaternion.identity);
                }
                if (cavePoints[x, y] ==3)
                {
                    Instantiate(Ladder, new Vector2(x, y), Quaternion.identity);
                }

            }
        }
       


    }
    
}
