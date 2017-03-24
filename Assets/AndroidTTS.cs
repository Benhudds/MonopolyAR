using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidTTS : ITTSInterface
{
    private readonly AndroidJavaObject tts;

    public AndroidTTS()
    {
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject context = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        tts = new AndroidJavaObject("com.example.ttslib.TTS", context);
    }

    public void Speak(string str)
    {
        tts.Call("Speak", new AndroidJavaObject("java.lang.String", str));
    }
}
