using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected int health;
    protected int maxHealth;

    private void Awake()
    {
        //Probably will be overwritten by other script
        maxHealth = health;
    }
    public virtual void Damage(int amt, ItemType itemType, int tier, Vector2 position) { }
    public virtual void IncreaseMaxHealth(int amt)
    {
        maxHealth += amt;
        print("Player health increased from " + (maxHealth - amt) + " to " + maxHealth);
    }
}
