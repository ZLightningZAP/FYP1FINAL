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
            5000,
            2000,
            2000,
            100,
            300,
        };

    private static int currentScore;
    private static float Addition;
    private static int Multiplier;

    public static int CurrentScore { get { return currentScore; } }
    public static int CurrentMultiplier { get { return Multiplier; } }

    // Use this for initialization
    private void Start()
    {
        Multiplier = 1;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public static void AddCurrentScore(ScoreType score)
    {
        currentScore += scores[(int)score] * Multiplier;
    }

    public static void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public static void Multiply()
    {
        Addition += 0.05f;
        if (Addition >= 1)
        {
            Multiplier += 1;
            Addition = 0;
        }
    }

    public static void ResetMultiplier()
    {
        Multiplier = 1;
    }
}