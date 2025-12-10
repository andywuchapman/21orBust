
public class DoublePowerup : Powerup
{

    public override bool DoPowerup()
    {
        if (powerups.GameManager.LastButtonPressed == LastButtonPressedType.Hit)
        {
            powerups.Player.GetCard(true);
            return true;
        }
        else
        {
            return false;
        }
    }
}