using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Image image;  
    public GameObject gameOverCanvas;
    TouchInput ti;

    [Header("Level Time at Start")]
    public float levelTime;
    float startTime;
    // Use this for initialization
    void Start ()
    {
        ti = FindObjectOfType<TouchInput>();
        startTime = levelTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        levelTime -= Time.deltaTime;
        UpdateBar();
        if(levelTime <= 0)
        {
            ti.gameObject.SetActive(false);
            levelTime = 0;
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
        } 
	}

    void UpdateBar()
    {
        if(levelTime >= startTime)
        {
            levelTime = startTime;
        }
        float ratio = levelTime / startTime;
        image.rectTransform.localScale = new Vector3(ratio,1,1);
    } 

    public void AddTime(float timeToAdd)
    {
        levelTime += timeToAdd;
    }

    public void LoseTime(float lostTime)
    {
        levelTime -= lostTime;
    }
}
