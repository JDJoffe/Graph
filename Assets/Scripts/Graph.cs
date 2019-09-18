using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graph : MonoBehaviour
{
    public Transform pointPrefab;


    [Range(10, 100)]
    public int resolution = 10;
    [Header("Position functions")]
    public GraphFunctionNamePosX functionPosX;
    public GraphFunctionNamePosY functionPosY;
    public GraphFunctionNamePosZ functionPosZ;
    [Header("Rotation functions")]
    public GraphFunctionNameRotX functionRotX;
    public GraphFunctionNameRotY functionRotY;
    public GraphFunctionNameRotZ functionRotZ;

    public Transform[] points;
    static GraphFunction[] functions =
       {
        null,
        SineFunction,
        MultiSineFunction,
        CosFunction,
        MultiCosFunction,
        TanFunction,
        MultiTanFunction,
       };
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
            //change position axis
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x * position.x;
            // position.z = (position.y) * (position.x + step);
            //rotation axis change
            rotation.x = i;
            rotation.y = i;
            rotation.z = i;
            //apply new changes to local 
            point.localPosition = position;
            point.localScale = scale;
            point.localRotation = rotation;
            //set to parent
            point.SetParent(transform, false);
            points[i] = point;
        }
    }
    // get an array instance, make array of functions so you can pick which one to run

    private void Update()
    {
        float t = Time.time;


        // declared delegate so it can be invoked like a method
        GraphFunction posX = functions[(int)functionPosX];
        GraphFunction posY = functions[(int)functionPosY];
        GraphFunction posZ = functions[(int)functionPosZ];

        GraphFunction rotX = functions[(int)functionRotX];
        GraphFunction rotY = functions[(int)functionRotY];
        GraphFunction rotZ = functions[(int)functionRotZ];

        // for each object change their position, rotation and scale 
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            Quaternion rotation = point.localRotation;
            //position
            // X
            if (posX != null) position.x = posX(position.y, t);
            // Y
            if (posY != null) position.y = posY(position.x, t);
            // Z
            if (posZ != null) position.z = posZ(position.y, t);
            //rotation  
            // X
            if (rotX != null) rotation.x = rotX(position.x, t);
            // Y
            if (rotY != null) rotation.y = rotY(position.y, t);
            // Z
            if (rotZ != null) rotation.z = rotZ(position.z, t);


            // apply changes
            point.localPosition = position;
            point.localRotation = rotation;
        }
    }
    //Sin Cos and Tan functions to modify rotation, scale and position in update
    #region Sin
    static float SineFunction(float x, float t)
    {
        return Mathf.Sin(Mathf.PI * (x + t));
    }
    static float MultiSineFunction(float x, float t)
    {
        float sine = Mathf.Sin(Mathf.PI * (x + t));
        sine += Mathf.Sin(2f * Mathf.PI * (x + 2f * t)) / 2f;
        sine *= 2f / 3f;
        return sine;
    }
    #endregion
    #region Cos
    static float CosFunction(float x, float t)
    {
        return Mathf.Cos(Mathf.PI * (x + t));
    }
    static float MultiCosFunction(float x, float t)
    {
        float cosine = Mathf.Cos(Mathf.PI * (x + t));
        cosine += Mathf.Cos(2f * Mathf.PI * (x + 2f * t)) / 2f;
        cosine *= 2f / 3f;
        return cosine;
    }
    #endregion
    #region Tan
    static float TanFunction(float x, float t)
    {
        return Mathf.Tan(Mathf.PI * (x + t));
    }
    static float MultiTanFunction(float x, float t)
    {
        float tangent = Mathf.Tan(Mathf.PI * (x + t));
        tangent += Mathf.Tan(2f * Mathf.PI * (x + 2f * t)) / 2f;
        tangent *= 2f / 3f;
        return tangent;
    }
    #endregion
}
