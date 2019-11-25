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
        Sine2D,
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
        points = new Transform[resolution * resolution];
        // increments i then returns it
        // ++i;
        // returns i then increments it
        // i++;
        for (int i = 0,z=0; z < resolution; z++)
        {
             position.z = (z + 0.5f) * step - 1f;
           for(int x = 0; x < resolution; x++,i++)
           {
            // local transform = new instantiated prefab
            Transform point = Instantiate(pointPrefab);
            //change position axis
            position.x = (x + 0.5f) * step - 1f;
           
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
            if (posX != null) position.x = posX(position.y, t, position.z);
            // Y
            if (posY != null) position.y = posY(position.x, t,position.z);
            // Z
            if (posZ != null) position.z = posZ(position.y, t, position. z);
            //rotation  
            // X
            if (rotX != null) rotation.x = rotX(position.x, t, position.z);
            // Y
            if (rotY != null) rotation.y = rotY(position.y, t,position.z);
            // Z
            if (rotZ != null) rotation.z = rotZ(position.z, t,position.z);


            // apply changes
            point.localPosition = position;
            point.localRotation = rotation;
        }
    }
    const float pi = Mathf.PI;
    //Sin Cos and Tan functions to modify rotation, scale and position in update
    #region Sin
    static float SineFunction(float x, float t, float z)
    {
        return Mathf.Sin(pi * (x + t));
    }
    static float MultiSineFunction(float x, float t, float z)
    {
        float sine = Mathf.Sin(pi * (x + t));
        sine += Mathf.Sin(2f * pi * (x + 2f * t)) / 2f;
        sine *= 2f / 3f;
        return sine;
    }
    static float Sine2D(float x, float t, float z)
    {
      //  return Mathf.Sin(pi*(x + t + z));
      float y = Mathf.Sin(pi *(x + t));
      y += Mathf.Sin(pi * ( z + t));
      // do this instead of y /= 2 because multiplication is faster
      y *= 0.5f;
    }
    #endregion
    #region Cos
    static float CosFunction(float x, float t, float z)
    {
        return Mathf.Cos(pi * (x + t));
    }
    static float MultiCosFunction(float x, float t, float z)
    {
        float cosine = Mathf.Cos(pi * (x + t));
        cosine += Mathf.Cos(2f * pi * (x + 2f * t)) / 2f;
        cosine *= 2f / 3f;
        return cosine;
    }
    #endregion
    #region Tan
    static float TanFunction(float x, float t, float z)
    {
        return Mathf.Tan(pi * (x + t));
    }
    static float MultiTanFunction(float x, float t, float z)
    {
        float tangent = Mathf.Tan(pi * (x + t));
        tangent += Mathf.Tan(2f * pi * (x + 2f * t)) / 2f;
        tangent *= 2f / 3f;
        return tangent;
    }
    #endregion
}
