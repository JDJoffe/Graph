using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graph : MonoBehaviour
{
    public Transform pointPrefab;


    [Range(10, 100)]
    public int resolution = 10;
    [Header("Position functions")]
    public GraphFunctionName functionName;
    // public GraphFunctionNamePosX functionPosX;
    // public GraphFunctionNamePosY functionPosY;
    // public GraphFunctionNamePosZ functionPosZ;
    // [Header("Rotation functions")]
    // public GraphFunctionNameRotX functionRotX;
    // public GraphFunctionNameRotY functionRotY;
    // public GraphFunctionNameRotZ functionRotZ;

    public Transform[] points;
    static GraphFunction[] functions =
       {
        null,
        SineFunction,
        MultiSineFunction,
        Sine2D,
        MultiSine2D,
        CosFunction,
        MultiCosFunction,
         Cos2D,
        MultiCos2D,
        TanFunction,
        MultiTanFunction,
         Tan2D,
        MultiTan2D,
        SinRipple,
        Cylinder,
        Sphere,
        Torus,
       };
       // rotation graphfunction
       #region old
    //    static GraphFunctionQ[] functionsQ =
    //    {
    //        null,
    //        SineFunction,
    //     MultiSineFunction,
    //     Sine2D,
    //     MultiSine2D,
    //     CosFunction,
    //     MultiCosFunction,
    //      Cos2D,
    //     MultiCos2D,
    //     TanFunction,
    //     MultiTanFunction,
    //      Tan2D,
    //     MultiTan2D,
    //     SinRipple,
    //    }
    #endregion
    private void Awake()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
      //  Vector3 position = Vector3.zero;
       // Quaternion rotation = Quaternion.Euler(1, 1, 1);
        points = new Transform[resolution * resolution];
        #region old
        // // increments i then returns it
        // // ++i;
        // // returns i then increments it
        // // i++;
        // for (int i = 0,z=0; z < resolution; z++)
        // {
        //      position.z = (z + 0.5f) * step - 1f;
        //    for(int x = 0; x < resolution; x++,i++)
        //    {
        //     // local transform = new instantiated prefab
        //     Transform point = Instantiate(pointPrefab);
        //     //change position axis
        //     position.x = (x + 0.5f) * step - 1f;
           
        //     position.y = position.x * position.x;
        //     // position.z = (position.y) * (position.x + step);
        //     //rotation axis change
        //     rotation.x = i;
        //     rotation.y = i;
        //     rotation.z = i;
        //     //apply new changes to local 
        //     point.localPosition = position;
        //     point.localScale = scale;
        //     point.localRotation = rotation;
        //     //set to parent
        //     point.SetParent(transform, false);
        //     points[i] = point;
        //    }
        // }
        #endregion
        for(int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            point.localScale = scale;
            point.SetParent(transform,false);
            points[i] = point;
        }
       
    }
    // get an array instance, make array of functions so you can pick which one to run

    private void Update()
    {
        float t = Time.time;


        // declared delegate so it can be invoked like a method
        GraphFunction f = functions[(int)functionName];

        // these no longer work
        #region old
        // GraphFunction posX = functions[(int)functionPosX];
        // GraphFunction posY = functions[(int)functionPosY];
        // GraphFunction posZ = functions[(int)functionPosZ];

        // GraphFunctionQ rotX = functions[(int)functionRotX];
        // GraphFunctionQ rotY = functions[(int)functionRotY];
        // GraphFunctionQ rotZ = functions[(int)functionRotZ];

        // for each object change their position, rotation and scale 
        // for (int i = 0; i < points.Length; i++)
        // {
        //     Transform point = points[i];
        //     Vector3 position = point.localPosition;
        //     Quaternion rotation = point.localRotation;
        //     //position
        //     // X
        //     if (posX != null) position.x = posX(position.y, t, position.z);
        //     // Y
        //     if (posY != null) position.y = posY(position.x, t,position.z);
        //     // Z
        //     if (posZ != null) position.z = posZ(position.y, t, position. z);
        //     //rotation  
        //     // X
        //     if (rotX != null) rotation.x = rotX(position.x, t, position.z);
        //     // Y
        //     if (rotY != null) rotation.y = rotY(position.y, t,position.z);
        //     // Z
        //     if (rotZ != null) rotation.z = rotZ(position.z, t,position.z);
        //     // apply changes
        //     point.localPosition = position;
        //     point.localRotation = rotation;
        // }
#endregion
        // 
        float step = 2f / resolution;
        for(int i = 0, z = 0; z < resolution; z ++)
        {
            float v  = (z + 0.5f) * step - 1f;
            for(int x = 0; x < resolution; x ++,i++)
            {
                float u = (x + 0.5f) * step - 1f;
                points[i].localPosition = f(u,v,t);
                //points[i].localPosition = posX(u,t,v);
                 //points[i].localPosition = posY(u,t,v);
                  //points[i].localPosition = posZ(u,t,v);
                  
                 // points[i].localRotation = rotX(u,t,v);
                 //points[i].localRotation = rotY(u,t,v);
                // points[i].localRotation = rotZ(u,t,v);
            }
        }
    }
    const float pi = Mathf.PI;
    //Sin Cos and Tan functions to modify rotation, scale and position in update
    // cannot modify specific dimensions with these anymore, use the "function name" option in inspector
    #region Sin
    static /*float*/ Vector3 SineFunction(float u, float v, float t)
    {
       // return Mathf.Sin(pi * (x + t));
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + t ));
        p.z = v;
        return p;
    }
    static /*float*/ Vector3 MultiSineFunction(float u, float v, float t)
    {
        // float sine = Mathf.Sin(pi * (x + t));
        // sine += Mathf.Sin(2f * pi * (x + 2f * t)) / 2f;
        // sine *= 2f / 3f;
        // return sine;
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi* (u + t));
        p.y += Mathf.Sin(2f*pi*(u + 2f * t)) *0.5f;
        p.y *= 2f/3f;
        p.z = v;
        return p;
    }
    static /*float*/ Vector3 Sine2D(float u, float v, float t)
    {
      //  return Mathf.Sin(pi*(x + t + z));
    //   float y = Mathf.Sin(pi *(x + t));
    //   y += Mathf.Sin(pi * ( z + t));
    //   // do this instead of y /= 2 because multiplication is faster
    //   y *= 0.5f;
    //   return y;
    Vector3 p;
    p.x = u;
    p.y = Mathf.Sin(pi * (u + t));
    p.y += Mathf.Sin(pi * (v + t));
    p.y *= 0.5f;
    p.z = v;
    return p;
    }
    static /*float*/ Vector3 MultiSine2D(float u, float v, float t)
    {
        // float y = 4f * Mathf.Sin(pi*(x + z + t * 0.5f));
        // y += Mathf.Sin(pi *(x+t));
        // y += Mathf.Sin(2f * pi * (z + 2f * t)) * 0.5f;
        // y *= 1f/5.5f;
        // return y;
           Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi *(u+t));
        p.y += Mathf.Sin(2f * pi * (u + 2f * t)) * 0.5f;
        p.y *= 1f/5.5f;
        p.z = v;
        return p;
    }
    #endregion
    #region Cos
    static /*float*/ Vector3 CosFunction(float u, float v, float t)
    {
       // return Mathf.Cos(pi * (x + t));
         Vector3 p;
        p.x = u;
        p.y = Mathf.Cos(pi * (u + t ));
        p.z = v;
        return p;
    }
    static /*float*/ Vector3 MultiCosFunction(float u, float v, float t)
    {
        // float cosine = Mathf.Cos(pi * (x + t));
        // cosine += Mathf.Cos(2f * pi * (x + 2f * t)) / 2f;
        // cosine *= 2f / 3f;
        // return cosine;
         Vector3 p;
        p.x = u;
        p.y = Mathf.Cos(pi* (u + t));
        p.y += Mathf.Cos(2f*pi*(u + 2f * t)) *0.5f;
        p.y *= 2f/3f;
        p.z = v;
        return p;
    }
     static /*float*/ Vector3 Cos2D(float u, float v, float t)
    {
    //   //  return Mathf.Sin(pi*(x + t + z));
    //   float y = Mathf.Cos(pi *(x + t));
    //   y += Mathf.Cos(pi * ( z + t));
    //   // do this instead of y /= 2 because multiplication is faster
    //   y *= 0.5f;
    //   return y;
     Vector3 p;
    p.x = u;
    p.y = Mathf.Cos(pi * (u + t));
    p.y += Mathf.Cos(pi * (v + t));
    p.y *= 0.5f;
    p.z = v;
    return p;
    }
    static /*float*/ Vector3 MultiCos2D(float u, float v, float t)
    {
        // float y = 4f * Mathf.Cos(pi*(x + z + t * 0.5f));
        // y += Mathf.Cos(pi *(x+t));
        // y += Mathf.Cos(2f * pi * (z + 2f * t)) * 0.5f;
        // y *= 1f/5.5f;
        // return y;
          Vector3 p;
        p.x = u;
        p.y = Mathf.Cos(pi *(u+t));
        p.y += Mathf.Cos(2f * pi * (u + 2f * t)) * 0.5f;
        p.y *= 1f/5.5f;
        p.z = v;
        return p;
    }
    #endregion
    #region Tan
    static /*float*/ Vector3 TanFunction(float u, float v, float t)
    {
        // return Mathf.Tan(pi * (x + t));
          Vector3 p;
        p.x = u;
        p.y = Mathf.Tan(pi * (u + t ));
        p.z = v;
        return p;       
    }
    static /*float*/ Vector3 MultiTanFunction(float u, float v, float t)
    {
        // float tangent = Mathf.Tan(pi * (x + t));
        // tangent += Mathf.Tan(2f * pi * (x + 2f * t)) / 2f;
        // tangent *= 2f / 3f;
        // return tangent;
         Vector3 p;
        p.x = u;
        p.y = Mathf.Tan(pi* (u + t));
        p.y += Mathf.Tan(2f*pi*(u + 2f * t)) *0.5f;
        p.y *= 2f/3f;
        p.z = v;
        return p;
    }
     static /*float*/ Vector3 Tan2D(float u, float v, float t)
    {
    //   //  return Mathf.Sin(pi*(x + t + z));
    //   float y = Mathf.Tan(pi *(x + t));
    //   y += Mathf.Tan(pi * ( z + t));
    //   // do this instead of y /= 2 because multiplication is faster
    //   y *= 0.5f;
    //   return y;
     Vector3 p;
    p.x = u;
    p.y = Mathf.Tan(pi * (u + t));
    p.y += Mathf.Tan(pi * (v + t));
    p.y *= 0.5f;
    p.z = v;
    return p;
    }
    static /*float*/ Vector3 MultiTan2D(float u, float v, float t)
    {
        // float y = 4f * Mathf.Tan(pi*(x + z + t * 0.5f));
        // y += Mathf.Tan(pi *(x+t));
        // y += Mathf.Tan(2f * pi * (z + 2f * t)) * 0.5f;
        // y *= 1f/5.5f;
        // return y;
          Vector3 p;
        p.x = u;
        p.y = Mathf.Tan(pi *(u+t));
        p.y += Mathf.Tan(2f * pi * (u + 2f * t)) * 0.5f;
        p.y *= 1f/5.5f;
        p.z = v;
        return p;
    }
    #endregion
    #region extrafunctionsthatarecool
    // generate a ripple
    static /*float*/ Vector3 SinRipple(float u, float v, float t)
    {
    //     float d = Mathf.Sqrt(x * x + z * z);
    //     //float y = d;
    //    // float y = Mathf.Sin(pi * d);
    //    float y = Mathf.Sin (pi*( 4f * d - t));
    //     y /= 1f + 10f*d;
    //     return y;
     Vector3 p;
    float d = Mathf.Sqrt(u * u + v * v);
    p.x = u;
    p.y = Mathf.Sin(pi * (4f * d - t));
    p.y /= 1f + 10f * d;
    p.z = v;
    return p;
    }
    // generate a cylinder
    static Vector3 Cylinder(float u, float v, float t)
    {
        Vector3 p;
       // float r = 1f + Mathf.Sin(6*pi*u)*0.2f;
      // float r = 1 + Mathf.Sin(2f * pi * z)*0.2f;
      float r = 0.8f +  Mathf.Sin(pi*(6f*u + 2f *v + t))*0.2f;
        p.x =r* Mathf.Sin(pi*u);
        p.y = v;
        p.z =r* Mathf.Cos(pi * u);
        return p;
    }
    // generate a sphere
    static Vector3 Sphere (float u, float v, float t)
    {
        Vector3 p;
        // float r = Mathf.Cos(pi*0.5f*v);
        // p.x = r * Mathf.Sin(pi * u);
        // p.y = Mathf.Sin(pi * 0.5f * v);
        // p.z = r*Mathf.Cos(pi*u);
        float r = 0.8f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
        r += Mathf.Sin(pi * (4f * v + t)) * 0.1f;
        float s = r * Mathf.Cos(pi * 0.5f * v);
        p.x = s * Mathf.Sin(pi * u);
        p.y = r * Mathf.Sin(pi * 0.5f * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }
    // generate a torus
    static Vector3 Torus (float u, float v, float t)
    {
        Vector3 p;
       // float r1 = 1;
        //float r2 = 0.5f;
        float r1 =0.65f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
        float r2 = 0.2f + Mathf.Sin(pi * (4f * v + t)) * 0.05f;
        float s = r2 *Mathf.Cos(pi* v) + r1;
        p.x = s * Mathf.Sin(pi * u);
        p.y = r2 * Mathf.Sin(pi  * v);
        p.z = s*Mathf.Cos(pi* u);
        return p;
    }
    #endregion
}
