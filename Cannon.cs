using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Interactable
{
    public bool isLoaded;
    [SerializeField]
    Animator anim;
    [SerializeField]
    Pipe[] pipes;
    AudioSource src;
    [SerializeField]
    AudioClip clip;

    [SerializeField] SteamEngine steamEngine;
    [SerializeField] AudioClip[] clips;



    private void Awake()
    {
        src = GetComponent<AudioSource>();
        src.clip = clip;
    }
    public override void EndInteraction()
    {
        //Fire cannon if able
        if(anim.GetBool("isHolding") && isLoaded)
        {
            bool rdy = false;
            for (int i = 0; i < pipes.Length; i++)
            {
                if (pipes[i].isBursted)
                {
                    rdy = false;
                    break;
                } else
                {
                    rdy = true;
                    
                }
            }

            if (steamEngine.steamAmount <= 33) {
                rdy = false;
            }

            if (rdy)
            {
                //Fire
                print("Fire!");
                anim.SetTrigger("Fire");
                rdy = false;
                isLoaded = false;
                Army.instance.GetFucked();
                
            }
           
        }
        anim.SetBool("isHolding", false);

    }

    

    public override void Interact()
    {
        
    }

    public override void Interacting()
    {
        anim.SetBool("isHolding", true);
    }

    public void Fire()
    {
        src.Play();
        //int rand = Random.Range(0, clips.Length - 1);
        //DialogueManager.instance.PlayAudio(clips[rand]);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Player1")
        {
           // print("Player1");
           // collision.GetComponent<InteractSystem>().StopTheInteraction();
            anim.SetBool("isHolding", false);

        } else if(collision.name == "Player2")
            
               // print("player2");
               // collision.GetComponent<InteractSystem>().StopTheInteraction();
                anim.SetBool("isHolding", false);   
    }
}
