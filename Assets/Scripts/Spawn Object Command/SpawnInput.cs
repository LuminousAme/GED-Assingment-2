using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInput : MonoBehaviour
{
    Camera maincam;
    RaycastHit hitInfo;
    public Transform PlatformPrefab;
    public Transform EnemyPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                Color c = new Color(1, 1, 1);

                SpawnFunctions command = new PlaceObjectCommand(hitInfo.point, c, PlatformPrefab);
                SpawnScript.AddCommand(command);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                Color c = new Color(0.75f, 0, 0);

                SpawnFunctions command = new PlaceObjectCommand(hitInfo.point, c, EnemyPrefab);
                SpawnScript.AddCommand(command);
            }
        }
    }
}
