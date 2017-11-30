using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public float laserModeCooldown = 5.0f;
    public float laserModeDelay = 5.0f;
    public bool laserMode = false;
    public GameObject pop;
    public GameObject deathpop;
    public GameObject timePop;
    public GameObject explosion;
    public GameObject laserpop;
    [Tooltip("don't touch")]
    public TimeManager tm;
    [Tooltip("don't touch")]
    public ScoreHandler sh;
    public LayerMask bubbleLayer;
    LaserPooler laserPool;
    public LayerMask touchInputLayer;

	void Start ()
    {
        laserPool = FindObjectOfType<LaserPooler>();
        sh = FindObjectOfType<ScoreHandler>();
        tm = FindObjectOfType<TimeManager>();
        laser = new GameObject[laserPool.lasers.Count];
        for(int i = 0; i < laserPool.lasers.Count; i++)
        {
            laser[i] = laserPool.GetPooledObject();
            laser[i].SetActive(true);
        }

        for(int i = 0; i < laser.Length; i++)
        {
            laser[i].SetActive(false);
        }
	}

	void Update ()
    {
        if (!laserMode)
        {
         for(int i = 0; i < laser.Length; i++)
            {
                if (laser[i].activeInHierarchy)
                {
                    laser[i].SetActive(false);
                }
            }
#if UNITY_ANDROID || UNITY_IOS
        AndroidControl();
#endif

#if UNITY_STANDALONE || UNITY_WEBPLAYER
            PCTestControl();
#endif
        }
        else if (laserMode)
        {
            laserModeCooldown -= Time.deltaTime;
            if(laserModeCooldown <= 0)
            {

                laserModeCooldown = laserModeDelay;
                laserMode = false;
            }
#if UNITY_ANDROID || UNITY_IOS
        LaserControlAndroid();
#endif

#if UNITY_STANDALONE || UNITY_WEBPLAYER
            PcTestLaser();
#endif
        }

    }
    void AndroidControl()
    {
        if (Input.touchCount > 0)
        {
            /*  Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
              RaycastHit hit;
              if (Physics.Raycast(ray, out hit, Mathf.Infinity, bubbleLayer))
              {
                  Debug.Log(hit.point);
                  Destroy(hit.transform.gameObject);
              } */
            foreach (Touch t in Input.touches)
            {

                Ray ray = Camera.main.ScreenPointToRay(t.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, bubbleLayer))
                {
                    BubbleMovement bm = hit.transform.GetComponent<BubbleMovement>();

                    switch (bm.bubbleType)
                    {
                        case BubbleMovement.BubbleType.bubble:
                            sh.AddScore();
                            tm.AddTime(bm.timeFracture);
                            Instantiate(deathpop, hit.transform.position, hit.transform.rotation);
                            Destroy(hit.transform.gameObject);
                            break;

                        case BubbleMovement.BubbleType.deathBubble:
                            tm.LoseTime(bm.timeFracture);
                            Instantiate(pop, hit.transform.position, hit.transform.rotation);
                            Destroy(hit.transform.gameObject);
                            break;

                        case BubbleMovement.BubbleType.timeBubble:
                            sh.AddScore();
                            tm.AddTime(bm.timeFracture);
                            Instantiate(timePop, hit.transform.position, hit.transform.rotation);
                            Destroy(hit.transform.gameObject);
                            break;
                        case BubbleMovement.BubbleType.explodingBubble:
                            sh.AddScore();
                            tm.AddTime(bm.timeFracture);
                            Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                            Destroy(hit.transform.gameObject);
                            break;

                        case BubbleMovement.BubbleType.laserBubble:
                            sh.AddScore();
                            tm.AddTime(bm.timeFracture);                          
                            Instantiate(laserpop, hit.transform.position, hit.transform.rotation);
                            Destroy(hit.transform.gameObject);
                            laserMode = true;
                            break;
                    }

                    /*
                                           if (bm.hostile)
                                           {
                                                tm.LoseTime(bm.timeFracture);
                                                Instantiate(pop, hit.transform.position, hit.transform.rotation);
                                                Destroy(hit.transform.gameObject);
                                           }
                                           else if (!bm.hostile)
                                           {
                                                sh.AddScore();
                                                tm.AddTime(bm.timeFracture);
                                                Instantiate(deathpop, hit.transform.position, hit.transform.rotation);
                                                Destroy(hit.transform.gameObject);
                                           }

                                           */
                }
            }
        }
    }
    void PCTestControl()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, bubbleLayer))
            {
                BubbleMovement bm = hit.transform.GetComponent<BubbleMovement>();

                switch (bm.bubbleType)
                {
                    case BubbleMovement.BubbleType.bubble:
                        sh.AddScore();
                        tm.AddTime(bm.timeFracture);
                        Instantiate(deathpop, hit.transform.position, hit.transform.rotation);
                        Destroy(hit.transform.gameObject);
                        break;

                    case BubbleMovement.BubbleType.deathBubble:
                        tm.LoseTime(bm.timeFracture);
                        Instantiate(pop, hit.transform.position, hit.transform.rotation);
                        Destroy(hit.transform.gameObject);
                        break;

                    case BubbleMovement.BubbleType.timeBubble:
                        sh.AddScore();
                        tm.AddTime(bm.timeFracture);
                        Instantiate(timePop, hit.transform.position, hit.transform.rotation);
                        Destroy(hit.transform.gameObject);
                        break;
                    case BubbleMovement.BubbleType.explodingBubble:
                        sh.AddScore();
                        tm.AddTime(bm.timeFracture);
                        Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                        Destroy(hit.transform.gameObject);
                        break;
                    case BubbleMovement.BubbleType.laserBubble:
                        sh.AddScore();
                        tm.AddTime(bm.timeFracture);
                        Instantiate(laserpop, hit.transform.position, hit.transform.rotation);
                        Destroy(hit.transform.gameObject);
                        laserMode = true;
                        break;
                }
            }
        }

        
    }
    GameObject[] laser;
    void LaserControlAndroid()
    {



        
        if(Input.touchCount > 0)
        {
            //for (int i = 0; i < Input.touchCount; i++)
            //{

            foreach(Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began)
                {
                    
                    Ray ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, touchInputLayer))
                    {
                        Debug.Log("TouchStarted" + " " + t.fingerId);
                        laser[t.fingerId].SetActive(true);
                        Vector3 movepos = Camera.main.ScreenToWorldPoint(t.position);
                        movepos.z = 0;
                        laser[t.fingerId].transform.position = movepos;
                    }
                }
                else if (t.phase == TouchPhase.Moved)
                {
                    laser[t.fingerId].SetActive(true);
                    Debug.Log("Moved Finger" + " " + t.fingerId);
                    Ray ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, touchInputLayer))
                    {
                        Vector3 movepos = Camera.main.ScreenToWorldPoint(t.position);
                        movepos.z = 0;
                        laser[t.fingerId].transform.position = movepos;
                    }


                }
                else if (t.phase == TouchPhase.Ended)
                {
                    Debug.Log("Touch Ended" + " " + t.fingerId);
                    laser[t.fingerId].SetActive(false);
                }
            }
                

          //  }
        }
        
    

    }
    void PcTestLaser()
    {
        Vector3 movepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        movepos.z = 0;
        if(laser == null)
        {
            laser[0] = laserPool.GetPooledObject();
        }
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            laser[0].SetActive(true);
            laser[0].transform.position = movepos;
        }
        else
        {
            laser[0].SetActive(false);
        }
    }
}
