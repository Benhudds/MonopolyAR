using UnityEngine;
using UnityEngine.UI;

public class GUITileScreenspace : MonoBehaviour
{
    public bool bHighContrast = Settings.BalanceCounting;

    private bool bHighContrastTrig;
    public bool bPhysicalTileHovered;
    public bool bScreenspaceTileHovered;

    private readonly Color cBrown = new Color(0.615f, 0.388f, 0.003f);
    private readonly Color cDarkBlue = new Color(0.078f, 0.278f, 0.721f);
    private readonly Color cGreen = new Color(0.0f, 1.0f, 0.0f);
    //private readonly Color cLightBlue = new Color(0.313f, 0.784f, 0.886f);
    private readonly Color cLightBlue = new Color(0.6f, 0.96f, 0.98f);
    private readonly Color cOrange = new Color(0.984f, 0.639f, 0.035f);
    private readonly Color cPink = new Color(0.937f, 0.043f, 0.741f);
    private readonly Color cRed = new Color(1.0f, 0.0f, 0.0f);
    private readonly Color cStation = new Color(1.0f, 1.0f, 1.0f);
    public Color cTileColour;
    private CanvasGroup cTileContent;
    private readonly Color cUtility = new Color(1.0f, 1.0f, 1.0f);
    private readonly Color cYellow = new Color(0.937f, 0.933f, 0.043f);
    public float fAnimationPos;
    public float fAnimationSpeed = 1.0f;
    public int iAnimationState;
    private Image iTileFooterBar;
    private Image iTileImage;

    private Image iTileTitleBar;
    private RectTransform rTileRect;
    private Text tColourSet;
    private Text tHotel;
    private Text tHotelCost;
    private Text tHouse1;
    private Text tHouse2;
    private Text tHouse3;
    private Text tHouse4;
    private Text tHouseCost;

    private Text tRent;
    private Text tTileTitleSubText;
    private Text tTileTitleText;
    public Vector3 vPhysicalTilePos;

    public void StartTile(int index)
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
        var boarddata = GameObject.Find("MonopolyTileGUI").GetComponent<MonopolyBoardData>();
        var thistile = boarddata.TilesProperties[index];

        tTileTitleText.text = thistile.sName;

        tRent.text = thistile.iCost.ToString();
        tColourSet.text = (thistile.iRent).ToString();
        tHouse1.text = thistile.iRent1House.ToString();
        tHouse2.text = thistile.iRent2House.ToString();
        tHouse3.text = thistile.iRent3House.ToString();
        tHouse4.text = thistile.iRent4House.ToString();
        tHotel.text = thistile.iRentHotel.ToString();

        tHouseCost.text = "House\n" + thistile.iHouseCost;
        tHotelCost.text = "Hotel\n" + thistile.iHotelCost;

        iTileTitleBar.color = cStation;
        switch (thistile.eTileType)
        {
            case MonopolyBoardData.TileType.Property:
                tTileTitleSubText.text = "(" + thistile.sColour + ")";
                transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(7).gameObject.SetActive(false);
                switch (thistile.sColour)
                {
                    case "Brown":
                        iTileTitleBar.color = cBrown;
                        break;
                    case "Red":
                        iTileTitleBar.color = cRed;
                        break;
                    case "Light Blue":
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
                }
                break;
            case MonopolyBoardData.TileType.CommunityChest:
                tTileTitleSubText.text = "";
                transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(7).gameObject.SetActive(false);
                break;
            case MonopolyBoardData.TileType.Chance:
                tTileTitleSubText.text = "";
                transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(7).gameObject.SetActive(false);
                break;
            case MonopolyBoardData.TileType.RailwayStation:
                tTileTitleSubText.text = "(RailwayStation)";
                iTileTitleBar.color = cStation;
                transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(5).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(7).gameObject.SetActive(false);
                break;
            case MonopolyBoardData.TileType.Utility:
                tTileTitleSubText.text = "(Utility)";
                transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(6).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(7).gameObject.SetActive(false);
                iTileTitleBar.color = cUtility;
                break;
            case MonopolyBoardData.TileType.IncomeTax:
            case MonopolyBoardData.TileType.SuperTax:
                tTileTitleSubText.text = "";
                transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
                break;
        }
    }

    private void Update()
    {
        AnimateFrame();

        if (Settings.ColourCorrection)
        {
            ContrastModeToggled();
        }
    }

    private void ContrastModeToggled()
    {
        iTileFooterBar.color = Color.white;
        iTileTitleBar.color = Color.black;
        tTileTitleText.color = Color.white;
        tTileTitleSubText.color = Color.white;
    }

    private void AnimateFrame()
    {
        if (iTileImage == null)
            return;


        if (bPhysicalTileHovered || bScreenspaceTileHovered)
            fAnimationPos += Time.deltaTime * fAnimationSpeed;
        else
            fAnimationPos -= Time.deltaTime * fAnimationSpeed;

        if (iAnimationState == 0)
        {
            iTileImage.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(0.0f, 1.0f, fAnimationPos));

            if (fAnimationPos > 1.0f)
            {
                iAnimationState++;
                fAnimationPos = 0.0f;
            }
            else if (fAnimationPos < 0.0f)
            {
                fAnimationPos = 0.0f;
            }
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