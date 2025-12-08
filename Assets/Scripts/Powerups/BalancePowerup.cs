public class BalancePowerup : Powerup
{

    public override bool DoPowerup()
    {
        return true;
    }
    
    public void Balance()
    {
        //if "add" is selected,
        //AddOne();
        //else if "subtract" is selected,
        //SubtractOne();
    }
    
    private void AddOne()
    {
        //add +1 to the next card's total
    }

    private void SubtractOne()
    {
        //minus -1 to the next card's total
    }
}
