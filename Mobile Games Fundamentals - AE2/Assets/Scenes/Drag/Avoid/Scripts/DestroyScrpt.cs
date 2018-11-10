using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScrpt : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Destroy")
        {
            Destroy(collision.gameObject);
            Debug.Log("Destroyed");
        }
    }
}
