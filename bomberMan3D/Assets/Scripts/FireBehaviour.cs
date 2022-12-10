using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _fireDuration;
    void Start()
    {
        Destroy(gameObject, _fireDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<IndestructibleWall>())
        {
            Destroy(other.gameObject);
        }
        

    }
}
