﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUITileScreenspace : MonoBehaviour
{
    public bool bScreenspaceTileHovered;
    public bool bPhysicalTileHovered;
    public Vector3 vPhysicalTilePos;
    public float fAnimationSpeed = 1.0f;
    public bool bHighContrast = false;

    private bool bHighContrastTrig = false;
    public int iAnimationState = 0;
    public float fAnimationPos = 0.0f;
    RectTransform rTileRect;
    Image iTileImage;
    CanvasGroup cTileContent;
    public Color cTileColour;

    Image iTileTitleBar;
    Image iTileFooterBar;
    Text tTileTitleText;
    Text tTileTitleSubText;

    Text tRent;
    Text tColourSet;
    Text tHouse1;
    Text tHouse2;
    Text tHouse3;
    Text tHouse4;
    Text tHotel;
    Text tHouseCost;
    Text tHotelCost;

    Color cBrown = new Color(0.615f, 0.388f, 0.003f);
    Color cDarkBlue = new Color(0.078f, 0.278f, 0.721f);
    Color cGreen = new Color(0.0f, 1.0f, 0.0f);
    Color cLightBlue = new Color(0.313f, 0.784f, 0.886f);
    Color cOrange = new Color(0.984f, 0.639f, 0.035f);
    Color cPink = new Color(0.937f, 0.043f, 0.741f);
    Color cRed = new Color(1.0f,0.0f,0.0f);
    Color cStation = new Color(1.0f,1.0f,1.0f);
    Color cUtility = new Color(1.0f, 1.0f, 1.0f);
    Color cYellow = new Color(0.937f, 0.933f, 0.043f);

    public void StartTile(int Index)
    {
        rTileRect = GetComponent<RectTransform>();
        iTileImage = GetComponent<Image>();
        cTileContent = transform.GetChild(0).GetComponent<CanvasGroup>();

        rTileRect.sizeDelta = new Vector2(40, 40);
        iTileImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        cTileContent.alpha = 0.0f;

        iTileTitleBar = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        iTileFooterBar = transform.GetChild(0).GetChild(2).GetComponent<Image>();
        tTileTitleText = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
        tTileTitleSubText = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>();

        tRent = transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>();
        tColourSet = transform.GetChild(0).GetChild(1).GetChild(3).GetComponent<Text>();
        tHouse1 = transform.GetChild(0).GetChild(1).GetChild(4).GetComponent<Text>();
        tHouse2 = transform.GetChild(0).GetChild(1).GetChild(5).GetComponent<Text>();
        tHouse3 = transform.GetChild(0).GetChild(1).GetChild(7).GetComponent<Text>();
        tHouse4 = transform.GetChild(0).GetChild(1).GetChild(6).GetComponent<Text>();
        tHotel = transform.GetChild(0).GetChild(1).GetChild(9).GetComponent<Text>();

        tHouseCost = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
        tHotelCost = transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Text>();

        //Populate me
        MonopolyBoardData boarddata = GameObject.Find("MonopolyTileGUI").GetComponent<MonopolyBoardData>();
        MonopolyBoardData.TileProperties thistile = boarddata.TilesProperties[Index];

        tTileTitleText.text = thistile.sName;
        tTileTitleSubText.text = "(" + thistile.sColour + ")";

        tRent.text = thistile.iRent.ToString();
        tColourSet.text = (thistile.iRent * 2).ToString();
        tHouse1.text = thistile.iRent1House.ToString();
        tHouse2.text = thistile.iRent2House.ToString();
        tHouse3.text = thistile.iRent3House.ToString();
        tHouse4.text = thistile.iRent4House.ToString();
        tHotel.text = thistile.iRentHotel.ToString();

        tHouseCost.text = "House\n" + thistile.iHouseCost.ToString();
        tHotelCost.text = "Hotel\n" + thistile.iHotelCost.ToString();

        switch (thistile.eTileType)
        {
            case MonopolyBoardData.TileType.Property:
                switch (thistile.sColour)
                {
                    case "Brown":
                        iTileTitleBar.color = cBrown;
                        break;
                    case "Red":
                        iTileTitleBar.color = cRed;
                        break;
                    case "LightBlue":
                        iTileTitleBar.color = cLightBlue;
                        break;
                    case "DarkBlue":
                        iTileTitleBar.color = cDarkBlue;
                        break;
                    case "Orange":
                        iTileTitleBar.color = cOrange;
                        break;
                    case "Pink":
                        iTileTitleBar.color = cPink;
                        break;
                    case "Green":
                        iTileTitleBar.color = cGreen;
                        break;
                    case "Yellow":
                        iTileTitleBar.color = cYellow;
                        break;
                    default:
                        iTileTitleBar.color = cStation;
                        break;
                }
                break;
            case MonopolyBoardData.TileType.Utility:
                iTileTitleBar.color = cUtility;
                break;
            default:
                iTileTitleBar.color = cStation;
                break;
        }

        
    }

    private void Update()
    {
        AnimateFrame();

        if (bHighContrast != bHighContrastTrig)
        {
            bHighContrastTrig = bHighContrast;
            ContrastModeToggled();
        }
    }

    private void ContrastModeToggled()
    {
        if (bHighContrast)
        {
            iTileFooterBar.color = Color.white;
            iTileTitleBar.color = Color.black;
            tTileTitleText.color = Color.white;
            tTileTitleSubText.color = Color.white;
        }
        else
        {
            iTileFooterBar.color = new Color32(210, 210, 210, 255);
            iTileTitleBar.color = cTileColour;
            tTileTitleText.color = Color.black;
            tTileTitleSubText.color = Color.black;
        }
    }

    private void AnimateFrame()
    {
        if (iTileImage == null)
        {
            return;
        }


        if (bPhysicalTileHovered || bScreenspaceTileHovered)
            fAnimationPos += Time.deltaTime * fAnimationSpeed;
        else
            fAnimationPos -= Time.deltaTime * fAnimationSpeed;

        if (iAnimationState == 0)
        {
            iTileImage.color = new Color(1.0f,1.0f,1.0f, Mathf.Lerp(0.0f, 1.0f, fAnimationPos));

            if (fAnimationPos > 1.0f)
            {
                iAnimationState++;
                fAnimationPos = 0.0f;
            }
            else if (fAnimationPos < 0.0f)
                fAnimationPos = 0.0f;
        }
        else if (iAnimationState == 1)
        {
            rTileRect.sizeDelta = new Vector2(Mathf.Lerp(40, 150, fAnimationPos), Mathf.Lerp(40, 250, fAnimationPos));

            if (fAnimationPos > 1.0f)
            {
                fAnimationPos = 0.0f;
                iAnimationState++;
            }
            else if (fAnimationPos < 0.0f)
            {
                fAnimationPos = 1.0f;
                iAnimationState--;
            }
        }
        else if (iAnimationState == 2)
        {
            cTileContent.alpha = fAnimationPos;

            if (fAnimationPos > 1.0f)
            {
                fAnimationPos = 1.0f;
            }
            else if (fAnimationPos < 0.0f)
            {
                fAnimationPos = 1.0f;
                iAnimationState--;
            }
        }
    }

    public void OnMouseEnterTile()
    {
        bScreenspaceTileHovered = true;
    }

    public void OnMouseExitTile()
    {
        bScreenspaceTileHovered = false;
    }

    public void OnMouseEnterPhysicalTile()
    {
        bPhysicalTileHovered = true;
    }

    public void OnMouseExitPhysicalTile()
    {
        bPhysicalTileHovered = false;
    }
}
