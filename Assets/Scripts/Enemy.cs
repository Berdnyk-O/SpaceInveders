using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyableObject
{
    public float Healt = 10;
    public float Speed = 3;
    private float _currentSpeed = 3;

    public GameObject BulletPrefab;
    public Transform LaunchOffset;

    public Vector3 RelativePosition;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    void Start()
    {
        _currentSpeed = Speed;
        _startPosition = transform.position;
        _endPosition = transform.position+RelativePosition;
        InvokeRepeating("TryShoot", Random.Range(2,5), Random.Range(2, 5));
    }

    void Update()
    {
        if(_currentSpeed > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endPosition, Speed * Time.deltaTime);
            if(transform.position == _endPosition)
            {
                _endPosition = _startPosition;
                _startPosition = transform.position;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        _currentSpeed = 0;
        yield return new WaitForSeconds(1.5f);
        _currentSpeed = Speed;
    }

    private void TryShoot()
    {
        if(CanShoot())
        {
            Instantiate(BulletPrefab, LaunchOffset.position, LaunchOffset.rotation);
        }
        
    }

    private bool CanShoot()
    {
        Debug.Log("HI");
        Vector3 direction = -transform.up;

        RaycastHit hit;
        if (Physics.Raycast(LaunchOffset.position, direction, out hit, 4f))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.CompareTag("enemy"))
            {
                return false;
            }
        }

        return true;
    }

    public void TakeDamage(float damage)
    {
        Healt-=damage;
        if(Healt<=0)
        {
            Destroy(gameObject);
        }
    }
}
