using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCS : MonoBehaviour
{
    public Rigidbody m_rigidbody;
    
    public float DashForce = 300.0f;
    public float WSpeed = 100.0f;
    float Speed;
    public float MouseVel;
    float AAngle;
    Vector3 DashVector;
    Vector3 PlayerForward;
    Vector3 InputDirection;
    Vector3 CF;
    Vector3 CFN;
    Vector3 VelocityVector;
    Vector3 VelocityNormal;
    float DashTimer;
    float DashTimerMax = 0.1f;




  
    void Start()
    {
         m_rigidbody = GetComponent<Rigidbody>();
        
    }

 
    void Update()
    {   PlayerForward =m_rigidbody.transform.forward;

        CF.x = PlayerForward.x;
        CF.z = PlayerForward.z;
        CF.y = 0;
        CFN = CF.normalized;

        MouseVel = 5 * Input.GetAxis("Mouse X");
        
        m_rigidbody.transform.Rotate( 0,MouseVel, 0, Space.World);
         
        InputDirection.x = Input.GetAxisRaw("Vertical");
        InputDirection.z = Input.GetAxisRaw("Horizontal");
        InputDirection.y = 0;
        float V2Mag = InputDirection.magnitude;
        float V2X = InputDirection.x;
        float V2Y = InputDirection.z;
        float AngleBetween = Mathf.Acos(((V2X * 1) + (V2Y * 0)) /(V2Mag)) * Mathf.Rad2Deg;
        if (InputDirection.z < 0.0f)
        {
            AAngle = 360 - AngleBetween;
        }
        else
        {
            AAngle = AngleBetween;
        }
        VelocityVector = Quaternion.AngleAxis(AAngle, Vector3.up) * PlayerForward;
        VelocityNormal = (VelocityVector.normalized) * Speed;
        m_rigidbody.velocity = VelocityNormal; 
                
        
         
        if(Input.GetKeyDown("space")){
            Debug.Log("Pressed");
            Dash();

        }

        if (DashTimer > 0)
        {
            DashTimer -= Time.deltaTime;
            Speed = DashForce;
        }
        else{
        Speed = WSpeed;
        }

    }
    public void Dash(){
         DashTimer = DashTimerMax;
    }

}
