using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int StartingPlayerHealthPts = 6;
    public int PlayerHealthTeam1Pts;
    public int PlayerHealthTeam2Pts;

    public bool DeathSoud;

    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealthTeam1Pts = StartingPlayerHealthPts;
        PlayerHealthTeam2Pts = StartingPlayerHealthPts;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealthTeam1Pts <= 0)
        {
            Debug.Log("Team 2 wins");
            DeathSoud = true;
        }

        if (PlayerHealthTeam2Pts <= 0)
        {
            Debug.Log("Team 1 wins");
            DeathSoud = true;
        }

        if (DeathSoud)
        {
            GetComponent<AudioSource>().PlayOneShot(deathSound);
            DeathSoud = false;
        }
    }
}
