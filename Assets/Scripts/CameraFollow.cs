using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float height = 40;
    public float distance = 40;
    public GameObject target;
    public int id;

    public Vector3 offset;
    public float smoothSpeed = 0.125f;



    // Start is called before the first frame update
    void Start()
    {
        var camComponent = GetComponent<Camera>();

        int LayerEverything = LayerMask.NameToLayer("Everything");
        int LayerPlayer1See = LayerMask.NameToLayer("Player1See");
        int LayerPlayer2See = LayerMask.NameToLayer("Player2See");
        int LayerPlayer3See = LayerMask.NameToLayer("Player3See");
        int LayerPlayer4See = LayerMask.NameToLayer("Player4See");
        int LayerPlayerTeam1See = LayerMask.NameToLayer("PlayerTeam1See");
        int LayerPlayerTeam2See = LayerMask.NameToLayer("PlayerTeam2See");


        switch (id)
        {
            case 0:
                camComponent.rect = new Rect(new Vector2(0, 0.5f), new Vector2(0.5f, 0.5f));

                camComponent.cullingMask = (LayerEverything << 0) & ~(1 << LayerPlayerTeam2See) & ~(1 << LayerPlayer2See) & ~(1 << LayerPlayer3See) & ~(1 << LayerPlayer4See);
                break;

            case 1:
                camComponent.rect = new Rect(new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));

                camComponent.cullingMask = (LayerEverything << 0) & ~(1 << LayerPlayerTeam2See) & ~(1 << LayerPlayer1See) & ~(1 << LayerPlayer3See) & ~(1 << LayerPlayer4See);
                break;

            case 2:
                camComponent.rect = new Rect(new Vector2(0, 0), new Vector2(0.5f, 0.5f));

                camComponent.cullingMask = (LayerEverything << 0) & ~(1 << LayerPlayerTeam1See) & ~(1 << LayerPlayer1See) & ~(1 << LayerPlayer2See) & ~(1 << LayerPlayer4See);
                break;

            case 3:
                camComponent.rect = new Rect(new Vector2(0.5f, 0), new Vector2(0.5f, 0.5f));

                camComponent.cullingMask = (LayerEverything << 0) & ~(1 << LayerPlayerTeam1See) & ~(1 << LayerPlayer1See) & ~(1 << LayerPlayer2See) & ~(1 << LayerPlayer3See);
                break;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    transform.position = new Vector3(target.transform.position.x, target.transform.position.y + height, target.transform.position.z - distance);
    //}

    private void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.transform.position.x, target.transform.position.y + height, target.transform.position.z - distance) + offset;
        Vector3 smoothSpeedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothSpeedPosition;
    }
}
