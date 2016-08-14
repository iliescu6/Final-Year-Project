using UnityEngine;
using System.Collections;

//Based on the example offered in the book "Unity in Action" by Joseph Hocking, Chapter 8

public interface IGameManager {
    ManagerStatus status { get; }

    void Startup();
}
