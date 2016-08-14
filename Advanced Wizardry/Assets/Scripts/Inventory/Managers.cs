using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof (InventoryManager))]

//Based on the example offered in the book "Unity in Action" by Joseph Hocking, Chapter 8

public class Managers : MonoBehaviour {
    public static InventoryManager Inventory { get; private set; }

    private List<IGameManager> _startSequence;

    void Awake() {
        Inventory = GetComponent<InventoryManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Inventory);

        StartCoroutine(StartupManagers());
    }
    private IEnumerator StartupManagers() {
        foreach (IGameManager manager in _startSequence) {
            manager.Startup();
        }
        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules) {
            int lastReady = numReady;
            numReady = 0;

            foreach (IGameManager manager in _startSequence) {
                if (manager.status == ManagerStatus.Started) {
                    numReady++;
                }
            }
            if (numReady > lastReady)


            yield return null;
        }

    }

}
