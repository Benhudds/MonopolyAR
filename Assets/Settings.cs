using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    public static bool GazeTracking = true;
    public static bool TextToSpeech = true;
    public static bool TileInformation = true;
    public static bool ColourCorrection = true;
    public static bool BalanceCounting = true;

    public void SetGazeTracking()
    {
        Settings.GazeTracking = !Settings.GazeTracking;
    }
    public void SetTextToSpeech()
    {
        Settings.TextToSpeech = !Settings.TextToSpeech;
    }
    public void SetTileInformation()
    {
        Settings.TileInformation = !Settings.TileInformation;
    }
    public void SetColourCorrection()
    {
        Settings.ColourCorrection = !Settings.ColourCorrection;
    }
    public void SetBalanceCounting()
    {
        Settings.BalanceCounting = !Settings.BalanceCounting;
    }
}
