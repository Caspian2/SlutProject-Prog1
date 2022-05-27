using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public float x;
    public float y;

    //Om du ramlar av banan så teleporterar du tillbaka till starten
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = new Vector2(x,y);
        }
    }
}

