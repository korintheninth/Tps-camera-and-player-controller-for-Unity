using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSC : MonoBehaviour
{
    float Teta;
    float Iota;
    float RotationDegrees;
    private PlayerCS playerCS;
    public GameObject player;
    void Start()
    {
        playerCS = player.GetComponent<PlayerCS>();
    }

    // Update is called once per frame
    void Update()
    {   Teta += Input.GetAxis("Mouse Y");
        Iota += playerCS.MouseVel;
        Teta = Mathf.Clamp(Teta,1.57079633f,4.71238898f);
        float y_location = Mathf.Sin(Teta) * 10;
        float x_location = Mathf.Cos(Teta) * 10;
        transform.localPosition = new Vector3(0,y_location,x_location);
        transform.rotation = Quaternion.Euler((180-(Mathf.Rad2Deg * Teta)), Iota ,transform.rotation.z);
        
    }
}
