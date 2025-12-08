using UnityEngine;

public class RandomizerPowerup : Powerup
{

    public override bool DoPowerup()
    {
        Randomizer();
        return true;
    }
    
    public void Randomizer()
    {
        powerups.Player.RandomizeLastCardInHand();
    }
}
