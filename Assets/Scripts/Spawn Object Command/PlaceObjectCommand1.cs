using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectCommand : SpawnFunctions
{
    Vector3 position;
    Color color;
    Transform cube;

    public PlaceObjectCommand(Vector3 position, Color color, Transform cube)
    {
        this.position = position;
        this.color = color;
        this.cube = cube;
    }

    public void Execute()
    {
        SpawnObject.PlaceObject(position, color, cube);
    }

    public void Undo()
    {
        SpawnObject.RemoveObject(position, color);
    }
}
