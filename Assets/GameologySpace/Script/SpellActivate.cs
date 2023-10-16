using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActivate : MonoBehaviour
{
    private void Start()
    {
        SpellManager spellManager = FindObjectOfType<SpellManager>();

        // Subscribe to the spell events
        spellManager.OnEarthSpellActivated += HandleEarthSpell;
        spellManager.OnFireSpellActivated += HandleFireSpell;
        spellManager.OnIceSpellActivated += HandleIceSpell;
    }

    private void HandleEarthSpell()
    {
        Debug.Log("Handling Earth Spell...");

        // Find the child object named "Earth"
        Transform spellTransform = transform.Find("Earth");
        if (spellTransform != null)
        {
            // Start the coroutine to handle the activation and deactivation
            StartCoroutine(ActivatedSpell(spellTransform.gameObject, "Earth"));
        }
        else
        {
            Debug.LogWarning("Earth not found!");
        }
    }

    private void HandleFireSpell()
    {
        Debug.Log("Handling Fire Spell...");

        // Find the child object named "Flamethrower"
        Transform spellTransform = transform.Find("FlameThrower");
        if (spellTransform != null)
        {
            // Start the coroutine to handle the activation and deactivation
            StartCoroutine(ActivatedSpell(spellTransform.gameObject, "Fire"));
        }
        else
        {
            Debug.LogWarning("Flamethrower not found!");
        }
    }

    private void HandleIceSpell()
    {
        Debug.Log("Handling Ice Spell...");

        // Find the child object named "IceLance"
        Transform spellTransform = transform.Find("IceLance");
        if (spellTransform != null)
        {
            // Start the coroutine to handle the activation and deactivation
            StartCoroutine(ActivatedSpell(spellTransform.gameObject, "Ice"));
        }
        else
        {
            Debug.LogWarning("IceLance not found!");
        }
    }

    private IEnumerator ActivatedSpell(GameObject spell, string spellName)
    {
        yield return new WaitForSeconds(1f);

        // Play the corresponding sound based on the spell name
        switch (spellName)
        {
            case "Earth":
                SoundFX.Instance.PlayEarthSound();
                break;
            case "Fire":
                SoundFX.Instance.PlayFireSound();
                break;
            case "Ice":
                SoundFX.Instance.PlayIceSound();
                break;
            default:
                Debug.LogWarning($"Unknown spell name: {spellName}");
                break;
        }

        // Set IceLance to active
        spell.SetActive(true);

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Set IceLance to inactive
        spell.SetActive(false);
    }

    private void OnDestroy()
    {
        SpellManager spellManager = FindObjectOfType<SpellManager>();

        // Unsubscribe from the spell events
        if (spellManager != null)
        {
            spellManager.OnEarthSpellActivated -= HandleEarthSpell;
            spellManager.OnFireSpellActivated -= HandleFireSpell;
            spellManager.OnIceSpellActivated -= HandleIceSpell;
        }
    }
}
