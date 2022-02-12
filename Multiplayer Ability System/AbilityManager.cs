using UnityEngine.InputSystem;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public Ability currentAbility;
    public AbilityCooldownUI abilityCooldown;

    public void ActivateAbility(InputAction.CallbackContext context)
    {
        if (GameManager.instance.CanDoInput())
        {
            if (context.performed)
                currentAbility.StartAbility(context);
            else if (context.canceled)
                currentAbility.EndAbility(context);
        }
    }

    public void SetAbility(Ability ability)
    {
        if (currentAbility != null)
            currentAbility.DeleteAbility();

        currentAbility = ability;
        currentAbility.InitializeAbility();

        if (ability.hasCooldown)
        {
            abilityCooldown.gameObject.SetActive(true);
            abilityCooldown.foreground.sprite = ability.sprite;
            abilityCooldown.background.sprite = ability.sprite;
        }
        else
        {
            abilityCooldown.gameObject.SetActive(false);
        }
           
    }

    private void Update()
    {
        if(currentAbility != null)
            currentAbility.UpdateAbility();
    }

}
