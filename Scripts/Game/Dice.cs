using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    [SerializeField]
    private Text diceTxt;

     private Rigidbody rb;
    private bool isRolling = true;
 
    [SerializeField]
    private GameObject[] faces;

    private bool locked;
    [SerializeField]
    private Transform hight;

    public string _name;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        locked = true;
    }

    void Update()
    {
        if (!isRolling )
        {
            RollDice();
        }

        if (!locked && rb.IsSleeping()) 
        {
            CheckResult();
            locked = true;
            isRolling = true;
        }
    }

    public void SetRollDice()
    {
        transform.position = hight.position;

        isRolling = false;
        
    }

    void RollDice()
    {
        isRolling = true;
        locked = false;
        rb.velocity = Vector3.zero; // Define a velocidade inicial como zero
        rb.angularVelocity = Random.insideUnitSphere * 10f; // Adiciona uma velocidade angular aleatória

        float randomForce = Random.Range(45f, 60f); // Força aleatória para simular o lançamento do dado
        rb.AddForce(Vector3.up * randomForce, ForceMode.Impulse); // Adiciona uma força de impulso para simular o lançamento do dado

       
    }

    void CheckResult()
    {
       foreach (var face in faces) 
        {
           
            face.SetActive(true);
          
       }     

    }

    public void SetResult(int aux)
    {
        
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero; ;
        diceTxt.text = aux.ToString();
        GameManager.Instance.ready++;
        GameManager.Instance.DiceSoma(aux,_name);
        

    }
}

