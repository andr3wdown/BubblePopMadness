using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {

    [Header("SpawnAttributes")]
    [Space(10)]
    public float spawnDelay;
    float cooldown;
    public int amountOfSpawnage;

    public bool spawning = true;

    public float speedupRatio = 400;

    [Header("Objects")]
    [Space(10)]
    public GameObject holder;
    public GameObject[] bubbles;   
    public Transform[] spawnPoints;
    public float avgSpeed = 1.5f;
    public float maxSpeed = 3.0f;
    int randomChance = 128;
	// Use this for initialization
	void Start ()
    {
		if(Screen.width >= 800)
        {
            holder.transform.localScale = new Vector3(1.1f, 1, 1);
        }
	}
    bool
        first = false,
        second = false;
	// Update is called once per frame
	void Update ()
    {
        

        if (spawning)
        {
            avgSpeed += Time.deltaTime / 200;
            if(avgSpeed >= maxSpeed)
            {
                avgSpeed = maxSpeed;
            }
            spawnDelay -= Time.deltaTime / speedupRatio;
            if(spawnDelay < 0.5f && !first)
            {
                speedupRatio = speedupRatio * 2;
                first = true;
            }
            if(spawnDelay < 0.3 && !second)
            {
                speedupRatio = speedupRatio * 2f;
                second = true;
            }
            if(spawnDelay < 0.2f)
            {
                spawnDelay = 0.2f;
            }


            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                

                for(int i = 0; i < amountOfSpawnage; i++)
                {
                    int sele = Random.Range(0, spawnPoints.Length);
                    int objSele = Random.Range(0, randomChance);
                    switch (objSele)
                    {
                        default:
                            objSele = 0;
                            break;

                        case 0:
                            objSele = 1; break;

                        case 1:
                            objSele = 1; break;

                        case 2:
                            objSele = 1; break;

                        case 3:
                            objSele = 1; break;

                        case 4:
                            objSele = 1; break;

                        case 5:
                            objSele = 1; break;

                        case 6:
                            objSele = 1; break;

                        case 7:
                            objSele = 1; break;

                        case 8:
                            objSele = 2; break;

                        case 9:
                            objSele = 3; break;

                        case 10:
                            objSele = 4; break;



                    }

                    GameObject bubble = Instantiate(bubbles[objSele], spawnPoints[sele].position, Quaternion.identity) as GameObject;
                    switch (objSele)
                    {
                        case 4:
                            bubble.GetComponent<BubbleMovement>().timeFracture = spawnDelay * 1.1f;
                            bubble.GetComponent<BubbleMovement>().moveSpeed = Random.Range(avgSpeed - 0.5f, avgSpeed + 0.5f);
                            bubble.GetComponent<BubbleMovement>().bubbleType = BubbleMovement.BubbleType.laserBubble;
                            bubble.GetComponent<BubbleMovement>().hostile = false;
                            break;                            
                        case 3:
                            bubble.GetComponent<BubbleMovement>().timeFracture = spawnDelay * 1.1f;
                            bubble.GetComponent<BubbleMovement>().moveSpeed = Random.Range(avgSpeed - 0.5f, avgSpeed + 0.5f);
                            bubble.GetComponent<BubbleMovement>().bubbleType = BubbleMovement.BubbleType.explodingBubble;
                            bubble.GetComponent<BubbleMovement>().hostile = false;
                            break;
                        case 2:
                            bubble.GetComponent<BubbleMovement>().timeFracture = 15f;
                            bubble.GetComponent<BubbleMovement>().moveSpeed = Random.Range(avgSpeed - 0.5f, avgSpeed + 0.5f);
                            bubble.GetComponent<BubbleMovement>().bubbleType = BubbleMovement.BubbleType.timeBubble;
                            bubble.GetComponent<BubbleMovement>().hostile = false;
                            break;
                        case 1:
                            bubble.GetComponent<BubbleMovement>().timeFracture = 20;
                            bubble.GetComponent<BubbleMovement>().moveSpeed = Random.Range(0.8f, 1.8f);
                            bubble.GetComponent<BubbleMovement>().bubbleType = BubbleMovement.BubbleType.deathBubble;
                            bubble.GetComponent<BubbleMovement>().hostile = true;
                            break;

                        case 0:
                            bubble.GetComponent<BubbleMovement>().timeFracture = spawnDelay * 1.1f;
                            bubble.GetComponent<BubbleMovement>().moveSpeed = Random.Range(avgSpeed -0.5f, avgSpeed + 0.5f);                          
                            bubble.GetComponent<BubbleMovement>().bubbleType = BubbleMovement.BubbleType.bubble;
                            bubble.GetComponent<BubbleMovement>().hostile = false;
                            break;
                    }
                }
                

                cooldown = spawnDelay;
            }
        }
	}
}
