using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDamage : Damageable
{
    PlayerScriptManager scriptManager;
    [SerializeField] float cooldown;
    [SerializeField] GameObject craftingScreen, doneScreen;
    [SerializeField] float regenTime;
    [SerializeField] int regenHealthAmt;
    [SerializeField] Animator anim;
    PlayerUIManager playerUI;
    PlayerMovement playerMovement;
    Rumbler controllerRumble;
    LootDrop lootDrop;
    bool dead = false;
    float timer = 0;
    float regenTimer = 0;
    public override void Damage(int amt, ItemType itemType, int tier, Vector2 pos)
    {
        health -= amt;
        regenTimer = 0;
        playerUI.UpdatePlayerHealth(health, maxHealth);
        if(health <= 0)
        {
            Death();
            lootDrop.DropLoot();
        }else
        {
            Vector2 force = pos - (Vector2)this.transform.position;
            force = force.normalized * 4;
            playerMovement.ApplyKnockback(-force);
            controllerRumble.RumblePulse(0.5f, 1.5f, 0.2f, 0.3f);
        }
    }
    private void Awake()
    {
        scriptManager = GetComponent<PlayerScriptManager>();
        playerUI = GetComponent<PlayerUIManager>();
        lootDrop = GetComponent<LootDrop>();
        controllerRumble = GetComponent<Rumbler>();
        playerMovement = GetComponent<PlayerMovement>();
        maxHealth = health;
    }

    private void Update()
    {
        if (dead)
        {
            timer += Time.deltaTime;
            if(timer >= cooldown && (!craftingScreen.activeInHierarchy && !doneScreen.activeInHierarchy))
            {
                dead = false;
                timer = 0;
                Respawn();
            }
        }else
        {
            if(health > 0 && health < maxHealth)
            {
                regenTimer += Time.deltaTime;
                if (regenTimer >= regenTime && (!craftingScreen.activeInHierarchy && !doneScreen.activeInHierarchy))
                {
                    RegenHealth(regenHealthAmt);
                    regenTimer = 0;
                }
            }
        }
    }

    public void RegenHealth(int amt)
    {
        health += amt;
        if (health > maxHealth)
            health = maxHealth;
        playerUI.UpdatePlayerHealth(health, maxHealth);
    }
    void Death()
    {

        controllerRumble.RumbleLinear(0.1f, 0.8f, 0.1f, 1, 1);
        scriptManager.TogglePlayerScripts(false);
        anim.SetTrigger("Dead");
        print("Dead");
        dead = true;
    }
    void Respawn()
    {
        scriptManager.TogglePlayerScripts(true);
        health = maxHealth;
        playerUI.UpdatePlayerHealth(health, maxHealth);
        Transform[] tran = new Transform[1];
        tran[0] = this.transform;
        SpawnManager.instance.Spawn(tran);
        anim.SetTrigger("Alive");
        print("Respawned");
    }

   
}
