
public class RemovePowerup : Powerup
{
    
    public override bool DoPowerup()
    {
        print("Removing powerup");
        Remove();
        return true;
    }
    
    public void Remove()
    {
        powerups.Player.RemoveLastCard();
    }
}