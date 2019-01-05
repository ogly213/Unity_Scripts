using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class Manejo: MonoBehaviour
{
    public WheelCollider WheelFL;//Los coliders de las ruedas
    public WheelCollider WheelFR;
    public WheelCollider WheelBL;
    public WheelCollider WheelBR;

    public GameObject FL;//Los Objetos
    public GameObject FR;
    public GameObject BL;
    public GameObject BR;

    public float topSpeed = 250f;//Maxima Velocidad
    public float maxTorque = 200f;//El par máximo para aplicar a las ruedas.
    public float maxSteerAngle = 45f;
    public float currentSpeed;
    public float maxBrakeTorque = 2200;


    private float Forward;//Eje Frontal
    private float Turn;//Giro
    private float Brake;//Freno

    private Rigidbody rb;// Rigid Body para el coche


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() //Mas realista a la hora de fisicas
    {
        Forward = Input.GetAxis("Vertical");
        Turn = Input.GetAxis("Horizontal");
        Brake = Input.GetAxis("Jump");

        WheelFL.steerAngle = maxSteerAngle * Turn;
        WheelFR.steerAngle = maxSteerAngle * Turn;

        currentSpeed = 2 * 22 / 7 * WheelBL.radius * WheelBL.rpm * 60 / 1000; //formula para calcularlo todo

        if (currentSpeed < topSpeed)
        {
            WheelBL.motorTorque = maxTorque * Forward;//Gira las ruedas tanto para alante como para atras :v
            WheelBR.motorTorque = maxTorque * Forward;
        }

        WheelBL.brakeTorque = maxBrakeTorque * Brake;
        WheelBR.brakeTorque = maxBrakeTorque * Brake;
        WheelFL.brakeTorque = maxBrakeTorque * Brake;
        WheelFR.brakeTorque = maxBrakeTorque * Brake;

    }
    void Update()
    {
        Quaternion flq;
        Vector3 flv;
        WheelFL.GetWorldPose(out flv, out flq);
        FL.transform.position = flv;
        FL.transform.rotation = flq;

        Quaternion Blq;
        Vector3 Blv;
        WheelBL.GetWorldPose(out Blv, out Blq);
        BL.transform.position = Blv;
        BL.transform.rotation = Blq;

        Quaternion fRq;
        Vector3 fRv;
        WheelFR.GetWorldPose(out fRv, out fRq);
        FR.transform.position = fRv;
        FR.transform.rotation = fRq;

        Quaternion BRq;
        Vector3 BRv;
        WheelBR.GetWorldPose(out BRv, out BRq);
        BR.transform.position = BRv;
        BR.transform.rotation = BRq;

    }
}
