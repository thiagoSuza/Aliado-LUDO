using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Load", 4f);
    }

    public void Load()
    {
        SceneManager.LoadScene(1);
    }
}
