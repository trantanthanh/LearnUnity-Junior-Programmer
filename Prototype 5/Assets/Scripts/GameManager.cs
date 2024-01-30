using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeIntervalSpawn = 1f;
    public TextMeshProUGUI scoreTMP;
    public List<GameObject> targets;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeIntervalSpawn);
            int randomIdx = Random.Range(0, targets.Count);
            Instantiate(targets[randomIdx]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score < 0) score = 0;
        scoreTMP.text = "Score : " + score;
    }
}
