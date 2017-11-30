using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Facebook.Unity;

public class FacebookManager : MonoBehaviour
{
    ScoreHandler sc;
    Texture2D screenCap;
    Texture2D border;
    bool shot = false;
    private void Awake()
    {
        /*screenCap = new Texture2D(300, 200, TextureFormat.RGB24, false);
        border = new Texture2D(2, 2, TextureFormat.ARGB32, false);
        border.Apply(); */
        sc = FindObjectOfType<ScoreHandler>();
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }
    }

   
    

    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();
        screenCap.ReadPixels(new Rect(198, 98, 298, 198), 0, 0);
        screenCap.Apply();
        byte[] bytes = screenCap.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "SavedScreen.png", bytes);      
        shot = true;
    }

    IEnumerator Delete()
    {
        yield return new WaitForEndOfFrame();
        File.Delete("SavedScreen.png");
    }
    public void ShareOnFB()
    {

        //StartCoroutine("Capture");
        FB.ShareLink(
            contentURL: new System.Uri("https://play.google.com/apps/details?id=com.UpGames.bubblepop"),
            photoURL: new System.Uri("http://i.imgur.com/MdBkIj2.png"),
            contentTitle: "I just got a score of " + sc.highscore + " in Bubble Pop Madness! Download Bubble Pop Madness now on Google PlayStore!",
            contentDescription: "Bubble Pop Madness is a fun and easy to get into mobile game for anyone! Download it now free on the Google PlayStore",
            callback: OnShare);           
    }
    void OnShare(IShareResult result)
    {
        if(result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink error: " + result.Error);
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log(result.PostId);
        }
        else
        {
            Debug.Log("Shared Succesfully!");
        }
    }
   /* private void OnGUI()
    {
        GUI.DrawTexture(new Rect(300, 100, 300, 2), border, ScaleMode.StretchToFill); // top
        GUI.DrawTexture(new Rect(300, 300, 300, 2), border, ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(200, 100, 2, 200), border, ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(500, 100, 2, 200), border, ScaleMode.StretchToFill);
    } */

}
