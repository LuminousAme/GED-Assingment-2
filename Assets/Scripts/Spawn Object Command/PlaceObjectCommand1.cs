using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectCommand : SpawnFunctions
{
    Vector3 position;
    Color color;
    Transform obj;
    uint id;

    public PlaceObjectCommand(Vector3 position, Color color, Transform obj)
    {
        this.position = position;
        this.color = color;
        this.obj = obj;
    }

    public void Execute()
    {
        id = SpawnObject.PlaceObject(position, color, obj);
    }

    public void Undo()
    {
        SpawnObject.RemoveObject(id);
    }
}
