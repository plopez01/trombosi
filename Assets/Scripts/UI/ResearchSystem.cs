using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResearchSystem : MonoBehaviour
{
    private IPManager ipManager;

    [SerializeField] private GameManager manager;
    [SerializeField] private QuizHolder quiz;
    [SerializeField] private GameObject button;
    [SerializeField] private Image progressImg;
    [SerializeField] private int researchCost;
    [SerializeField] private Vector2 randomPoints;

    float timeSpent = 0;

    [SerializeField] float timeToResearch;

    bool researching = false;
    // Start is called before the first frame update
    void Start()
    {
        ipManager = GetComponent<IPManager>();
    }

    public void StartResearch()
    {
        researching = true;
        if (Random.Range(0f, 1f) > 0.5) quiz.openQuiz(BonusPoints, LosePoints);
        button.SetActive(false);
    }

    void BonusPoints()
    {
        ipManager.points += 2;
    }

    void LosePoints()
    {
        ipManager.points -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (researching)
        {
            float progress = timeSpent / timeToResearch;
            timeSpent += Time.unscaledDeltaTime;
            progressImg.fillAmount = progress;
            if (progress >= 1)
            {
                manager.UI.Money -= researchCost;
                researching = false;
                timeSpent = 0;
                button.SetActive(true);
                progressImg.fillAmount = 0;
                ipManager.points += (int) Random.Range(randomPoints.x, randomPoints.y+1);
            }
        }
    }
}
