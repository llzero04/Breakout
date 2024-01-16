using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreater : MonoBehaviour
{
    public GameObject brick;

    // Limits x, -8.3 to 8.3 with 1 as width
    // 4.7 to 1 with 0.5 as width
    // Start is called before the first frame update
    void Start()
    {
        createLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool rand50()
    {
        return ((Random.Range(0, 10) & 1) == 0 ? false : true);
    }

    bool rand75()
    {
        return rand50() | rand50();
    }

    void createLevel()
    {
        int level = FindAnyObjectByType<GameManager>().getLevel();

        float xStart = -8f, yStart = 4.7f;
        float xEnd = 8f, yEnd = 1f;
        int instantiatedCount = 0;
        GameObject instantiated;
        for (float j = yStart; j >= yEnd; j-=0.5f)
        {
            for(float i = xStart; i <= xEnd; i++)
            {
                // Create Brick
                // Instantiate(brick, new Vector3(i, j), Quaternion.identity);

                if(level == 1)
                {
                    if(!rand75())
                    {
                        instantiated = Instantiate(brick, new Vector3(i, j), Quaternion.identity);
                        instantiated.GetComponent<BrickObjectScript>().setBrickHealth(Random.Range(1, 4));
                        instantiatedCount += 1;
                    }
                }
                else if(level == 2)
                {
                    if(rand50())
                    {
                        instantiated = Instantiate(brick, new Vector3(i, j), Quaternion.identity);
                        instantiated.GetComponent<BrickObjectScript>().setBrickHealth(Random.Range(1, 4));
                        instantiatedCount += 1;
                    }
                }
                else if(level == 3)
                {
                    if (rand75())
                    {
                        instantiated = Instantiate(brick, new Vector3(i, j), Quaternion.identity);
                        instantiated.GetComponent<BrickObjectScript>().setBrickHealth(Random.Range(1, 4));
                        instantiatedCount += 1;
                    }
                }
                else if(level == 4)
                {
                    instantiated = Instantiate(brick, new Vector3(i, j), Quaternion.identity);
                    instantiated.GetComponent<BrickObjectScript>().setBrickHealth(Random.Range(1, 4));
                    instantiatedCount += 1;
                }
            }
        }

        FindAnyObjectByType<GameManager>().setTotalBricks(instantiatedCount);
    }
}
