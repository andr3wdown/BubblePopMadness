using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCanvas : MonoBehaviour {

    bool start = true;
	
	// Update is called once per frame
	void Update ()
    {
        if (start)
        {
            Time.timeScale = 0;
            start = false;
        }
#if UNITY_ANDROID || UNITY_IOS
        
        if(Input.touchCount > 0)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
#endif

#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
#endif
    }

}
