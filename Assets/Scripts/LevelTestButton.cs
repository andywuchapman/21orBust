using UnityEngine;

public class LevelTestButton : MonoBehaviour
{
    public BlackjackLevels levels;

    public void Win100()
    {
        if (levels != null)
        {
            levels.OnHandFinished(100);
        }
    }

    public void Lose50()
    {
        if (levels != null)
        {
            levels.OnHandFinished(-50);
        }
    }
}

