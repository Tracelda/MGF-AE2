using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringScrpt : MonoBehaviour {


	void Start () {
		
	}

    void Update()
    {
        transform.Rotate(Input.acceleration.y * 2, 0, -Input.acceleration.x * 2, Space.World);
    }

}
