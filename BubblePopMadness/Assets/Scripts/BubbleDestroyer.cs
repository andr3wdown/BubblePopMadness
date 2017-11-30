using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDestroyer : MonoBehaviour
{
    TimeManager tm;
    public float timePenalty;
    private void Start()
    {
        tm = FindObjectOfType<TimeManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BubbleMovement>() != null)
        {
            if (other.GetComponent<BubbleMovement>().bubbleType == BubbleMovement.BubbleType.bubble)
            {
                tm.LoseTime(timePenalty);
            }
            Destroy(other.gameObject);
        }
     
        
    }

}
