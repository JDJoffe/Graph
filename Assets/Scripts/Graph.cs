using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(10, 100)]
    // public List<Transform> pointPrefabs;
    public int resolution = 10;
    public Transform[] points;
    private void Awake()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;
        Quaternion rotation = Quaternion.Euler(1, 1, 1);
        points = new Transform[resolution];
        // increments i then returns it
        // ++i;
        // returns i then increments it
        // i++;
        for (int i = 0; i < points.Length; i++)
        {
            // local transform = new instantiated prefab
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x * position.x;
            position.z = (position.y + step) * (position.x + step);
            rotation.x = i * step;
            rotation.y = i * step;
            rotation.z = i * step;
            point.localPosition = position;
            point.localScale = scale;
            point.localRotation = rotation;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }
    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            Quaternion rotation = point.localRotation;
            // X
            // position.x = Mathf.Sin(Mathf.PI * (position.z + Time.time)) ; // Sin
            // position.x = Mathf.Cos(Mathf.PI * (position.z + Time.time)) ; // Cos
            // position.x = Mathf.Tan(Mathf.PI * (position.z + Time.time)) ; // Tan
            // Y

            // position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time)); // Sin 
            // position.y = Mathf.Cos(Mathf.PI * (position.x + Time.time)); // Cos 
            // position.y = Mathf.Tan(Mathf.PI * (position.x + Time.time)); // Tan 

            // Z
            // position.z = Mathf.Sin(Mathf.PI * (position.y + Time.time)); // Sin
            // position.z = Mathf.Cos(Mathf.PI * (position.y + Time.time)); // Cos
            // position.z = Mathf.Tan(Mathf.PI * (position.y + Time.time)); // Tan

            rotation.x = i * position.x + Time.time;
            rotation.y = i * position.y + Time.time;
            rotation.z = i * position.z + Time.time;
            point.localPosition = position;
            point.localRotation = rotation;
        }
    }

}
