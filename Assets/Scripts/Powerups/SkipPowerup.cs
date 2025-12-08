public class SkipPowerup : Powerup
{
    public override bool DoPowerup()
    {
        return true;
    }
    
    // just the skip powerup specifics
    
    public void Skip()
    {
        //remove the next card
        //select card in second position
    }
}
