using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vuforia;
using UnityEngine;

public class BensHighligher : MonoBehaviour
{
    private readonly List<Renderer> tHighlighted = new List<Renderer>();
    private const float timer = 9;
    private float timeLeft = timer;
    private int hitId;

    // Use this for initialization
    void Start ()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
	
	// Update is called once per frame
	void Update ()
	{
        TouchTracking();

	    if (Settings.GazeTracking)
	    {
	        GazeTracking();
	    };
	}

    private void TouchTracking()
    {
        foreach(var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                var ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit rhit;
                if (Physics.Raycast(ray, out rhit, 1000) && rhit.transform.name == "SquareBase")
                {
                    foreach (
                var childRenderer in
                rhit.transform.GetComponentsInChildren<MeshRenderer>().Where(mr => mr.name != "SquareBase"))
                    {
                        childRenderer.enabled = !childRenderer.enabled;
                    }
                }
            }
        }
    }

    private void GazeTracking()
    {
        tHighlighted.ForEach(t => t.enabled = false);

        RaycastHit rhit;
        if (Physics.Raycast(new Ray(transform.position, transform.forward), out rhit, 1000) &&
            rhit.transform.name == "SquareBase")
        {

            if (hitId != rhit.transform.GetInstanceID())
            {
                timeLeft = timer;
                tHighlighted.ForEach(t => t.material.color = Color.yellow);
                hitId = rhit.transform.GetInstanceID();
            }

            foreach (
                var childRenderer in
                rhit.transform.GetComponentsInChildren<MeshRenderer>().Where(mr => mr.name != "SquareBase"))
            {

                childRenderer.enabled = true;
                tHighlighted.Add(childRenderer);
                timeLeft -= Time.deltaTime;
            }

            if (timeLeft <= 0)
            {
                // Do stuff. This is where we would launch the other scene

                // TEST CODE
                tHighlighted.ForEach(t => t.material.color = Color.cyan);
            }
        }
        else
        {
            timeLeft = timer;
            tHighlighted.ForEach(t => t.material.color = Color.yellow);
            tHighlighted.Clear();
        }
    }
}
