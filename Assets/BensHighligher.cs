using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BensHighligher : MonoBehaviour
{
    private List<Transform> tHighlighted = new List<Transform>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        this.tHighlighted.ForEach(t => t.GetComponent<MeshRenderer>().material.color = Color.white);

        tHighlighted.Clear();

	    RaycastHit rhit;
	    if (Physics.Raycast(new Ray(transform.position, transform.forward), out rhit, 1000))
	    {
	        if (rhit.transform.name == "SquareBase" && !tHighlighted.Contains(rhit.transform))
	        {
	            rhit.transform.GetComponent<MeshRenderer>().material.color = Color.cyan;
                tHighlighted.Add((rhit.transform));

            }
	    }
	}
}
