using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class C_MF : MonoBehaviour
{
    public static float pi = Mathf.PI;
    private static Vector3 center = Vector3.zero;
    public static float Hysteresis(float val, float min = -1.0f, float max = 1.0f)
    {
        return Mathf.Max(min, Mathf.Min(max, val)); 
    }

    public static float Hysteresis(float val, float max)
    {
        return Hysteresis(val, -max, max);
    }
    public static Vector2 Hysteresis(Vector2 val, Vector2 min, Vector2 max)
    {
        return new Vector2(Hysteresis(val.x, min.x, max.x), Hysteresis(val.y, min.y, max.y));
    }

    public static Vector3 Hysteresis(Vector3 val, Vector3 min , Vector3 max)
    {
        return new Vector3(Hysteresis(val.x, min.x, max.x), Hysteresis(val.y, min.y, max.y), Hysteresis(val.z, min.z, max.z));
    }
    
    public static float R2G (float rad)
    {
        return rad * 180.0f / Mathf.PI;
    }
    public static float G2R(float grad)
    {
        return grad / 180.0f * Mathf.PI;
    }
    
    public static float Round (float val, int d = 0)
    {
        return Mathf.Floor(val * Mathf.Pow(10, d) + 0.5f) / Mathf.Pow(10, d);
    }
    public static float NormalAngles(float val)
    {
        float res = val % 360;
        if (res > 180.0f) res -= 360;
        return res;
    }
    public static Vector3 NormalAngles(Vector3 val)
    {
        return new Vector3 (NormalAngles(val.x), NormalAngles(val.y), NormalAngles(val.z));
    }
    public static float Sign (float val)
    {
        return val == 0 ? 0 : Mathf.Sign(val);
    }

    public static float Hipotinuse (float x, float y)
    {
        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }

    public static float Angle(float x, float y)
    {
        return R2G(-Sign(y) * (pi / 4 - Sign(x) * pi / 4 + (x < 0 ? Mathf.Atan2(Mathf.Abs(x), Mathf.Abs(y)) : Mathf.Atan2(Mathf.Abs(y), Mathf.Abs(x)))));
    }
    public static Vector3 Angles(Vector3 from, Vector3 to)
    {
        Vector3 v = to - from;
        return new Vector3 (Angle(v.y, v.z), Angle(v.x, v.z), Angle(v.x, v.y));
    }

    public static Vector3 Angles(Vector3 to)
    {
        return Angles(Vector3.zero, to);
    }

    public static float toRotation(float begin, float end)
    {
        begin %= 360;
        end %= 360;
        begin += begin < 0 ? 360 : 0;
        end += (end < 0 || end < begin) ? 360 : 0;
        return end - begin - (end - begin <= 180 ? 0 : 360);
    }

}
