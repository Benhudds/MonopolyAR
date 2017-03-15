using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTSManager : ITTSInterface
{
    private readonly ITTSInterface tts;

    public TTSManager()
    {
#if UNITY_ANDROID
        tts = new AndroidTTS();
#else
        //TODO implement for windows etc
#endif
    }

    public void Speak(string str)
    {
        if (Settings.TextToSpeech)
        {
            tts.Speak(str);
        }
    }
}
