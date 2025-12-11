using UnityEngine;
using UnityEngine.UI;

public enum LastButtonPressedType
{
    Hit,
    Deal,
    Stand,
    Bet,
}

public class GameManager : MonoBehaviour
{
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betBtn;
    public Button endBtn;

    private int standClicks = 0;

    public Player player;
    public Player dealer;

    // NEW: reference to BlackjackLevels
    public BlackjackLevels blackjackLevels;

    public Text standBtnText;
    public Text scoreText;
    public Text dealerScoreText;
    public Text betsText;
    public Text cashText;
    public Text mainText;

    public GameObject hideCard;

    public LastButtonPressedType LastButtonPressed;

    private int pot = 0;

    private void Start()
    {
        // Auto-find BlackjackLevels if not set in Inspector
        if (blackjackLevels == null)
        {
            blackjackLevels = FindObjectOfType<BlackjackLevels>();
        }
    }

    public void DealClicked()
    {
        LastButtonPressed = LastButtonPressedType.Deal;

        player.ResetHand();
        dealer.ResetHand();

        dealerScoreText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);

        GameObject.Find("Deck").GetComponent<Deck>().Shuffle();
        player.StartHand();
        dealer.StartHand();

        scoreText.text = "Hand: " + player.handValue;
        dealerScoreText.text = "Hand: " + dealer.handValue;

        hideCard.GetComponent<Renderer>().enabled = true;

        dealBtn.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "Stand";

        pot = 40;
        betsText.text = "Bets: $" + pot;

        // OLD:
        // player.AdjustMoney(-20);

        // NEW: use BlackjackLevels so tables track profit/loss
        if (blackjackLevels != null)
        {
            blackjackLevels.ApplyHandResult(-20);
        }

        cashText.text = "$" + player.GetMoney();
    }

    public void HitClicked()
    {
        LastButtonPressed = LastButtonPressedType.Hit;

        if (player.cardIndex <= 10)
        {
            player.GetCard();
            scoreText.text = "Hand: " + player.handValue;
            hitBtn.gameObject.SetActive(false);
            endBtn.gameObject.SetActive(true);
        }
    }

    public void OnEndTurn()
    {
        if (player.handValue > 20) RoundOver();
        {
            hitBtn.gameObject.SetActive(true);
            endBtn.gameObject.SetActive(false);

        }
    }

    public void StandClicked()
    {
        LastButtonPressed = LastButtonPressedType.Stand;

        standClicks++;
        if (standClicks > 1) RoundOver();
        HitDealer();
        standBtnText.text = "Call";
    }

    public void HitDealer()
    {
        while (dealer.handValue < 16 && dealer.cardIndex < 10)
        {
            dealer.GetCard();
            dealerScoreText.text = "Hand: " + dealer.handValue;
            if (dealer.handValue > 20) RoundOver();
        }
    }

    public void RoundOver()
    {
        bool playerBust = player.handValue > 21;
        bool dealerBust = dealer.handValue > 21;
        bool player21 = player.handValue == 21;
        bool dealer21 = dealer.handValue == 21;

        if (standClicks < 2 && !playerBust && !dealerBust && !player21 && !dealer21) return;
        bool roundOver = true;

        if (playerBust && dealerBust)
        {
            mainText.text = "All Bust: Bets returned";

            // OLD:
            // player.AdjustMoney(pot / 2);

            // NEW:
            if (blackjackLevels != null)
            {
                blackjackLevels.ApplyHandResult(pot / 2);
            }
        }
        else if (playerBust || (!dealerBust && dealer.handValue > player.handValue))
        {
            mainText.text = "Dealer wins!";
            // Player already paid the bet(s), no extra money change here.
        }
        else if (dealerBust || player.handValue > dealer.handValue)
        {
            mainText.text = "You win!";

            // OLD:
            // player.AdjustMoney(pot);

            // NEW:
            if (blackjackLevels != null)
            {
                blackjackLevels.ApplyHandResult(pot);
            }
        }
        else if (player.handValue == dealer.handValue)
        {
            mainText.text = "Push: Bets returned";

            // OLD:
            // player.AdjustMoney(pot / 2);

            // NEW:
            if (blackjackLevels != null)
            {
                blackjackLevels.ApplyHandResult(pot / 2);
            }
        }
        else
        {
            roundOver = false;
        }

        if (roundOver)
        {
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            cashText.text = "$" + player.GetMoney();
            standClicks = 0;
        }
    }

    public void BetClicked()
    {
        Text newBet = betBtn.GetComponentInChildren(typeof(Text)) as Text;
        int intBet = int.Parse(newBet.text.Remove(0, 1));

        // OLD:
        // player.AdjustMoney(-intBet);

        // NEW:
        if (blackjackLevels != null)
        {
            blackjackLevels.ApplyHandResult(-intBet);
        }

        cashText.text = "$" + player.GetMoney();
        pot += (intBet * 2);
        betsText.text = "Bets: $" + pot;
    }
}

