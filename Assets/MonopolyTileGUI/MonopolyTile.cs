using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonopolyTile : MonoBehaviour
{
    public MonopolyTileGUI MonopolyTileGUI;

    private void OnMouseEnter()
    {
        MonopolyTileGUI.gCurrentlyLookedatTile = gameObject;
    }

    private void OnMouseExit()
    {
        if (MonopolyTileGUI.gCurrentlyLookedatTile == gameObject)
            MonopolyTileGUI.gCurrentlyLookedatTile = null;
    }
}
