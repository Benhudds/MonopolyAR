using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class GazeHighlighter 
    {
        public LayerMask lPhysicsMask;
        private readonly List<Renderer> tHighlighted = new List<Renderer>();
        private readonly List<GUITilePhysical> tPhyTiles = new List<GUITilePhysical>();
        private const float timer = 9;
        private float timeLeft = timer;
        private int hitId;

        public GazeHighlighter(LayerMask mask)
        {
            lPhysicsMask = mask;
        }

        public void GazeTracking(Transform transform)
        {
            tHighlighted.ForEach(t => t.enabled = false);

            RaycastHit rhit;
            if (Physics.Raycast(new Ray(transform.position, transform.forward), out rhit, lPhysicsMask, 1000))
            {

                if (hitId != rhit.transform.GetInstanceID())
                {
                    timeLeft = timer;
                    tHighlighted.ForEach(t => t.material.color = Color.yellow);
                    hitId = rhit.transform.GetInstanceID();

                    tPhyTiles.ForEach(t => t.OnMouseExit());
                    tPhyTiles.Clear();
                }

                foreach (var childRenderer in rhit.transform.GetComponentsInChildren<MeshRenderer>())
                {

                    childRenderer.enabled = true;
                    tHighlighted.Add(childRenderer);
                    timeLeft -= Time.deltaTime;
                }

                if (timeLeft <= 0)
                {
                    // Do stuff. This is where we would launch the other scene

                    // TEST CODE
                    tHighlighted.ForEach(t => t.material.color = Color.cyan);

                    tPhyTiles.ForEach(t => t.OnMouseExit());
                    tPhyTiles.Clear();

                    foreach (var tile in rhit.transform.GetComponentsInParent<GUITilePhysical>())
                    {
                        tPhyTiles.Add(tile);
                        tile.OnMouseEnter();
                    }
                }
            }
            else
            {
                timeLeft = timer;
                tHighlighted.ForEach(t => t.material.color = Color.yellow);
                tHighlighted.Clear();

                tPhyTiles.ForEach(t => t.OnMouseExit());
                tPhyTiles.Clear();
            }
        }
    }
}
