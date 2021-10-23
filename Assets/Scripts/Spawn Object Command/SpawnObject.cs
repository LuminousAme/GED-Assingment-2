using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    static List<Transform> obj;

    public static void PlaceObject(Vector3 position, Color color, Transform cube)
    {
        Transform newPlatform = Instantiate(cube, position, Quaternion.identity);
        newPlatform.GetComponentInChildren<MeshRenderer>().material.color = color;
        if (obj == null)
        {
            obj = new List<Transform>();
        }
        obj.Add(newPlatform);
    }

    public static void RemoveObject(Vector3 position, Color color)
    {
        for (int i = 0; i < obj.Count; i++)
        {
            if (obj[i].position == position && obj[i].GetComponentInChildren<MeshRenderer>().material.color == color)
            {
                GameObject.Destroy(obj[i].gameObject);
                obj.RemoveAt(i);
                break;
            }
        }
    }
}
