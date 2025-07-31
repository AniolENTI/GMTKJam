using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour
{
    public UnityEngine.Material screenMaterial;
    public UnityEngine.Texture texture1;
    public UnityEngine.Texture texture2;

    // Start is called before the first frame update
    void Start()
    {
        screenMaterial.SetTexture("_MainTex", texture1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(screenMaterial.GetTexture("_MainTex") == texture1)
                screenMaterial.SetTexture("_MainTex", texture2);
            else
                screenMaterial.SetTexture("_MainTex", texture1);
        }
    }
}
