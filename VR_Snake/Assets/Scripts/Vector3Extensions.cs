using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//Script for better Vector processing
static class Vector3Extensions
{
    public static Vector3 getRandomVector()
    {
        return new Vector3(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    public static Vector3 floorComponents(this Vector3 old)
    {
        return new Vector3((float)Math.Floor(old.x), (float)Math.Floor(old.y), (float)Math.Floor(old.z));
    }

    public static int isInside(this Vector3 toBeChecked, Vector3 cage)
    {
        if (toBeChecked.x < 0 || toBeChecked.x >= cage.x)
        {
            return 1;
        }
        if (toBeChecked.y < 0 || toBeChecked.y >= cage.y)
        {
            return 2;
        }
        if (toBeChecked.z < 0 || toBeChecked.z >= cage.z)
        {
            return 3;
        }
        return 0;
    }
    public static Vector3 modulo(this Vector3 vectorToBeFitted, Vector3 cage)
    {
        return new Vector3((vectorToBeFitted.x + cage.x) % cage.x, (vectorToBeFitted.y + cage.y) % cage.y, (vectorToBeFitted.z + cage.z) % cage.z);
    }

    public static bool isInSameCell(this Vector3 a, Vector3 b)
    {
        if (Math.Floor(a.x) != Math.Floor(b.x))
        {
            return false;
        }
        if (Math.Floor(a.y) != Math.Floor(b.y))
        {
            return false;
        }
        if (Math.Floor(a.z) != Math.Floor(b.z))
        {
            return false;
        }
        return true;
    }

    public static bool checkIfAreaLeftAndReturnNewPosition(this Vector3 toCheckposition, out Vector3 newPosition)
    {
        int leftGridVia = isInside(toCheckposition, VariableManager.instance.mapSize);
        //Avoid warnings where newPosition is not assigned, it will be overridden if something changes
        newPosition = toCheckposition;
        if (leftGridVia != 0)
        {
            switch (leftGridVia)
            {
                case 1:
                    //Debug.Log("Left the grid on the x axis");
                    if (!VariableManager.instance.isXAxisLooped)
                    {
                        return true;
                    }
                    break;
                case 2:
                    //Debug.Log("Left the grid on the y axis");
                    if (!VariableManager.instance.isYAxisLooped)
                    {
                        return true;
                    }
                    break;
                case 3:
                    //Debug.Log("Left the grid on the z axis");
                    if (!VariableManager.instance.isZAxisLooped)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            newPosition = modulo(newPosition, VariableManager.instance.mapSize);
        }
        return false;
    }
}
