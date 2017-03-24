using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonopolyTileGUI : MonoBehaviour
{
    public GameObject gCurrentlyLookedatTile;
    private Transform tHighlighter;
    private GameObject gTileInfo;

    private void Start()
    {
        tHighlighter = transform.GetChild(0);
        gTileInfo = transform.GetChild(0).GetChild(0).gameObject;
    }

    private void Update()
    {
        Color cHighlighter = tHighlighter.GetComponent<UnityEngine.UI.Image>().color;

        if (gCurrentlyLookedatTile || EventSystem.current.IsPointerOverGameObject())
        {
            cHighlighter = new Color(1.0f, 1.0f, 1.0f, cHighlighter.a + Time.deltaTime);
        }
        else
        {
            cHighlighter = new Color(1.0f, 1.0f, 1.0f, cHighlighter.a - Time.deltaTime);
        }

        if (cHighlighter.a > 1.0f)
        {
            cHighlighter = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            gTileInfo.SetActive(true);
        }
        else if (cHighlighter.a < 0.0f)
            cHighlighter = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        else
            gTileInfo.SetActive(false);

        tHighlighter.GetComponent<UnityEngine.UI.Image>().color = cHighlighter;

        if (gCurrentlyLookedatTile)
        {
            Vector3 vTileScreenPos = Camera.main.WorldToScreenPoint(gCurrentlyLookedatTile.transform.position);
            vTileScreenPos.z = 0;
            tHighlighter.position = vTileScreenPos;
        }
    }
}
