using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResourcesVM : MonoBehaviour {

    public TowerManager manager;
    public Text resources;
	void Start () {
        manager.ResourcesChange += SetText;
        resources.text = manager.Resources.ToString();
	}

    void SetText()
    {
        resources.text = manager.Resources.ToString();
    }
}
