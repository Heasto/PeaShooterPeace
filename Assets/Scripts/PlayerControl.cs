using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    private Vector3 moveVector;
    private Vector3 directionVector;

    public float bulletSpeed;
    public bulletController bullet1;
    public bulletController bullet2;
    public Transform firePoint;

    public Transform SpawnPoint_01;
    public GameObject CameraPrefab;
    private PlayerInput playerInput;

    public bool canShootAgain { get; private set; } = true;
	public GameObject[] ChildList { get; private set; }
    public float ArrowHeight = 5f;

	public float Recoil = 15f;

	public float ReloadTimer = 1f;
    private float reloadLimit = 0f;
    private bool doReloadTimer = true;

    public Material MaterialHatPlayer1;
    public Material MaterialBodyPlayer1;
    public Material MaterialHatPlayer2;
    public Material MaterialBodyPlayer2;
    public Material MaterialHatPlayer3;
    public Material MaterialBodyPlayer3;
    public Material MaterialHatPlayer4;
    public Material MaterialBodyPlayer4;

    public Material CurrentHatMat;
    public Material CurrentBodyMat;

    public GameObject ArrowSprite;

    public int PlayerId;

    public bool Team1;
    public bool Team2;

	void Start()
    {

        
        
        myRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        PlayerTransport();
        var cam = Instantiate(CameraPrefab).GetComponent<CameraFollow>();
        cam.target = this.gameObject;
        cam.id = playerInput.user.index;

        PlayerId = playerInput.user.index;

       // Instantiate(ArrowSprite, transform.position, transform.rotation);

        switch (PlayerId)
        {
            case 0:

                Team1 = true;

                int LayerPlayer01 = LayerMask.NameToLayer("Player1");
                gameObject.layer = LayerPlayer01;



               int LayerPlayerSee01 = LayerMask.NameToLayer("Player1See");
               ArrowSprite.layer = LayerPlayerSee01;

                foreach (Transform child in transform.GetComponentsInChildren<Transform>())
                {
                    if ( child.name == "CHAPEAU")
                    { 
                        gameObject.GetComponentsInChildren<MeshRenderer>();
                       child.gameObject.GetComponent<MeshRenderer>().material = MaterialHatPlayer1;

                    }

                    if (child.name == "CORPS")
                    {
                        gameObject.GetComponentsInChildren<MeshRenderer>();
                        child.gameObject.GetComponent<MeshRenderer>().material = MaterialBodyPlayer1;

                    }
                }
              
                break;

            case 1:

                Team1 = true;

                int LayerPlayer02 = LayerMask.NameToLayer("Player2");
                gameObject.layer = LayerPlayer02;

                int LayerPlayerSee02 = LayerMask.NameToLayer("Player2See");
                ArrowSprite.layer = LayerPlayerSee02;

                foreach (Transform child in transform.GetComponentsInChildren<Transform>())
                {
                    if (child.name == "CHAPEAU")
                    {

                        gameObject.GetComponentsInChildren<MeshRenderer>();
                        child.gameObject.GetComponent<MeshRenderer>().material = MaterialHatPlayer2;

                    }

                    if (child.name == "CORPS")
                    {
                        gameObject.GetComponentsInChildren<MeshRenderer>();
                        child.gameObject.GetComponent<MeshRenderer>().material = MaterialBodyPlayer2;

                    }
                }

                break;

            case 2:

                Team2 = true;


                int LayerPlayer03 = LayerMask.NameToLayer("Player3");
                gameObject.layer = LayerPlayer03;

                int LayerPlayerSee03 = LayerMask.NameToLayer("Player3See");
                ArrowSprite.layer = LayerPlayerSee03;

                foreach (Transform child in transform.GetComponentsInChildren<Transform>())
                {
                    if (child.name == "CHAPEAU")
                    {
                        gameObject.GetComponentsInChildren<MeshRenderer>();
                        child.gameObject.GetComponent<MeshRenderer>().material = MaterialHatPlayer3;

                    }

                    if (child.name == "CORPS")
                    {
                        gameObject.GetComponentsInChildren<MeshRenderer>();
                        child.gameObject.GetComponent<MeshRenderer>().material = MaterialBodyPlayer3;

                    }
                }

                break;

            case 3:

                Team2 = true;

                int LayerPlayer04 = LayerMask.NameToLayer("Player4");
                gameObject.layer = LayerPlayer04;

                int LayerPlayerSee04 = LayerMask.NameToLayer("Player4See");
                ArrowSprite.layer = LayerPlayerSee04;

                foreach (Transform child in transform.GetComponentsInChildren<Transform>())
                {
                    if (child.name == "CHAPEAU")
                    {
                        gameObject.GetComponentsInChildren<MeshRenderer>();
                        child.gameObject.GetComponent<MeshRenderer>().material = MaterialHatPlayer4;

                    }

                    if (child.name == "CORPS")
                    {
                        gameObject.GetComponentsInChildren<MeshRenderer>();
                        child.gameObject.GetComponent<MeshRenderer>().material = MaterialBodyPlayer4;

                    }
                }

                break;

        }

       
    }

    // Update is called once per frame
    void Update()
    {
        ArrowSprite.transform.rotation = Quaternion.identity;

        //ArrowSprite.transform.position = this.transform.position; //new Vector3(this.transform.position.x, this.transform.position.y + ArrowHeight, this.transform.position.z);
            //(this.transform.position.x, this.transform.position.y + ArrowHeight, this.transform.position.z);

        moveInput = new Vector3(moveVector.x, 0f, moveVector.y);
        moveVelocity = moveInput * moveSpeed;

        Vector3 playerDirection = Vector3.right * -directionVector.x + Vector3.forward * -directionVector.y;
        if (playerDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }
        //if (Input.GetKeyDown(KeyCode.JoystickButton5))
        //    theGun.isFiring = true;
        //if(Input.GetKeyUp(KeyCode.JoystickButton5))
        //    theGun.isFiring = true;

        if (doReloadTimer)
        {
            ReloadTimer -= Time.deltaTime;
        }

        if (ReloadTimer <= reloadLimit)
        {
            canShootAgain = true;

            doReloadTimer = false;

            ReloadTimer = 1f;
        }
	}

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    public void OnMoveChanged_P1(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    public void OnDirectionChange_P1(InputAction.CallbackContext context)
    {
        directionVector = context.ReadValue<Vector2>();
    }

    public void FireGun(InputAction.CallbackContext context)
    {
        if (canShootAgain)
        {
            if (context.started)
            {
                if (Team1)
                {
                    bulletController newBullet = Instantiate(bullet1, firePoint.position, firePoint.rotation);
                    newBullet.speed = bulletSpeed;
                }

                if (Team2)
                {
                    bulletController newBullet = Instantiate(bullet2, firePoint.position, firePoint.rotation);
                    newBullet.speed = bulletSpeed;
                }

                //myRigidbody.AddForce(-transform.forward * Recoil, ForceMode.VelocityChange);

                canShootAgain = !canShootAgain;

                doReloadTimer = true;
            }
        }
    }

    public void PlayerTransport()
    {
        transform.position = SpawnPoint_01.transform.position;    
    }
}
