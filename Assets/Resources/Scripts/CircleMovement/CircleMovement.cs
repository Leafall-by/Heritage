using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 axis;
    [SerializeField] private float speed;
    [SerializeField] private CircleCollider2D collider;

    [HideInInspector] public UnityEvent<bool> OnClick;
    
    private bool inZone;

    private Coroutine axisCoroutine;
    [SerializeField] private int mindelay;
    [SerializeField] private int maxdelay;
    
    void Update()
    {
        transform.RotateAround(target.transform.position, axis, Time.deltaTime * speed);
        
        if (Input.GetMouseButtonDown(0) && inZone)
        {
            OnClick.Invoke(true);
        }
        else if(Input.GetMouseButtonDown(0) && !inZone)
        {
            OnClick.Invoke(false);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randAng = Random.Range(0, Mathf.PI * 2);
        return new Vector2(Mathf.Cos(randAng) * collider.radius, Mathf.Sin(randAng) * collider.radius);
    }

    private float GetRotationZ()
    {
        Vector3 difference = target.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        return rotZ;
    }

    private void OnEnable()
    {
        Vector3 vector = GetRandomPosition();
        transform.localPosition = vector;
        
        transform.rotation = Quaternion.Euler(0f, 0f, GetRotationZ());

        axisCoroutine = StartCoroutine(ChangeAxisCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(axisCoroutine);
    }

    private IEnumerator ChangeAxisCoroutine()
    {
        int delay = Random.Range(mindelay, maxdelay+1);

        yield return new WaitForSeconds(delay);
        axis *= -1;
        axisCoroutine = StartCoroutine(ChangeAxisCoroutine());
    }

    public void SetInRedZone(bool isInZone)
    {
        inZone = isInZone;
    }
}
