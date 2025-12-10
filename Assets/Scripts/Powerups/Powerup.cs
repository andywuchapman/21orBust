using UnityEngine;
using UnityEngine.UIElements;

public class Powerup : MonoBehaviour
{
    // stuff that all powerups do
    protected Powerups powerups;

    public void RegisterPowerups(Powerups powerups)
    {
        this.powerups = powerups;
    }

    public virtual bool DoPowerup()
    {
        return true;
    }
    
    
    public void OnPowerupClicked()
    {
        if (!powerups.HasPowerup(this))
            return;
        bool wasSuccess = DoPowerup();
        if (wasSuccess)
            powerups.OnPowerupClicked(this);
    }

    public void DestroyPowerup()
    {
        Destroy(gameObject);
    }
}
