using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Vuforia;
using UnityEngine;

public class BensHighligher : MonoBehaviour
{
    public LayerMask lPhysicsMask;
    private TouchHighlighter tHighlighter;
    private GazeHighlighter gHighlighter;

    // Use this for initialization
    void Start ()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

        if (Settings.TileInformation)
        {
            if (Settings.GazeTracking)
            {
                gHighlighter = new GazeHighlighter(lPhysicsMask);
            }
            else
            {
                tHighlighter = new TouchHighlighter(lPhysicsMask);
            }
        }
    }
	
	// Update is called once per frame
    void Update()
    {
        if (Settings.TileInformation)
        {
            if (Settings.GazeTracking)
            {
                gHighlighter.GazeTracking(transform);
            }
            else
            {
                tHighlighter.TouchTracking(transform);
            }
        }
    }


}
