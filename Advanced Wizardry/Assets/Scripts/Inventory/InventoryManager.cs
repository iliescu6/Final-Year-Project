using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Based on the example offered in the book "Unity in Action" by Joseph Hocking, Chapter 8

public class InventoryManager : MonoBehaviour,IGameManager {
    public ManagerStatus status { get; private set; }

    private Dictionary<string, int> _items;
    private Dictionary<string, int> _consumables;

    public void Startup() {

        _items = new Dictionary<string, int>();
        _consumables = new Dictionary<string, int>();

        status = ManagerStatus.Started;
    }


    public void AddItem(string name) {
        if (_items.ContainsKey(name))
        {
            _items[name] += 1;
        }
        else {
            _items[name] = 1;
        }
    }

    public void AddConsumable(string name)
    {
        if (_consumables.ContainsKey(name))
        {
            _consumables[name] += 1;
        }
        else
        {
            _consumables[name] = 1;
        }
    }

    public List<string> GetItemList() {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }

    public List<string> GetConsumableList()
    {
        List<string> list = new List<string>(_consumables.Keys);
        return list;
    }

    public int GetConsumableCount(string name) {
        if (_consumables.ContainsKey(name)) {
            return _consumables[name];
        }
        return 0;
    }



    public bool ConsumeItem(string name) {
        if (_consumables.ContainsKey(name))
        {
            _consumables[name] -=1;
        }
        else
        {

            return false;
        }
  
            return true;
        }
    }


