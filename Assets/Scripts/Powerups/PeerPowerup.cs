using System.Collections;
using UnityEngine;

public class PeerPowerup : Powerup
{
    // just the peer powerup specifics
    
    public override bool DoPowerup()
    {
        RevealCard();
        return true;
    }
    
    public void OnMouseDown()
    {
        OnPowerupClicked();
    }
    
    public void RevealCard()
    {
        Sprite cardSprite = powerups.Deck.GetTopCardSprite();
        powerups.PeerSpriteRenderer.sprite = cardSprite;
        StartCoroutine(WaitToHide());
    }

    IEnumerator WaitToHide()
    {
        yield return new WaitForSeconds(3f);
        powerups.PeerSpriteRenderer.sprite = null;
        Destroy(gameObject);
    }
}
