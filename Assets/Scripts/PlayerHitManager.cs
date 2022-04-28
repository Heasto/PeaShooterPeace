using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHitManager : MonoBehaviour
{
    public Material HurtMat;

    private PlayerControl playerControlScript;

    public bool doHurtTimer = false;
    public float HurtTimer = 1f;
    public float HurtLimit = 0f;
    public bool GotHurt;

    public ParticleSystem HurtParticle;

    public GameManager GameManagerScript;
    public GameObject MyGameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = this.GetComponent<PlayerControl>();

        MyGameManager = GameObject.FindGameObjectWithTag("GameManager");

        GameManagerScript = MyGameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

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
                GameManagerScript.PlayerHealthTeam1Pts -= 1;

                HurtParticle.Play(true);
            }

        }

        if (playerControlScript.Team2)
        {
            if (collision.gameObject.tag == "BulletTeam1")
            {
                GameManagerScript.PlayerHealthTeam2Pts -= 1;

                HurtParticle.Play(true);
            }
        }
    }
}
