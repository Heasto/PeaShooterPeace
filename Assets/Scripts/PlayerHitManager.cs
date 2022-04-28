using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHitManager : MonoBehaviour
{
    public int StartingPlayerHealthPts = 6;
    public int PlayerHealthTeam1Pts;
    public int PlayerHealthTeam2Pts;

    public Material HurtMat;

    private PlayerControl playerControlScript;

    public bool doHurtTimer = false;
    public float HurtTimer = 1f;
    public float HurtLimit = 0f;
    public bool GotHurt;

    public ParticleSystem HurtParticle;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealthTeam1Pts = StartingPlayerHealthPts;
        PlayerHealthTeam2Pts = StartingPlayerHealthPts;

        playerControlScript = this.GetComponent<PlayerControl>();


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealthTeam1Pts <= 0)
        {
            Debug.Log("Team 2 wins");
            //Destroy(this.gameObject);

            // exit scene
        }

        if (PlayerHealthTeam2Pts <= 0)
        {
            Debug.Log("Team 1 wins");
            //Destroy(this.gameObject);

            // exit scene
        }



        if (doHurtTimer)
        {
            HurtTimer -= Time.deltaTime;
        }

        if (HurtTimer <= HurtLimit)
        {
            GotHurt = true;

            doHurtTimer = false;

            HurtTimer = 1f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (playerControlScript.Team1)
        {
            if (collision.gameObject.tag == "BulletTeam2")
            {
                PlayerHealthTeam1Pts -= 1;

                HurtParticle.Play(true);
            }

        }

        if (playerControlScript.Team2)
        {
            if (collision.gameObject.tag == "BulletTeam1")
            {
                PlayerHealthTeam2Pts -= 1;

                HurtParticle.Play(true);
            }
        }
    }
}
