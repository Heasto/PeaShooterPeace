using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUpdate : MonoBehaviour
{
    public GameManager GameManagerScript;
    public GameObject MyGameManager;

    // Start is called before the first frame update
    void Start()
    {
        MyGameManager = GameObject.FindGameObjectWithTag("GameManager");
        GameManagerScript = MyGameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
