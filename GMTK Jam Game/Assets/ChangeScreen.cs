using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour
{
    public UnityEngine.Material screenMaterial;
    public UnityEngine.Texture baseImage;
    public UnityEngine.Texture[] alteredImageArray;

    // Start is called before the first frame update
    void Start()
    {
        screenMaterial.SetTexture("_MainTex", baseImage);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(screenMaterial.GetTexture("_MainTex") == baseImage)
            {
                UnityEngine.Texture auxTexture;
                int auxLength = alteredImageArray.Length;
                auxTexture = alteredImageArray[Random.Range(0, auxLength)];
                screenMaterial.SetTexture("_MainTex", auxTexture);
            }
                
            else
                screenMaterial.SetTexture("_MainTex", baseImage);
        }
    }
}
