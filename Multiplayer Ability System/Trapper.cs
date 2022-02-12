using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Trapper : Ability
{
    [SerializeField] GameObject trap;
    [SerializeField] float trapLifeTime;
    [SerializeField] float coolDownTime;
    bool coolDown = false;
    float timer = 0;
    [SerializeField] AbilityCooldownUI cooldownUI;
    [SerializeField] Collider2D myCol;
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
            GameObject g = Instantiate(trap, this.transform.position, Quaternion.identity);
            g.GetComponent<Trap>().myCol = myCol;
            Destroy(g, trapLifeTime);
        }
    }

    public override void UpdateAbility()
    {
        if (coolDown)
        {
            timer += Time.deltaTime;
            cooldownUI.UpdateImageFill(timer, coolDownTime);
            if (timer >= coolDownTime)
            {
                timer = 0;
                coolDown = false;
            }
        }
    }
}
