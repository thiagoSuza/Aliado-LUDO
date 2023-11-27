using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] waypoints;   

    public int currentPos;

    public int randomNumber,aux;

    public bool isMove;

    
    private Vector3 initialPos;
    

    private bool initialMove;
    private bool isPlayable;

    public bool inFinal;

    
    public GameObject selector;

    private int final;

    [SerializeField]
    Transform winPosition;

    public int value;

    [SerializeField]
    private GameObject[] visualIndex;

    public GameObject killer;

    public int id;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = 0;
        isMove = false;
        isPlayable = false;
        initialMove = false;
        initialPos = transform.position;
        value = 1;
        inFinal = false;
        final = waypoints.Length - 1;
        UpPiece(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove && isPlayable)
        {
            ActionMove();
        }

              


        if (initialMove)
        {
            MoveTowards(waypoints[0], 3);
            SetPieceOnPlay();
        }

    }

    public void SetInitialMove()
    {
        initialMove = true;
    }


   

    public  void Move(int soma)
    {
        randomNumber = soma;
        aux = currentPos + randomNumber;
        isMove = true;
        if(currentPos >= final-5)
        {
            inFinal = true;
        }

    }
    public void Move2()
    {
        randomNumber = GetComponentInParent<PlayerRow>().SplitResult();
        aux = currentPos + randomNumber;
        isMove = true;
        if (currentPos >= final - 5)
        {
            inFinal = true;
        }

    }

    public void ActionMove()
    {
        
        
        if (currentPos !=final)
        {
            if (Vector3.Distance(transform.position, waypoints[currentPos].position) < 2 && currentPos < aux)
            {
                currentPos++;
            }



            // Move o objeto para o próximo ponto de caminho.
            if (currentPos <= waypoints.Length)
            {
                if (aux > waypoints.Length)
                {
                    aux = waypoints.Length;
                }

                MoveTowards(waypoints[currentPos], 3);
            }
        }
        else
        {
            MoveTowards(winPosition, 3);
        }

        
        
        
    }

    void MoveTowards(Transform target, float speed)
    {
        // Calcula a direção entre o objeto atual e o ponto de destino.
        Vector3 direction = target.position - transform.position;

        // Move o objeto nessa direção.
       transform.position += direction * speed * Time.deltaTime;
    }


    public void ResetPos()
    {
        currentPos = 0;
        aux = 0;
        isMove = false;
        isPlayable =true;
        transform.position = initialPos;
        inFinal = false;
    }


    public void KillPos()
    {
        currentPos = 0;
        aux = 0;
        isMove = false;
        isPlayable = false;
        transform.position = initialPos;
        inFinal = false;
        GetComponentInParent<PlayerRow>().RemoveFromInPlayList(gameObject);
        GetComponentInParent<PlayerRow>().ResetInWaitList(gameObject);

    }

    public void SetPieceOnPlay()
    {
        if (Vector3.Distance(transform.position, waypoints[0].position) < 2 )
        {
            initialMove = false;
            isPlayable = true;

        }
    }                 
               
           
                   
            
    public void SetFinal()
    {
        isPlayable = false;
        GetComponentInParent<PlayerRow>().SetFinished(gameObject,value);

    }

    public void UpPiece(int aux)
    {
        value += aux;
        foreach(GameObject go in visualIndex)
        {
            go.SetActive(false);
        }
        if(value == 1)
        {
            visualIndex[0].SetActive(true);
        }
        else if(value == 2) 
        {
            visualIndex[1].SetActive(true);
        }
        else if (value == 3)
        {
            visualIndex[2].SetActive(true);
        }
        else if (value == 4)
        {
            visualIndex[3].SetActive(true);
        }

    }

    public void DesactivePiece()
    {
        GetComponentInParent<PlayerRow>().RemoveFromInPlayList(gameObject);
        gameObject.SetActive(false);
    }


    public void ActiverKiller()
    {
        StartCoroutine(Ktimer());
    }

    IEnumerator Ktimer()
    {
        killer.SetActive(true);
        yield return new WaitForSeconds(3f);
        killer.SetActive(false);

    }
    
}


  

