using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    Vector2 lookVector;
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(lookVector.magnitude == 0 && playerMovement.GetMovementVector().magnitude != 0)
        {
            //Not being held then default to look in movement direction
            var angle = Mathf.Atan2(playerMovement.GetMovementVector().y, playerMovement.GetMovementVector().x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        else if(lookVector.magnitude != 0)
        {
            var angle = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        
    }

    public void Look(InputAction.CallbackContext callback)
    {
        lookVector = callback.ReadValue<Vector2>();
    }
}
