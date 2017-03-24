using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class TouchHighlighter
    {
        public LayerMask lPhysicsMask;
        private readonly List<GUITilePhysical> tPhyTiles = new List<GUITilePhysical>();

        public TouchHighlighter(LayerMask mask)
        {
            lPhysicsMask = mask;
        }

        public void TouchTracking(Transform transform)
        {
            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    // Construct a ray from the current touch coordinates
                    var ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit rhit;
                    if (Physics.Raycast(ray, out rhit, lPhysicsMask, 1000))
                    {
                        //foreach (var childRenderer in rhit.transform.GetComponentsInChildren<MeshRenderer>())
                        //{
                        //    childRenderer.enabled = !childRenderer.enabled;
                        //}

                        tPhyTiles.ForEach(t => t.OnMouseExit());
                        tPhyTiles.Clear();

                        foreach (var tile in rhit.transform.GetComponentsInParent<GUITilePhysical>())
                        {
                            tile.OnMouseEnter();
                            tPhyTiles.Add(tile);
                        }
                    }
                    else
                    {
                        tPhyTiles.ForEach(t => t.OnMouseExit());
                        tPhyTiles.Clear();
                    }
                }
            }
        }

    }
}
