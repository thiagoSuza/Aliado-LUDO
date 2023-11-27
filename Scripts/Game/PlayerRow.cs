using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerRow : MonoBehaviour
{
    [SerializeField]
    private GameObject piece1, piece2, piece3, piece4;

    [SerializeField]
    private List<GameObject> waiting = new List<GameObject>();
    [SerializeField]
    private List<GameObject> inPlay = new List<GameObject>();
   

    [SerializeField]
    private int d1, d2;
    public int soma;

   
    private bool playAgain;  

    [SerializeField]
    private string colorName;
      

    [SerializeField]
    private bool checkFinal;

    private int endPointAmount;

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetInWaitingList();
        playAgain = false;
        checkFinal = false;
    }

    public void SetInWaitingList()
    {
        waiting.Add(piece1);
        waiting.Add(piece2);
        waiting.Add(piece3);
        waiting.Add(piece4);
    }

    public void CheckDiceResult(int aux1, int aux2)
    {
        d1 = aux1;
        d2 = aux2;
        soma = d1 + d2;
        if(soma ==12 || soma == 2)
        {
            playAgain = true;
        }

      /*  if (soma == 2)
        {
            SetPlayList();
        }*/

        if (inPlay.Count != 0)
        {
            MoveSelectedPiece();
        }
        else
        {
            StartCoroutine("Timer");
        }

      

        if (d1 == 6|| d2 == 6 || soma ==2)
        {
            SetPlayList();
            KillerAction();
        }

          
               


    }

    public int SplitResult()
    {
        counter++;
        if(counter == 1)
        {
            return d1;

        }
        if(counter == 2)
        {
            counter = 0;
            StartCoroutine("Timer");
            return d2;
            

        }
        return 0;

    }
    public void MoveSelectedPiece()
    {
        if (GameManager.Instance.isPlayerTurn)
        {
            foreach(var go in inPlay)
            {
                go.GetComponent<PlayerMovement>().selector.SetActive(true);
            }
        }
        else
        {
            int x = Random.Range(0, inPlay.Count);
            if (!checkFinal)
            {
                inPlay[x].GetComponent<PlayerMovement>().Move(soma);
            }
            else
            {
                inPlay[x].GetComponent<PlayerMovement>().Move(d1);
                
            }
            StartCoroutine("Timer");
        }
    }


    public void DesactiveSelector()
    {
        foreach (var go in inPlay)
        {
            go.GetComponent<PlayerMovement>().selector.SetActive(false);
        }
        StartCoroutine("Timer");
    }

    public void CheckFinal()
    {
        if(piece1.GetComponent<PlayerMovement>().inFinal == true && piece2.GetComponent<PlayerMovement>().inFinal == true && piece3.GetComponent<PlayerMovement>().inFinal == true && piece4.GetComponent<PlayerMovement>().inFinal == true)
        {
            checkFinal = true;
        }
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(8f);
        EndTurn();
    }
 
    

    public void EndTurn()
    {
        if (!playAgain)
        {
            GameManager.Instance.NextTurn();
        }
        else
        {
            GameManager.Instance.PlayAgain();
            playAgain = false;
        }
        KillerAction();


    }

    public void SetPlayList()
    {
        if (waiting.Count > 0)
        {
            int x = Random.Range(0, waiting.Count);
            GameObject pc = waiting[x];
            inPlay.Add(pc);
            waiting.RemoveAt(x);
            pc.GetComponent<PlayerMovement>().SetInitialMove();


        }

        if (GameManager.Instance.firstDrop == true && waiting.Count > 0)
        {
            int x = Random.Range(0, waiting.Count);
            GameObject pc = waiting[x];
            inPlay.Add(pc);
            waiting.RemoveAt(x);
            pc.GetComponent<PlayerMovement>().SetInitialMove();

            GameManager.Instance.firstDrop = false;
        }
    }

    public void SetFinished(GameObject obj,int aux)
    {
        inPlay.Remove(obj);
        endPointAmount += aux;

        if(endPointAmount >= 4) 
        {
            GameManager.Instance.FinishGame(colorName);

        }

           
        
    }

    public void KillerAction()
    {
        foreach (var p in inPlay)
        {
            p.GetComponent<PlayerMovement>().ActiverKiller();

        }
    }

    

    public void RemoveFromInPlayList(GameObject aux)
    {
        inPlay.Remove(aux);
    }
    public void ResetInWaitList(GameObject aux)
    {
        waiting.Add(aux);
    }    
    
}
