using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public struct DistanceInDirection
{
    public float forward;
    public float back;
    public float right;
    public float left;
}
public class BombDistanceCounter : MonoBehaviour
{
    public static BombDistanceCounter instance;

    
    private List<Ray> _rays = new List<Ray>();    
    private DistanceInDirection _distance;
    private float _prevDistance;
    private void Awake()
    {
        instance = this;
    }
    private float GetDistanceInDirection(Ray ray)
    {        
        RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, _prevDistance);
        int currentDistance = (int)Math.Ceiling(_prevDistance);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            GameObject currentObject = hit.collider.gameObject;
            if (currentObject.GetComponent<IndestructibleWall>() || currentObject.GetComponent<DestructibleWall>())
            {
                currentDistance = (int)Math.Ceiling(Mathf.Min(currentDistance, hit.distance));
            }
        }
        //Debug.DrawRay(ray.origin, ray.direction, Color.red);
        return currentDistance;   
    }

    public DistanceInDirection GetDistansAllDirections(GameObject bomb, float prevDistance)
    {
        _prevDistance = prevDistance;
        _distance.forward = GetDistanceInDirection(new Ray(bomb.transform.position, Vector3.forward));
        _distance.back = GetDistanceInDirection(new Ray(bomb.transform.position, -Vector3.forward));
        _distance.right = GetDistanceInDirection(new Ray(bomb.transform.position, Vector3.right));
        _distance.left = GetDistanceInDirection(new Ray(bomb.transform.position, -Vector3.right));       
        return _distance;
    }
    
    
    
    
}
