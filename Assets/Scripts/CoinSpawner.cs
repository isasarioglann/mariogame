using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner instance;

    public GameObject coinPrefab;
    public Transform[] spawnPoints; // Coinlerin çýkabileceði noktalar
    public float spawnInterval = 2f; // Her 2 saniyede bir coin oluþtur
    public float coinLifetime = 3f; // Coin 3 saniye sonra yok olacak

 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCoinsContinuously());
    }
    IEnumerator SpawnCoinsContinuously()
    {
        while (true)
        {
            SpawnCoin(); // Yeni coin oluþtur
            yield return new WaitForSeconds(spawnInterval); // 2 saniye bekle
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCoin()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length); // Rastgele bir nokta seç
        GameObject newCoin = Instantiate(coinPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        Destroy(newCoin, coinLifetime); // Coin 3 saniye sonra yok olacak
    }
}
