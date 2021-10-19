using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool hold;
    public bool coolDown;
    public int currentPlayer;
    public abstract void Interact();
    public abstract void Interacting();
    public abstract void EndInteraction();
}
