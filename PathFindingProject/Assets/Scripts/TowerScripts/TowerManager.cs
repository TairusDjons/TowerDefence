using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TowerEvent();
public class TowerManager : MonoBehaviour {

    [SerializeField]
    int resources;
    public TowerPicker picker;
    public event TowerEvent ResourcesChange;
    public int Resources
    {
        get { return resources; }
        set
        {
            resources = value < 0 ? 0 : value;
            if (ResourcesChange != null)
                ResourcesChange();
        }
    }

    List<Tower> towers;
    public static TowerManager instance;
    public bool deleteTower;
    void Start() {
        instance = this;
        towers = new List<Tower>();
        InvokeRepeating("GenerateResources", 0f, 2.5f);
    }

    public void SetPlace(TowerPlacing place)
    {
        if (picker.deleteTower)
            DestroyTower(place.tower);
        else BuildTower(place);
    }

    public void BuildTower(TowerPlacing place)
    {
        Tower tower = picker.CurrentTower;
        if (tower != null && Resources >= tower.value)
        {
            place.tower = Instantiate(tower, place.Position(), Quaternion.identity);
            towers.Add(place.tower);
            Resources -= place.tower.value;
        }
            
    }

    public void DestroyTower(Tower tower)
    {
        if (tower == null)
            return;
        Resources += tower.value / 2;
        Destroy(tower.gameObject);
    }

    void GenerateResources() { Resources++; }
	// Update is called once per frame
	void Update () {
        
	}
}
