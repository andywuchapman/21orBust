using System;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public GameManager GameManager;
    public Player Player;
    public Deck Deck;
    public SpriteRenderer PeerSpriteRenderer;
    public DoublePowerup DoublePowerup;
    
    private List<Powerup> powerups;

    public void Awake()
    {
        powerups = new List<Powerup>();
        AddPowerup(DoublePowerup);
    }
    
    public void AddPowerup(Powerup powerup)
    {
        powerups.Add(powerup);
        powerup.RegisterPowerups(this);
    }
    
    private void RemovePowerup(Powerup powerup)
    {
        powerups.Remove(powerup);
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

    private void FindRecentCard()
    {
        //find the most recent card drawn
    }
}
