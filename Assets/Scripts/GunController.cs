using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public bool isFiring;
    public bulletController bullet;
    public float bulletSpeed;
    public float timerBetweenShots;
    private float shotCounter;

    public Transform firePoint;
    private int shoot;


    private void Awake()
    {


    }

    void Start()
    {
        
    }

    void Update()
    {
        //if (isFiring)
        //{
        //    shotCounter -= Time.deltaTime;
        //    if (shotCounter <= 0)
        //    {
        //        shotCounter = timerBetweenShots;
        //        bulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as bulletController;
        //        newBullet.speed = bulletSpeed;
        //    }
        //}
    }

    public void FireGun(InputAction.CallbackContext context)
    {
        bulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        newBullet.speed = bulletSpeed;
    }

    /*public void OnShoot(InputAction.CallbackContext context)
    {
        shoot = context.ReadValue<int>();
        context.ReadValueAsButton();
    }*/
}
