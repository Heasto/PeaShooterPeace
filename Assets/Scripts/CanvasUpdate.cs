using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUpdate : MonoBehaviour
{
    public GameManager GameManagerScript;
    private GameObject MyGameManager;

    public TextMeshProUGUI LivesNbrTeam1;
    public TextMeshProUGUI LivesNbrTeam2;

    private TextMeshProUGUI TeamLives1;
    private TextMeshProUGUI TeamLives2;

    // Start is called before the first frame update
    void Start()
    {
        MyGameManager = GameObject.FindGameObjectWithTag("GameManager");
        GameManagerScript = MyGameManager.GetComponent<GameManager>();

        TeamLives1 = LivesNbrTeam1.GetComponent<TextMeshProUGUI>();
        TeamLives2 = LivesNbrTeam2.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameManagerScript.PlayerHealthTeam1Pts >= 0) || (GameManagerScript.PlayerHealthTeam2Pts >= 0)) 
        {
            TeamLives1.text = GameManagerScript.PlayerHealthTeam1Pts.ToString();
            TeamLives2.text = GameManagerScript.PlayerHealthTeam2Pts.ToString();
        }
    }
}
