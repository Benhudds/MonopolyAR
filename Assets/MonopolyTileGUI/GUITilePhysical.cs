using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITilePhysical : MonoBehaviour
{
    public int iGameBoardIndex = 0;
    public GameObject gTileScreenspacePrefab;
    private GameObject gTileScreenspace;

    private void Start()
    {
        gTileScreenspace = (GameObject)Instantiate(gTileScreenspacePrefab, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("MonopolyTileGUI").transform);
        gTileScreenspace.GetComponent<GUITileScreenspace>().StartTile(iGameBoardIndex);
    }

    public void OnMouseEnter()
    {
        gTileScreenspace.GetComponent<GUITileScreenspace>().OnMouseEnterPhysicalTile();
    }

    public void OnMouseExit()
    {
        gTileScreenspace.GetComponent<GUITileScreenspace>().OnMouseExitPhysicalTile();
    }
}
