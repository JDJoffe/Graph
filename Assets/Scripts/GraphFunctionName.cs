using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All these enums are so i can select exactly what combination of functions i want to use in the inspector
public enum GraphFunctionName
{
         NULL,
// sin
    Sine,
    MultiSine,
     Sine2D,
     MultiSine2D,
     // cos
    Cos,
    MultiCos,
      Cos2D,
   MultiCos2D,
   // tan
    Tan,
    MultiTan,
       Tan2D,
   MultiTan2D,
   // extra
   SinRipple,
   Cylinder,
   Sphere,
    Torus
}
#region old
// public enum GraphFunctionNamePosX
// {
//        NULL,
// // sin
//     Sine,
//     MultiSine,
//      Sine2D,
//      MultiSine2D,
//      // cos
//     Cos,
//     MultiCos,
//       Cos2D,
//    MultiCos2D,
//    // tan
//     Tan,
//     MultiTan,
//        Tan2D,
//    MultiTan2D,
//    // extra
//    SinRipple,
//     Cylinder,
//    Sphere,
//     Torus
  
// }
// public enum GraphFunctionNamePosY
// {
//    NULL,
// // sin
//     Sine,
//     MultiSine,
//      Sine2D,
//      MultiSine2D,
//      // cos
//     Cos,
//     MultiCos,
//       Cos2D,
//    MultiCos2D,
//    // tan
//     Tan,
//     MultiTan,
//        Tan2D,
//    MultiTan2D,
//    // extra
//     SinRipple,
//      Cylinder,
//    Sphere,
//     Torus
 
// }
// public enum GraphFunctionNamePosZ
// {
//       NULL,
// // sin
//     Sine,
//     MultiSine,
//      Sine2D,
//      MultiSine2D,
//      // cos
//     Cos,
//     MultiCos,
//       Cos2D,
//    MultiCos2D,
//    // tan
//     Tan,
//     MultiTan,
//        Tan2D,
//    MultiTan2D,
//    // extra
//    SinRipple,
//     Cylinder,
//    Sphere,
//    Torus
  
// }
// public enum GraphFunctionNameRotX
// {
//       NULL,
// // sin
//     Sine,
//     MultiSine,
//      Sine2D,
//      MultiSine2D,
//      // cos
//     Cos,
//     MultiCos,
//       Cos2D,
//    MultiCos2D,
//    // tan
//     Tan,
//     MultiTan,
//        Tan2D,
//    MultiTan2D,
//    // extra
//    SinRipple,
//     Cylinder,
//    Sphere,
//     Torus
  

// }
// public enum GraphFunctionNameRotY
// {
//      NULL,
// // sin
//     Sine,
//     MultiSine,
//      Sine2D,
//      MultiSine2D,
//      // cos
//     Cos,
//     MultiCos,
//       Cos2D,
//    MultiCos2D,
//    // tan
//     Tan,
//     MultiTan,
//        Tan2D,
//    MultiTan2D,
//    // extra
//    SinRipple,
//     Cylinder,
//    Sphere,
//     Torus
  
// }
// public enum GraphFunctionNameRotZ
// { 
//       NULL,
// // sin
//     Sine,
//     MultiSine,
//      Sine2D,
//      MultiSine2D,
//      // cos
//     Cos,
//     MultiCos,
//       Cos2D,
//    MultiCos2D,
//    // tan
//     Tan,
//     MultiTan,
//        Tan2D,
//    MultiTan2D,
//    // extra
//    SinRipple,
//     Cylinder,
//    Sphere,
//     Torus
   
// }
#endregion
