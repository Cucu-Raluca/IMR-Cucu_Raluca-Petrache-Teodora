using UnityEngine;
using TMPro;

public class TargetScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public ParticleSystem hitParticles;

    private int totalScore = 0;

    private void Start()
    {
        scoreText.text = "Score: 0";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Ball")
        {
            return;
        }

        float distanceFromCenter = Vector3.Distance(
            transform.position,
            other.transform.position
        );
        Debug.Log("Distanta fata de centru: " + distanceFromCenter);
        int points = 0;

        if (distanceFromCenter < 0.8f)
        {
            points = 10;
        }
        else if (distanceFromCenter < 1.0f)
        {
            points = 5;
        }
        else
        {
            points = 1;
        }

        totalScore = totalScore + points;

        scoreText.text = "Score: " + totalScore;

        if (hitParticles != null)
        {
            hitParticles.Play();
        }

        Debug.Log("Points: " + points);
    }
}