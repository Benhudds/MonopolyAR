using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        Settings.TTSM.Speak("Let's play boys");
        SceneManager.LoadScene(sceneIndex);
    }
}
