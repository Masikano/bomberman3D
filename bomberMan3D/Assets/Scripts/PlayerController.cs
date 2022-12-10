using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3;
    private Vector3 _newPos;
    [SerializeField]
    private GameObject _bombPrefab;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int x = Mathf.RoundToInt( transform.position.x);
            //int y = Mathf.RoundToInt(transform.position.y);
            int z = Mathf.RoundToInt(transform.position.z);
            Vector3 bombPos = new Vector3(x, transform.position.y, z);
            Instantiate(_bombPrefab,bombPos,Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {
        _newPos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //transform.Translate(_newPos * speed * Time.deltaTime);
        _rb.velocity = _newPos * speed;
        
    }

    
}
