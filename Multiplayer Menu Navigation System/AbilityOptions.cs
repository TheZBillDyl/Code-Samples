using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityOptions : CustomizerCategory
{
    [Header("Abilities")]
    [SerializeField] GameObject abilitySource;
    Ability[] abilities;
    [SerializeField] AbilityManager abilityManager;

    private void Start()
    {
        abilities = abilitySource.GetComponents<Ability>();
        arrayLength = abilities.Length;
        SetOption();
    }
    public override void SetOption()
    {
        abilityManager.SetAbility(abilities[selectedIndex]);
        SetOptionSprites();
        optionName.text = abilities[selectedIndex].name;
    }

    public override void SetOptionSprites()
    {
        //We need to check the indexes to make sure we arent break the arrays
        if (abilities.Length > 0)
        {
            if (selectedIndex - 1 >= 0)
                SetSprite(abilities[selectedIndex - 1].sprite, previousOptionSprite);
            else
                SetSprite(null, previousOptionSprite);

            SetSprite(abilities[selectedIndex].sprite, selectedOptionSprite);

            if (selectedIndex + 1 <= abilities.Length - 1)
                SetSprite(abilities[selectedIndex + 1].sprite, nextOptionSprite);
            else
                SetSprite(null, nextOptionSprite);
        }
        else
        {
            SetSprite(null, selectedOptionSprite);
        }
    }
}
