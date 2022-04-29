using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int StartingPlayerHealthPts = 6;
    public int PlayerHealthTeam1Pts;
    public int PlayerHealthTeam2Pts;

    public bool DeathSoud;

    public AudioClip deathSound;

    public GameObject EndGameCam;
    public GameObject EndMessage;
    public GameObject GameHUD;
    public TextMeshProUGUI EndGameWinMessage;
    public Camera CamDepth;


    // Start is called before the first frame update
    void Start()
    {
        PlayerHealthTeam1Pts = StartingPlayerHealthPts;
        PlayerHealthTeam2Pts = StartingPlayerHealthPts;

        EndGameWinMessage = EndMessage.GetComponentInChildren<TextMeshProUGUI>();

        CamDepth = EndGameCam.GetComponent<Camera>();
        CamDepth.depth = -1;

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealthTeam1Pts <= 0)
        {
            //Debug.Log("Team 2 wins");
            //DeathSoud = true;

            //EndGameCam.SetActive(true);
            EndMessage.SetActive(true);
            GameHUD.SetActive(false);

            CamDepth.depth = 1;

            EndGameWinMessage.text = ("BLUE TEAM WINS");
            EndGameWinMessage.color = Color.blue;

        }

        if (PlayerHealthTeam2Pts <= 0)
        {
            //Debug.Log("Team 1 wins");
           // EndGameCam.SetActive(true);
            EndMessage.SetActive(true);
            GameHUD.SetActive(false);

            CamDepth.depth = 1;

            EndGameWinMessage.text = ("RED TEAM WINS");
            EndGameWinMessage.color = Color.red;
            //DeathSoud = true;
        }

        //if (DeathSoud)
        //{
        //    GetComponent<AudioSource>().PlayOneShot(deathSound);
        //    DeathSoud = false;
        //}
    }
}
