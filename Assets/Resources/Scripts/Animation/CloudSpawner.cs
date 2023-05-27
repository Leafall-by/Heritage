using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _clouds;
    [SerializeField] private GameObject _spawnPoint;
    private const float SPAWN_CLOUD_TIME = 16f;

    private Coroutine _coroutine;

    private void Update()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(SpawnCloud());
        }
    }

    private IEnumerator SpawnCloud()
    {
        int num = Random.Range(0, _clouds.Length - 1);

        Vector3 vec = _spawnPoint.transform.position;

        vec.y += Random.Range(-150f, 0f);
        
        GameObject cloud = Instantiate(_clouds[num], vec,  Quaternion.identity);

        var image = cloud.GetComponent<Image>();
        
        var imageColor = image.color;
        imageColor.a = Random.Range(0.8f, 1f);
        image.color = imageColor;
        
        cloud.transform.SetParent(_spawnPoint.transform);
        yield return new WaitForSeconds(SPAWN_CLOUD_TIME);
        _coroutine = null;
    }

}
