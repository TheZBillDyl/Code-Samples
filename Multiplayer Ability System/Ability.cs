using UnityEngine;
using UnityEngine.InputSystem;
public abstract class Ability : MonoBehaviour
{
    public string name;
    public Sprite sprite;
    public bool hasCooldown;
    /// <summary>
    /// initialize any relevant values once the ability is equipped
    /// </summary>
    public abstract void InitializeAbility();
    /// <summary>
    /// Called once the player presses the ability button
    /// </summary>
    /// <param name="context"></param>
    public abstract void StartAbility(InputAction.CallbackContext context);
    /// <summary>
    /// Called once the player releases the ability button
    /// </summary>
    /// <param name="context"></param>
    public abstract void EndAbility(InputAction.CallbackContext context);
    /// <summary>
    /// Reset any values changed
    /// </summary>
    public abstract void DeleteAbility();
    /// <summary>
    /// Called every frame by the ability manager
    /// </summary>
    public abstract void UpdateAbility();
}
