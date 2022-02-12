using UnityEngine.InputSystem;
using UnityEngine;

public class Dodge : Ability
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] AbilityCooldownUI cooldownUI;
    public override void StartAbility(InputAction.CallbackContext context)
    {
        playerMovement.StartDodge();
    }
    public override void EndAbility(InputAction.CallbackContext context)
    {
        playerMovement.EndDodge();
    }

    public override void InitializeAbility()
    {
    }

    public override void DeleteAbility()
    {
    }

    public override void UpdateAbility()
    {
        if(playerMovement.dodgeCooldown)
        {
            cooldownUI.UpdateImageFill(playerMovement.timer, playerMovement.dashCooldownLength);
        }
        else
        {
            cooldownUI.UpdateImageFill(playerMovement.dashCooldownLength, playerMovement.dashCooldownLength);
        }
    }
}
