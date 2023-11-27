using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private PlayerRow[] pr;

    [SerializeField]
    private int parcialOne, parcialTwo;
    [SerializeField]
    private Dice d1, d2;

    public bool firstDrop;
    public bool isPlayerTurn;

    [SerializeField]
    private int colorTurn = 0;
    private int Playercolor;

    [SerializeField]
    private Button rollDice;

    [SerializeField]
    private Text rowText;

    public int ready;

    [SerializeField]
    private GameObject[] skuls;

    [SerializeField]
    private Text finalText;

    [SerializeField]
    private GameObject finalPanel;

    [SerializeField]
    private GameObject[] sinalizations;

    

    private void Awake()
    {
        Instance = this;
        GetPlayerCOlor();

    }

    // Start is called before the first frame update
    void Start()
    {
        rollDice.interactable = false;
        firstDrop = true;
        SetTurn();
        ready = 0;
        Time.timeScale = 1;
    }


    

    public void GetPlayerCOlor()
    {
        Playercolor = PlayerPrefs.GetInt("PlayerColor", 0);
    }


    public void DiceSoma(int aux,string auxN)
    {

        if(auxN == "DadoTwo")
        {
            parcialTwo = aux;
        }

        if(auxN == "DadoOne")
        {
            parcialOne = aux;
        }

        

        if (ready >= 2 && parcialOne != 0 && parcialTwo !=0)
        {
            
            SetDesignedPlayerRow();
            ready = 0;
            parcialOne = 0;
            parcialTwo= 0;
        }
    }

    public void RollDice()
    {
        d1.SetRollDice();
        d2.SetRollDice();
        rollDice.interactable = false;

    }


    public void SetDesignedPlayerRow()
    {
       

        if (colorTurn == 0)
        {
            
            pr[0].CheckDiceResult(parcialOne, parcialTwo);
            
        }
         if (colorTurn == 1)
        {
            
            pr[1].CheckDiceResult(parcialOne, parcialTwo);
            

        }
         if (colorTurn == 2)
        {
            
            pr[2].CheckDiceResult(parcialOne, parcialTwo);
            
        }
         if (colorTurn == 3)
        {
            
            pr[3].CheckDiceResult(parcialOne, parcialTwo);
        }
    }

    public void SetText()
    {
        foreach (GameObject go in sinalizations)
        {
            go.SetActive(false);
        }

        if (colorTurn == 0)
        {
            sinalizations[0].SetActive(true);
            rowText.text = "Vez do Azul";
        }
        else if (colorTurn == 1)
        {
            sinalizations[1].SetActive(true);
            rowText.text = "Vez do Vermelhor";
        }
        else if (colorTurn == 2)
        {
            sinalizations[2].SetActive(true);
            rowText.text = "Vez do Preto";
        }
        else if (colorTurn == 3)
        {
            sinalizations[3].SetActive(true);
            rowText.text = "Vez do Verde";
        }
    }

    public void SetTurn()
    {
        SetText();
        if (colorTurn == Playercolor)
        {
            isPlayerTurn = true;
            rollDice.interactable = true;
            rowText.text = "SUA VEZ";
        }
        else
        {
            isPlayerTurn = false;
            RollDice();
        }

       
    }

    public void NextTurn()
    {
        foreach(GameObject p in skuls)
        {
            p.GetComponent<SkullTrap>().SetActiveBox();
        }
        colorTurn++;
        if(colorTurn > 3) 
        {
            colorTurn = 0;
        }

        SetText();

        if (colorTurn == Playercolor)
        {
            isPlayerTurn = true;
            rollDice.interactable = true;
            rowText.text = "SUA VEZ";
        }
        else
        {
            isPlayerTurn = false;
            RollDice();
        }

        
    }

    public void PlayAgain()
    {
        if (colorTurn == Playercolor)
        {
            isPlayerTurn = true;
            rollDice.interactable = true;
            rowText.text = "SUA VEZ";
        }
        else
        {
            isPlayerTurn = false;
            RollDice();
        }
    }

   
    public void FinishGame(string aux)
    {
        finalPanel.SetActive(true);
        Time.timeScale = 0f;
        finalText.text = aux;
    }

    


}
