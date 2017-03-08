using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CanvasVis : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public static CanvasVis instance;

    void Start()
    {
        instance = this;
    }

    public static void Hide()
    {
        instance.canvasGroup.alpha = 0;
    }

    public static void Show()
    {
        instance.canvasGroup.alpha = 1;
    }
}
