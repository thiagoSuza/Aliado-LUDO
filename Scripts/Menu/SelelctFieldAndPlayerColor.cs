using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelelctFieldAndPlayerColor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] blueBackground;

    private void Start()
    {
        SetBlueBG();
    }

    public void SetBlueBG()
    {
        foreach (var item in blueBackground)
        {
            item.SetActive(false);
        }
        blueBackground[PlayerPrefs.GetInt("Material", 0)].SetActive(true);
    }


    public void SelectPlayerColor(int aux)
    {
        PlayerPrefs.SetInt("PlayerColor", aux);
        SceneManager.LoadScene(2);
    }

    public void SelectField(int aux)
    {
        PlayerPrefs.SetInt("Material", aux);
        foreach (var item in blueBackground)
        {
            item.SetActive(false);
        }
        blueBackground[aux].SetActive(true);
        
    }


}
