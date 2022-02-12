using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceObject : Damageable
{
    public Resource resource;
    public int amount;
    public bool isRich, isBrokenAtStart, hasRubble;
    [SerializeField] int rubbleAmount = 5;
    [SerializeField] GameObject rubblePrefab;
    [SerializeField] float rubbleForce = 3;
    BoxCollider2D col;
    SpriteRenderer sr;
    UnityEngine.Rendering.Universal.ShadowCaster2D shadowCaster;
    [SerializeField] ParticleSystem particleSystem;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        shadowCaster = GetComponentInChildren<UnityEngine.Rendering.Universal.ShadowCaster2D>();
    }
    private void Start()
    {
        gameObject.name = resource.name;
        if (!isBrokenAtStart)
        {
            sr.sprite = ResourceController.instance.GetRockSprite(isRich);
        }
        ResourceController.instance.AddToSpawnedResources(this);
    }
    public void RevealMe()
    {
        sr.sprite = resource.sprite;
        col.size = col.size / 2;
        col.isTrigger = true;
        shadowCaster.enabled = false;
    }

    void SpawnRubble(Vector2 pos)
    {
        for (int i = 0; i < rubbleAmount; i++)
        {
            Vector2 offset = new Vector2(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f));
            GameObject g = Instantiate(rubblePrefab, this.transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), Quaternion.identity);
            Vector2 direction = pos - (Vector2)g.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            g.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            g.GetComponent<Rigidbody2D>().AddForce(-(direction.normalized + offset) * rubbleForce);
            g.GetComponent<Rubble>().activated = true;
            Destroy(g, 5);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerInventory>().ModifyResourceAmount(resource, amount);
            Destroy(this.gameObject);
        }
    }

    public override void Damage(int amt, ItemType itemType, int tier, Vector2 hitLocation)
    {
        if (itemType == ItemType.SPAWNABLE)
        {
            amt = amt / 2;
        }
        if (itemType == ItemType.PICKAXE || itemType == ItemType.SPAWNABLE)
        {
            particleSystem.Play();
            health -= amt;
            if (health <= 0)
            {
                resource = ResourceController.instance.GetResourceBasedOnTier(tier);
                RevealMe();
                if (hasRubble)
                    SpawnRubble(hitLocation);
            }
        }
    }
}
