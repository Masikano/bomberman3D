using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    public GameObject firePrefab;
    [SerializeField]
    private float _timeToExplosion;
    [SerializeField]
    private int _fireForce;
    private IEnumerator corutine;
    //[SerializeField]
    //private float _fireSpawnDelay;
    
    private DistanceInDirection _distanceInDirection;

    private void Start()
    {
        _distanceInDirection = BombDistanceCounter.instance.GetDistansAllDirections(gameObject, _fireForce);
        Debug.Log("forward: " + _distanceInDirection.forward);
        Debug.Log("back: " + _distanceInDirection.back);
        Debug.Log("left: " + _distanceInDirection.left);
        Debug.Log("right: " + _distanceInDirection.right);
    }
    private void Update()
    {
        Invoke("BlowUp", _timeToExplosion);
    }

    private void BlowUp()
    {
        Instantiate(firePrefab, transform.position, Quaternion.identity);
        
        for(int i = 0; i < _fireForce; i++)
        {
            //corutine = SpawnFire(i, _fireSpawnDelay);
            //StartCoroutine(corutine);
            SpawnFire(i);
        }
        Destroy(gameObject);
    }
    //private void SpawnFire(int offset)
    private void SpawnFire(int offset)
    {
        //yield return new WaitForSeconds(delay);
        

        if(offset < _distanceInDirection.forward)
            Instantiate(firePrefab, transform.position + Vector3.forward * offset, Quaternion.identity);
        if (offset < _distanceInDirection.back)
            Instantiate(firePrefab, transform.position - Vector3.forward * offset, Quaternion.identity);
        if (offset < _distanceInDirection.right)
            Instantiate(firePrefab, transform.position + Vector3.right * offset, Quaternion.identity);
        if (offset < _distanceInDirection.left)
            Instantiate(firePrefab, transform.position - Vector3.right * offset, Quaternion.identity);
    }
}
