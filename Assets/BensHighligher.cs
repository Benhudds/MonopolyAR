using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;

public class BensHighligher : MonoBehaviour
{
    private readonly List<Transform> tHighlighted = new List<Transform>();

	// Use this for initialization
	void Start ()
	{
	    CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}
	
	// Update is called once per frame
	void Update ()
	{
        tHighlighted.ForEach(t => t.GetComponent<MeshRenderer>().material.color = Color.white);

        tHighlighted.Clear();

	    RaycastHit rhit;
	    if (Physics.Raycast(new Ray(transform.position, transform.forward), out rhit, 1000) && rhit.transform.name == "SquareBase")
	    {
	        if (!tHighlighted.Contains(rhit.transform))
	        {
	            rhit.transform.GetComponent<MeshRenderer>().material.color = Color.cyan;
                tHighlighted.Add(rhit.transform);
            }
	    }
	}
}
