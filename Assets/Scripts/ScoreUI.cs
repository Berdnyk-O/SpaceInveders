using Assets.Scripts;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text ScoreText;

    private float _score = 0;

    private void OnEnable()
    {
        Actions.OnEnemyKilled += UpdateScore;
    }
    
    private void OnDestroy()
    {
        Actions.OnEnemyKilled -= UpdateScore;
    }

    void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(float score)
    {
        _score += score;
        ScoreText.text = _score.ToString();
    }
}
