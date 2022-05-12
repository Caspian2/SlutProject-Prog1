using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{   
    public Transform laserGun;
    public Transform shootPoint;
    public GameObject laserPrefab;

    private float fireRate = 3f;
    private float lastTimeShoot = 0f;


    Vector2 direrction;

    // Update is called once per frame
    void Update()
    {   //Gör så att pist9len följer efter musen och pistolen flipar om jag drar musen över på vänster
        FaceMouse();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - laserGun.position;
        
        mousePos.Normalize();

        float rotationZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        laserGun.rotation = Quaternion.Euler(0f, 0f, rotationZ); 

        if(rotationZ > 90 || rotationZ < -90)
        {
            laserGun.Rotate(180, 0, 0);
        }

        /*LastTimeShoot = Ingame Tiden så om lastTimeShoot + firerate så kan jag skjuta, annars kan jag inte*/
        if(!PauseMenu.isPaused)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                if(Time.time > lastTimeShoot + fireRate)
                {
                    lastTimeShoot = Time.time;
                    Shoot();
                }
            }
        }
    }

    void FaceMouse()
    {
        laserGun.transform.right = direrction;
    }

    void Shoot()
    {
        Instantiate(laserPrefab, shootPoint.position, shootPoint.rotation);
    }
}
