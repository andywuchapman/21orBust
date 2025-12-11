using System;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupType
{
    Double,
    Balance,
    Peer,
    Randomizer,
    Remove,
    Skip
}

public class Powerups : MonoBehaviour
{
    public GameManager GameManager;
    public Player Player;
    public Deck Deck;
    public SpriteRenderer PeerSpriteRenderer;
    public GameObject PowerupsPanel;
    
    public GameObject RemovePowerupPrefab;
    public GameObject BalancePowerupPrefab;
    public GameObject DoublePowerupPrefab;
    public GameObject PeerPowerupPrefab;
    public GameObject RandomizerPowerupPrefab;
    public GameObject SkipPowerupPrefab;
    
    private List<Powerup> powerups;

    public void Awake()
    {
        powerups = new List<Powerup>();
    }
    
    public void AddPowerup(PowerupType powerupType)
    {
        switch (powerupType)
        {
            case PowerupType.Double:
                GameObject doublePowerup = Instantiate(DoublePowerupPrefab);
                doublePowerup.transform.SetParent(PowerupsPanel.transform);
                DoublePowerup doublePowerupScript = doublePowerup.GetComponent<DoublePowerup>();
                powerups.Add(doublePowerupScript);
                doublePowerupScript.RegisterPowerups(this);
                break;
            case PowerupType.Remove:
                GameObject removePowerup = Instantiate(RemovePowerupPrefab);
                removePowerup.transform.SetParent(PowerupsPanel.transform);
                RemovePowerup removePowerupScript = removePowerup.GetComponent<RemovePowerup>();
                powerups.Add(removePowerupScript);
                removePowerupScript.RegisterPowerups(this);
                break;
            case PowerupType.Skip:
                GameObject skipPowerup = Instantiate(SkipPowerupPrefab);
                skipPowerup.transform.SetParent(PowerupsPanel.transform);
                SkipPowerup skipPowerupScript = skipPowerup.GetComponent<SkipPowerup>();
                powerups.Add(skipPowerupScript);
                skipPowerupScript.RegisterPowerups(this);
                break;
            case PowerupType.Peer:
                GameObject peerPowerup = Instantiate(PeerPowerupPrefab);
                peerPowerup.transform.SetParent(PowerupsPanel.transform);
                PeerPowerup peerPowerupScript = peerPowerup.GetComponent<PeerPowerup>();
                powerups.Add(peerPowerupScript);
                peerPowerupScript.RegisterPowerups(this);
                break;
            case PowerupType.Randomizer:
                GameObject randomizerPowerup = Instantiate(RandomizerPowerupPrefab);
                randomizerPowerup.transform.SetParent(PowerupsPanel.transform);
                RandomizerPowerup randomizerPowerupScript = randomizerPowerup.GetComponent<RandomizerPowerup>();
                powerups.Add(randomizerPowerupScript);
                randomizerPowerupScript.RegisterPowerups(this);
                break;
        }
    }

    private void AddSpriteToUI()
    {
        
    }
    
    private void RemovePowerup(Powerup powerup)
    {
        powerups.Remove(powerup);
        
        // also add code to delete the powerup gameobject that's on screen
    }

    public void OnPowerupClicked(Powerup powerup)
    {
        RemovePowerup(powerup);
    }
    
    public bool HasPowerup(Powerup powerup)
    {
        if (powerups.Contains(powerup))
            return true;
        return false;
    }
}
