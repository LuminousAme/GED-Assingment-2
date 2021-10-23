using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    static Queue<SpawnFunctions> commandBuffer;

    static List<SpawnFunctions> commandHistory;
    static int counter;

    private void Awake()
    {
        commandBuffer = new Queue<SpawnFunctions>();
        commandHistory = new List<SpawnFunctions>();
    }

    public static void AddCommand(SpawnFunctions command)
    {
        while (commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }

        commandBuffer.Enqueue(command);
    }

    // Update is called once per frame
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            SpawnFunctions spawn = commandBuffer.Dequeue();
            spawn.Execute();

            commandHistory.Add(spawn);
            counter++;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (counter > 0)
                {
                    counter--;
                    commandHistory[counter].Undo();
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (counter < commandHistory.Count)
                {
                    commandHistory[counter].Execute();
                    counter++;
                }
            }
        }
    }
}
