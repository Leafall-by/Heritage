using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudMove : MonoBehaviour
{
    private int _lifeTime = 100;

    private Coroutine _coroutine;

    private int _liveSeconds = 0;
    private bool _direction = true;

    private void Start()
    {
        StartCoroutine(TickLife());
    }

    private void Update()
    {
        if (_coroutine != null)
        {
            return;
        }

        int dir = _direction ? -1 : 1;
        _coroutine = StartCoroutine(Move(dir));
    }

    private IEnumerator TickLife()
    {
        for (; _liveSeconds <= _lifeTime; _liveSeconds++)
        {
            yield return new WaitForSeconds(1f);
        }
        
        Destroy(gameObject);   
    }
    
    private IEnumerator Move(int dir)
    {
        float randSpeed = Random.Range(1f, 1.6f);
        Vector3 direction = dir == -1 ? Vector3.left : Vector3.right;
        
        transform.Translate(direction * (Time.deltaTime * randSpeed * 120));
        yield return new WaitForSeconds(.01f);
        _coroutine = null;
    }
}
