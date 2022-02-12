using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RefinerySkip : Ability
{
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] AbilityCooldownUI cooldownUI;
    [SerializeField] float coolDownTime;
    bool coolDown = false;
    float timer = 0;
    public override void DeleteAbility()
    {

    }

    public override void EndAbility(InputAction.CallbackContext context)
    {

    }

    public override void InitializeAbility()
    {

    }

    public override void StartAbility(InputAction.CallbackContext context)
    {
        if (!coolDown)
        {
            coolDown = true;

            //Get the raw resource, reduce it,  modify the refined resource correctly.
            Resource[] resources = ResourceController.instance.GetRawResources();
            Resource[] refined = ResourceController.instance.GetRefinedResources();
            for (int i = 0; i < resources.Length; i++)
            {
                int amt = playerInventory.GetRawResourceAmount(resources[i].resourceType);
                playerInventory.ModifyResourceAmount(resources[i], -amt);
                playerInventory.ModifyResourceAmount(refined[i], amt);
            }
        }
    }

    public override void UpdateAbility()
    {
        if (coolDown)
        {
            timer += Time.deltaTime;
            cooldownUI.UpdateImageFill(timer, coolDownTime);
            if(timer >= coolDownTime)
            {
                timer = 0;
                coolDown = false;
            }
        }
    }
}
