using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Matrix : MonoBehaviour
{
 
    private List<GameObject> cubes = new List<GameObject>();
    public GameObject cube;
    public GameObject player;   
    private int spawnPosX = -3;
    private int spawnPosZ = 5;
    public static int size = 6;
    private int playerPos = size / 2;
    public static Vector3[,] spawnPos = new Vector3[size,size];
    string[] text = { string.Empty, string.Empty };
    int clickCount=0;
    private List<string> birds = new List<string>()
    {
        "Eagle","Pigeon","Falcon","Parrot","Dove","Hawk","Robin","Woodpecker","Flamingo"
    };
    int index = 0;
    int[] cubeIndex = { 0, 0 };
    int length = 0;
    int birdrandom = 0;
    int random1 = 0;
    int random2 = 0;
    bool assigned1 = false;
    bool assigned2 = false;
  
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<size;i++)
        {
            spawnPosX = -3;
            for (int j=0;j<size;j++)
            {
                spawnPos[i, j] = new Vector3(spawnPosX, 0, spawnPosZ);
                spawnPosX += 3;
            }
            spawnPosZ -= 3;
        }
        for(int i=0; i<size; i++)
        {
            for(int j=0;j<size;j++)
            {
                cubes.Add(Instantiate(cube, spawnPos[i, j], cube.transform.rotation));
                length++;
               
            }
        }
       
        
        for(int i=0; i<length/2; i++ )
        {
            assigned1 = false;
            assigned2 = false;
            birdrandom = Random.Range(0, 9);
            
                while (!assigned1 || !assigned2)
                {
                    random1 = Random.Range(0, length);
                    random2 = Random.Range(0, length);
                    if (random1 != random2)
                    {
                        if (cubes[random1].GetComponentInChildren<TextMeshPro>().text == string.Empty && !assigned1)
                        {
                            cubes[random1].GetComponentInChildren<TextMeshPro>().text = birds[birdrandom];
                            assigned1 = true;
                        }
                        if (cubes[random2].GetComponentInChildren<TextMeshPro>().text == string.Empty && !assigned2)
                        {
                            cubes[random2].GetComponentInChildren<TextMeshPro>().text = birds[birdrandom];
                            assigned2 = true;
                        }
                    }
                }


            
        }    
      //  Instantiate(player, spawnPos[playerPos, playerPos] + new Vector3(0, 2, 0), player.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        CheckSame();
    }
    void CheckSame()
    {
        var tests = cubes;
        for(int i=0;i<length;i++)
        {
            
            if (cubes[i].gameObject.GetComponent<Cube>().click == true)
            {

                if (clickCount < 2)
                {

                    text[clickCount] = cubes[i].GetComponentInChildren<TextMeshPro>().text;
                    cubeIndex[clickCount] = i;
                    clickCount++;
                    
                 
                }
                if (clickCount == 2)
                {
                    if (text[0] == text[1])
                    {
                        cubes[cubeIndex[0]].SetActive(false);
                        cubes[cubeIndex[1]].SetActive(false);
                        
                        
                    }
                    cubes[cubeIndex[0]].GetComponent<Cube>().click = false;
                    cubes[cubeIndex[1]].GetComponent<Cube>().click = false;
                }
              
            }

        }
        clickCount = 0;
        
    }
}
