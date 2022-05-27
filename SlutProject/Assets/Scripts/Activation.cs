using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public GameObject grapple_text;
    [SerializeField] private GameObject grap;

    //Texterna är av 
    private void Start() 
    {
        grapple_text.SetActive(false);
    }

    // När jag går in i olika triggerpoints så visas text som hjälper spelaren
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            grapple_text.SetActive(true);
        }
    }

}
