using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzleCollScrpt : MonoBehaviour {
    public PuzleScrpt PuzleScrpt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Movable")
        {
            PuzleScrpt.GameWon = true;
            // Debug.Log("Collission");
        }
    }
}
