using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour {
    public float moveSpeed;
    public float timeFracture;
    public bool hostile;
    public enum BubbleType
    {
        bubble,
        deathBubble,
        timeBubble,
        explodingBubble,
        laserBubble
    }

    public BubbleType bubbleType;
    private void Start()
    {
        //moveSpeed = Random.Range(moveSpeed - 0.5f, moveSpeed + 0.5f);
    }
    void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up, moveSpeed * Time.deltaTime);
	}
}
