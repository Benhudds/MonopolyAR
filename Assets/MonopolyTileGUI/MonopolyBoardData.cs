using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MonopolyBoardData : MonoBehaviour
{
    public bool bLoadData = false;

    public string sDirectorytoDataFiles = "";

    public enum TileType
    {
        Property = 0,
        CommunityChest = 1,
        IncomeTax = 2,
        RailwayStation = 3,
        Chance = 4,
        Utility = 5,
        SuperTax = 6
    }

    [Serializable]
    public struct TileProperties
    {
        public string sName;
        public TileType eTileType;
        public int iRent;
        public int iRent1House;
        public int iRent2House;
        public int iRent3House;
        public int iRent4House;
        public int iRentHotel;
        public int iMortgage;
        public int iHouseCost;
        public int iHotelCost;
        public int iCost;
        public string sColour;
    }

    public TileProperties[] TilesProperties;

    private void OnDrawGizmos()
    {
        if (bLoadData)
        {
            bLoadData = false;
            LoadDataintoStruct();
        }
    }

    private void LoadDataintoStruct()
    {
        List<TileProperties> lTiles = new List<TileProperties>();
       
        foreach (string sFile in Directory.GetFiles(sDirectorytoDataFiles, "*.txt"))
        {
            string[] sFileDatas = File.ReadAllLines(sFile);

            for (int i = 1; i < sFileDatas.Length; i++)
            {
                string[] sDataParts = sFileDatas[i].Split(',');

                TileProperties tNewTile = new TileProperties();
                tNewTile.eTileType = (TileType)Int32.Parse(sDataParts[0]);
                tNewTile.sName = sDataParts[1];

                switch (tNewTile.eTileType)
                {
                    case TileType.Property:
                        try
                        {
                            tNewTile.iRent = int.Parse(sDataParts[2]);
                            tNewTile.iRent1House = int.Parse(sDataParts[3]);
                            tNewTile.iRent2House = int.Parse(sDataParts[4]);
                            tNewTile.iRent3House = int.Parse(sDataParts[5]);
                            tNewTile.iRent4House = int.Parse(sDataParts[6]);
                            tNewTile.iRentHotel = int.Parse(sDataParts[7]);
                            tNewTile.iMortgage = int.Parse(sDataParts[8]);
                            tNewTile.iHouseCost = int.Parse(sDataParts[9]);
                            tNewTile.iHotelCost = int.Parse(sDataParts[10]);
                            tNewTile.iCost = int.Parse(sDataParts[11]);
                            tNewTile.sColour = sDataParts[12];
                        }
                        catch {}
                        break;
                    case TileType.CommunityChest:
                        break;
                    case TileType.IncomeTax:
                        tNewTile.iCost = int.Parse(sDataParts[11]);
                        break;
                    case TileType.RailwayStation:
                        tNewTile.iCost = int.Parse(sDataParts[11]);
                        break;
                    case TileType.Chance:
                        break;
                    case TileType.Utility:
                        tNewTile.iCost = int.Parse(sDataParts[11]);
                        break;
                    case TileType.SuperTax:
                        tNewTile.iCost = int.Parse(sDataParts[11]);
                        break;
                    default:
                        break;
                }

                lTiles.Add(tNewTile);
            }
        }

        TilesProperties = lTiles.ToArray();
    }
}
