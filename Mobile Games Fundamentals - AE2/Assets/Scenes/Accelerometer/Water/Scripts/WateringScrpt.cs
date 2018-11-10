using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringScrpt : MonoBehaviour {
    public Vector3 Rotation;
    public float LeftLock;
    public float RightLock;
    public GameObject Wateringcan;
    public Rigidbody2D Rigid;
    

	void Start ()
    {
        Wateringcan = GameObject.Find("WateringCan");
        Rigid = Wateringcan.GetComponent<Rigidbody2D>();
        LeftLock = 10f;
        RightLock = -30f;
    }

    void Update()
    {
        Rotate();
        CheckRotation();
    }

    public void Rotate()
    {
        Rotation = new Vector3(0, 0, -Input.acceleration.x * 2);
        transform.Rotate(Rotation);
    }

    public void CheckRotation()
    {
        //if (gameObject.transform.rotation.z < RightLock)
        //{
        //    gameObject.transform.rotation = Quaternion.Euler(Rotation.x, Rotation.y, RightLock);

        //    Rigid.freezeRotation = true;
        //    Debug.Log("Freeze Right");
        //}

        if (gameObject.transform.rotation.z >= LeftLock)
        {
            gameObject.transform.rotation = Quaternion.Euler(Rotation.x, Rotation.y, LeftLock);

            Rigid.freezeRotation = true;
            Debug.Log("Freeze Left");
        }
    }

    //if (gameObject.transform.rotation.z == LeftLock)
    //{
    //    Debug.Log("Pouring");
    //}


}
