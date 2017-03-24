using UnityEngine;
using System.Collections;

[AddComponentMenu("Image Effects/Color Pattern Highlight")]
public class ColorPatternHighlight : MonoBehaviour {

	public PatternInfo[] patterns;

	private Material addMaterialP;
    private Material subMaterialP;
    private Material mulMaterialP;	
	//public Texture2D patText;

	public enum HighlightTypes
	{
		TextureAdditive = 0,
		TextureSubstractive = 1,
		TextureMultiply = 2		
	}

    [System.Serializable]
    public class PatternInfo
    {        
        public Color patternColor = Color.red;
        public float range = 0.1f;
        public float hueRange = 0.1f;

        public HighlightTypes highlightType;
        public Texture patternTexture;

        public bool autoTiling = true;  
        public Vector2 tiling;
        public Vector2 tilingShift;
        public float strength = 1;
        public float edgeSharpness = 1;
    }

    Material subMaterial
    {
        get
        {
            if (subMaterialP == null)
            {
                subMaterialP = new Material(Shader.Find("Hidden/ColorPatternHighlight_sub"));
            }
            return subMaterialP;
        }
    }

    Material addMaterial
    {
        get
        {
            if (addMaterialP == null)
            {
                addMaterialP = new Material(Shader.Find("Hidden/ColorPatternHighlight_add"));
            }
            return addMaterialP;
        }
    }

    Material mulMaterial
    {
        get
        {
            if (mulMaterialP == null)
            {
                mulMaterialP = new Material(Shader.Find("Hidden/ColorPatternHighlight_mul"));
            }
            return mulMaterialP;
        }
    }

	


	void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture) //sourceTexture is the source texture, destTexture is the final image that gets to the screen
	{
        RenderTexture src = sourceTexture;
        RenderTexture dst = null;
        Material material = null;
        for (int i = 0; i < patterns.Length; i++)
        {
            switch(patterns[i].highlightType)
            {
                case HighlightTypes.TextureSubstractive:
                    material = subMaterial;
                    break;
                case HighlightTypes.TextureAdditive:
                    material = addMaterial;
                    break;
                case HighlightTypes.TextureMultiply:
                    material = mulMaterial;
                    break;
            }

            material.SetTexture("_Pattern",patterns[i].patternTexture);
            material.SetColor("_PatCol",patterns[i].patternColor);
            material.SetFloat("_Range",patterns[i].range);
            material.SetFloat("_HueRange",patterns[i].hueRange);
            material.SetFloat("_Strength",patterns[i].strength);
            material.SetFloat("_edgeCoef",patterns[i].edgeSharpness);

            if (patterns[i].autoTiling)
            {
                material.SetFloat("_tilingX",(float)Screen.width / patterns[i].patternTexture.width);
                material.SetFloat("_tilingY",(float)Screen.height / patterns[i].patternTexture.height); 
            }
            else
            {
                material.SetFloat("_tilingX",patterns[i].tiling.x);
                material.SetFloat("_tilingY",patterns[i].tiling.y); 
            }
            material.SetFloat("_tilingShiftX",patterns[i].tilingShift.x);
            material.SetFloat("_tilingShiftY",patterns[i].tilingShift.y);



            if (i == patterns.Length-1)
                dst = destTexture;
            else
            {                
                dst = RenderTexture.GetTemporary(src.width,src.height,0,RenderTextureFormat.ARGB32,RenderTextureReadWrite.Linear);
            }

            Graphics.Blit(src, dst, material);

            if (i > 0)
                RenderTexture.ReleaseTemporary(src);            
            src = dst;            
        }
	}



	// Use this for initialization
	void Start () 
	{
		//SetTexture();
	}

	void OnDisable ()
	{
        //Destroys materials when not used so it won't cause leaks
        if(subMaterialP != null)
		{
            DestroyImmediate(subMaterialP);	
        }
        if(addMaterialP != null)
        {
            DestroyImmediate(subMaterialP); 
        }
        if(mulMaterialP != null)
        {
            DestroyImmediate(subMaterialP); 
        }
	}
}
