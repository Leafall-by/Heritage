using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _clouds;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Weather _weather;
    private const float SPAWN_CLOUD_TIME = 16f;
    private int _lastSpawnIndex = -1;
    private int _lastSpawnObjectIndex = -1;

    private Coroutine _coroutine;

    private void Update()
    {
        if (_coroutine == null && _weather.IsRain == false)
        {
            _coroutine = StartCoroutine(SpawnCloud());
        }
    }


    
    private IEnumerator SpawnCloud()
    {
        int num = Random.Range(0, _clouds.Length);
        while (_lastSpawnObjectIndex == num)
        {
            num = Random.Range(0, _clouds.Length);
        }

        _lastSpawnObjectIndex = num;
        
        int randomSpawnPoint = Random.Range(0, _spawnPoints.Length);
        while (_lastSpawnIndex == randomSpawnPoint)
        {
            randomSpawnPoint = Random.Range(0, _spawnPoints.Length);
        }

        _lastSpawnIndex = randomSpawnPoint;
        
        GameObject cloud = Instantiate(_clouds[num], _spawnPoints[randomSpawnPoint]);
        cloud.GetComponent<CloudMove>().SetWeather(_weather);
        var image = cloud.GetComponent<Image>();
        
        var imageColor = image.color;
        imageColor.a = Random.Range(0.8f, 1f);
        image.color = imageColor;
        
        yield return new WaitForSeconds(SPAWN_CLOUD_TIME);
        _coroutine = null;
    }

}
