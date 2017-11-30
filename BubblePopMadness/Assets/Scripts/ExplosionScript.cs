using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    ScoreHandler sh;
    TimeManager tm;
    TouchInput input;
    public GameObject pop;

    Collider der;
    public float cooldown = 0.3f;
    // Use this for initialization
    void Start ()
    {
        input = FindObjectOfType<TouchInput>();
        sh = input.sh;
        tm = input.tm;
        der = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            der.enabled = false;
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BubbleMovement>() != null)
        {
            BubbleMovement bm = other.transform.GetComponent<BubbleMovement>();

            switch (bm.bubbleType)
            {
                case BubbleMovement.BubbleType.bubble:
                    sh.AddScore();
                    tm.AddTime(bm.timeFracture);
                    Instantiate(pop, other.transform.position, other.transform.rotation);
                    Destroy(other.transform.gameObject);
                    break;

                default:

                    break;
            }
        }
    } 
}
