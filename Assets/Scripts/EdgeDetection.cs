using UnityEngine;
using System.Collections;

public class EdgeDetection : MonoBehaviour {

    public Texture srcTexture;
    public ComputeShader cs;

    private RenderTexture destTexture;

    // Use this for initialization
    void Start () {

        destTexture = new RenderTexture( srcTexture.width, srcTexture.height, 0, RenderTextureFormat.ARGB32 );
        destTexture.enableRandomWrite = true;
        destTexture.Create();

    }

    // Update is called once per frame
    void Update () {

        if(!SystemInfo.supportsComputeShaders)
        {

            Debug.LogError("Compute Shader is not Support!!");
            return ;

        }

        cs.SetTexture(0, "srcTexture", srcTexture);
        cs.SetTexture(0, "Result", destTexture);

        cs.Dispatch(0, srcTexture.width/8,srcTexture.height/8,1);

        GetComponent<Renderer>().material.mainTexture = destTexture;

    }
}
