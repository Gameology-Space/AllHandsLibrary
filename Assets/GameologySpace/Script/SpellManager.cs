using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    // Define the events for the spells
    public event System.Action OnEarthSpellActivated;
    public event System.Action OnFireSpellActivated;
    public event System.Action OnIceSpellActivated;

    // Function to activate the Earth spell
    public void ActivateEarthSpell()
    {
        Debug.Log("Earth Spell Activated!");
        OnEarthSpellActivated?.Invoke(); // Invoke the Earth spell event
    }

    // Function to activate the Fire spell
    public void ActivateFireSpell()
    {
        Debug.Log("Fire Spell Activated!");
        OnFireSpellActivated?.Invoke(); // Invoke the Fire spell event
    }

    // Function to activate the Ice spell
    public void ActivateIceSpell()
    {
        Debug.Log("Ice Spell Activated!");
        OnIceSpellActivated?.Invoke(); // Invoke the Ice spell event
    }
}
