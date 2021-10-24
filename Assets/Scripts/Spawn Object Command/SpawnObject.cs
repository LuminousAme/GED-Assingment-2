using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    static List<Transform> obj;
    static uint currentId;

    public static uint PlaceObject(Vector3 position, Color color, Transform newObject)
    {
        Transform newPlatform = Instantiate(newObject, position, Quaternion.identity);
        newPlatform.GetComponentInChildren<MeshRenderer>().material.color = color;
        if (obj == null)
        {
            obj = new List<Transform>();
            currentId = 0;
        }
        obj.Add(newPlatform);
        currentId++;
        newPlatform.GetComponent<ObjectIDContainer>().ID = currentId;

        return currentId;
    }

    public static void RemoveObject(uint id)
    {
        for(int i = 0; i < obj.Count; i++)
        {
            if (obj[i].GetComponent<ObjectIDContainer>().ID == id)
            {
                GameObject.Destroy(obj[i].gameObject);
                obj.RemoveAt(i);
                break;
            }
        }
    }
}
