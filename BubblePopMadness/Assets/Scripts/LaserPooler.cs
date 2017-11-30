using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPooler : MonoBehaviour
{
    public GameObject laser;

    public int touchAmount;

    public List<GameObject> lasers;

	void Start ()
    {
        lasers = new List<GameObject>();

        for(int i = 0; i < touchAmount; i++)
        {
            GameObject go = Instantiate(laser) as GameObject;
            go.SetActive(false);
            lasers.Add(go);
        }
	}
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < lasers.Count; i++)
        {
            if (!lasers[i].activeInHierarchy)
            {
                return lasers[i];
            }
        }

        GameObject go = Instantiate(laser) as GameObject;
        go.SetActive(false);
        lasers.Add(go);

        return go;
    }

    void Joo()
    {
        GameObject laser = this.GetPooledObject();
        laser.SetActive(true);
    }
}
