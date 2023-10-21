using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private const string Score = "Score: ";

    [SerializeField] private Destroyer _destroyer;
    [SerializeField] private TMP_Text _scoreDisplay;

    private int _score;

    private void OnEnable()
    {
        _destroyer.EnemyDestroyed += OnEnemyDestroyed;
    }

    private void OnDisable()
    {
        _destroyer.EnemyDestroyed -= OnEnemyDestroyed;
    }

    private void OnEnemyDestroyed(int score)
    {
        _score += score;
        _scoreDisplay.text = $"{Score}{_score}";
    }
}
