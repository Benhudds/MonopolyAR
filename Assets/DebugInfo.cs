using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInfo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.InverseTransformDirection(new Vector3(50,0,30)));
    }
}
