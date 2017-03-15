using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public static TTSManager TTSM;

    public static bool GazeTracking = true;
    public static bool TextToSpeech = true;
    public static bool TileInformation = true;
    public static bool ColourCorrection = true;
    public static bool BalanceCounting = true;

    void Start()
    {
        TTSM = new TTSManager();
    }

    public void SetGazeTracking()
    {
        Settings.GazeTracking = !Settings.GazeTracking;
        TTSM.Speak("gaze interaction " + (GazeTracking ? "enabled" : "disabled"));
    }
    public void SetTextToSpeech()
    {
        Settings.TextToSpeech = !Settings.TextToSpeech;
        TTSM.Speak("text to speech " + (TextToSpeech ? "enabled" : "disabled"));
    }
    public void SetTileInformation()
    {
        Settings.TileInformation = !Settings.TileInformation;
        TTSM.Speak("tile information " + (TileInformation ? "enabled" : "disabled"));
    }
    public void SetColourCorrection()
    {
        Settings.ColourCorrection = !Settings.ColourCorrection;
        TTSM.Speak("colour correction " + (ColourCorrection ? "enabled" : "disabled"));
    }
    public void SetBalanceCounting()
    {
        Settings.BalanceCounting = !Settings.BalanceCounting;
        TTSM.Speak("balance counting " + (BalanceCounting ? "enabled" : "disabled"));
    }
}
