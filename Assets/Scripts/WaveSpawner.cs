using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform SpawnPoint;
    public Text waveCountText;

    public float timeBetweenWaves = 5f;
    private float countDown = 2f;
    private int waveIndex = 0;

    private float timer = 0.6f;

	// Use this for initialization
	void Update () {
	    if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }


        countDown -= Time.deltaTime;
        waveCountText.text = Mathf.Round(countDown).ToString();


    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incomming");
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
