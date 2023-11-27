using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterial : MonoBehaviour
{
    [SerializeField]
    private Material[] material;
    private int index;

    private void Awake()
    {
        index = PlayerPrefs.GetInt("Material", 0);
        SetMaterialInGame();
    }

    public void SetMaterialInGame()
    {
        // Obtém o componente Renderer do objeto
        var renderer = gameObject.GetComponent<Renderer>();

        
        renderer.sharedMaterial = material[index];
    }
}
