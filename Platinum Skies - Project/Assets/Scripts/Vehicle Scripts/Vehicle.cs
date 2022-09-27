using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VehicleType
{
    plane,
    ship,
    gunship,
    other
}

public enum VehicleState
{
    flying,
    idle,
    other
}

public abstract class Vehicle : MonoBehaviour
{
    [HideInInspector] public PlayerController ourPlayer;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public int ourPlayerID;

    public Stats vehicleStats;
    public Faction ourFaction;
    public VehicleState ourState;
    public Vector3 momentum, turningVector;
    

    public virtual void Awake()
    {
        if (vehicleStats != null)
        {
            vehicleStats = Instantiate(vehicleStats);
            vehicleStats.SetStats();
        }
        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    public virtual void FixedUpdate()
    {
        switch(ourState)
        {
            case(VehicleState.flying):
                Movement();
                break;

            case(VehicleState.idle):
                break;

            default:
                break;
        }
    }

    public virtual void Initialize(PlayerController newPlayer)
    {
        ourPlayer = newPlayer;
        ourPlayerID = newPlayer.playerID;
        ourPlayer.ourVehicle = this;
    }

    public virtual void Movement()
    {
        if (ourPlayer != null)
        {
            if (ourPlayer.flightAxis != Vector2.zero)
            {
                
            }
            if (ourPlayer.rollAxis != Vector2.zero)
            {
                
            }
        }

        if (turningVector != Vector3.zero || turningVector != rb.angularVelocity)
        {
            rb.AddRelativeTorque(turningVector);
        }

        if (momentum != Vector3.zero || momentum != rb.velocity)
        {
            rb.AddForce(transform.TransformDirection(momentum), ForceMode.VelocityChange);
        }
    }
}