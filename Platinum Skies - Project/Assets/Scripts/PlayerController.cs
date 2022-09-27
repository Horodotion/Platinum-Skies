using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public int playerID;
    public Vehicle ourVehicle;
    public Vector2 flightAxis, rollAxis, cameraAxis;

    public void Start()
    {
        GeneralManager.instance.SpawnVehicle(this, VehicleType.plane);
    }

    public void OnFlightStickAxis(InputAction.CallbackContext ctx)
    {
        flightAxis = ctx.ReadValue<Vector2>();
    }

    public void OnRollAxis(InputAction.CallbackContext ctx)
    {
        rollAxis = ctx.ReadValue<Vector2>();
    }

    public void OnCameraAxis(InputAction.CallbackContext ctx)
    {
        cameraAxis = ctx.ReadValue<Vector2>();
    }
}
