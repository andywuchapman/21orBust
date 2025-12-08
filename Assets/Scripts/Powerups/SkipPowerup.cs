public class SkipPowerup : Powerup
{
    public override bool DoPowerup()
    {
        print("Skip Powerup");
        Skip();
        return true;
    }
    
    public void Skip()
    {
        powerups.Player.ReplaceLastCardInHand();
    }
}
