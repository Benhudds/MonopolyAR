using UnityEngine;
using System.Collections;

public class CPH_demo_rotate : MonoBehaviour {

	public Vector3 rotationSpeed;

	const float rotationSpeedCoef = 20;

	// Use this for initialization
	void Start () 
	{	
		transform.rotation = UnityEngine.Random.rotation;
		rotationSpeed.x = UnityEngine.Random.Range(-rotationSpeedCoef,rotationSpeedCoef);
		rotationSpeed.y = UnityEngine.Random.Range(-rotationSpeedCoef,rotationSpeedCoef);
		rotationSpeed.z = UnityEngine.Random.Range(-rotationSpeedCoef,rotationSpeedCoef);
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate ( Vector3.left * ( rotationSpeed.x * Time.deltaTime ) );
		transform.Rotate ( Vector3.up * ( rotationSpeed.y * Time.deltaTime ) );
		transform.Rotate ( Vector3.forward * ( rotationSpeed.z * Time.deltaTime ) );

	}
}
