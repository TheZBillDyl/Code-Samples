using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Invisibility : Ability
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] GameObject invisibilityParticles;
    [SerializeField] Color invisibleColor, normalColor;
    [SerializeField] Headlamp headlamp;
    bool isInvisible = false;
    [SerializeField] float timeInvisible = 5, coolDownTime;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource src;
    [SerializeField] AbilityCooldownUI cooldownUI;
    bool activated = false, coolDown = false;
    float timer = 0;
    public override void DeleteAbility()
    {
        sr.color = normalColor;
        activated = false;
        headlamp.enabled = true;
    }

    public override void EndAbility(InputAction.CallbackContext context)
    {
        
    }

    public override void InitializeAbility()
    {
        normalColor = sr.color;
        activated = true;
        src.clip = clip;
    }

    public override void StartAbility(InputAction.CallbackContext context)
    {
        if (!isInvisible && !coolDown)
        {
            sr.color = invisibleColor;
            isInvisible = true;
            headlamp.ToggleHeadLamp(false);
            headlamp.enabled = false;
            src.Play();
            Instantiate(invisibilityParticles, this.transform.position, Quaternion.identity);
        }

    }

    public override void UpdateAbility()
    {
        if (activated)
        {
            //Do ability stuff!
            //Cooldown
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

            if (isInvisible)
            {
                timer += Time.deltaTime;
                if (timer >= timeInvisible)
                {
                    timer = 0;
                    coolDown = true;
                    headlamp.enabled = true;
                    sr.color = normalColor;
                    isInvisible = false;
                }
            }
        }
    }
}
