using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public enum ScoreType
    {
        EnemyKill,
        BossKill,
        MissileDestroyed,
        ExitBonus,
        BodyShot,
        TopShot,
    }

    private static int[] scores =
        {
            1000,
            3000,
            2000,
            2000,
            100,
            300,
        };

    private static int currentScore;

    // Getters
    public static int CurrentScore { get { return currentScore; } }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public static void AddCurrentScore(ScoreType score)
    {
        currentScore += scores[(int)score];
    }

    public static void ResetCurrentScore()
    {
        currentScore = 0;
    }
}