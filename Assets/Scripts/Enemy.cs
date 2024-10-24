using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
        InvokeRepeating("TryShoot", 2,2);
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

    bool CanShoot()
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
}
