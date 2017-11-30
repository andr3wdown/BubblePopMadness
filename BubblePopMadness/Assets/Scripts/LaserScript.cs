using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    ScoreHandler sh;
    TimeManager tm;
    TouchInput input;
    public GameObject pop;
    public Touch touch;
    void Start()
    {
        input = FindObjectOfType<TouchInput>();
        sh = input.sh;
        tm = input.tm;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BubbleMovement>() != null)
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
                case BubbleMovement.BubbleType.timeBubble:
                    sh.AddScore();
                    tm.AddTime(bm.timeFracture);
                    Instantiate(input.timePop, other.transform.position, other.transform.rotation);
                    Destroy(other.transform.gameObject);
                    break;
                case BubbleMovement.BubbleType.explodingBubble:
                    sh.AddScore();
                    tm.AddTime(bm.timeFracture);
                    Instantiate(input.explosion, other.transform.position, other.transform.rotation);
                    Destroy(other.transform.gameObject);
                    break;
                case BubbleMovement.BubbleType.laserBubble:
                    sh.AddScore();
                    tm.AddTime(bm.timeFracture);
                    Instantiate(input.laserpop, other.transform.position, other.transform.rotation);
                    Destroy(other.transform.gameObject);
                    input.laserModeCooldown = input.laserModeDelay;
                    input.laserMode = true;
                    break;
            }
        }
    }
}
