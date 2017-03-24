using System.Threading;

public class TTSManager : ITTSInterface
{
    //public HoloLensTTS htts;
    private ITTSInterface tts;

    public TTSManager()
    {
#if UNITY_ANDROID
        tts = new AndroidTTS();
#else
        tts = new HoloLensTTS();
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
