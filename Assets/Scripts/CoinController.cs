using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour
{
    public int scoreValue = 1; // Her coin 1 puan kazandýrýr.
    private bool isCollected = false; // Coinin bir kez toplanmasýný saðlar.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected) // Eðer karakter coine deðerse ve coin toplanmamýþsa
        {
            isCollected = true; // Coin'in tekrar toplanmasýný engelle
            gameObject.SetActive(false); // Coin'i görünmez yap
            GameManager.instance.AddScore(scoreValue); // Skoru artýr
            StartCoroutine(SpawnNewCoinWithDelay()); // Yeni coin oluþtur
            Destroy(gameObject, 0.1f); // Biraz bekleyip coin'i yok et
        }
    }

    IEnumerator SpawnNewCoinWithDelay()
    {
        yield return new WaitForSeconds(1f); // 1 saniye gecikmeli oluþtur
        CoinSpawner.instance.SpawnCoin();
    }
}
