using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

    [SerializeField]
    int resources;
    public TowerPicker picker;
    public int Resources
    {
        get { return resources; }
        set { resources = value < 0 ? 0 : value; }
    }
    List<Tower> towers;
    public static TowerManager instance;
    public bool deleteTower;
    void Start() {
        instance = this;
        towers = new List<Tower>();
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
        if (tower != null && Resources > tower.value)
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
	// Update is called once per frame
	void Update () {
		
	}
}
