using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public GameObject grapple_text;
    [SerializeField] private GameObject grap;

    private void Start() 
    {
        grapple_text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            grapple_text.SetActive(true);
        }
    }

}
