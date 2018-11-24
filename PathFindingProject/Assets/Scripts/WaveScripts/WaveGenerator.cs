using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void WaveEvent();
public class WaveGenerator : MonoBehaviour
{
    public event WaveEvent NextWave;
    public event WaveEvent End;
    public List<Wave> waves;
    public float waveDelay;

    private bool canSpawnEnemy = true;
    private bool canSpawnWave = true;

    private int repeatCounter = 0;
    private int unitCounter = 0;
    private Wave currentWave;

    private Queue<Wave> Q_waves;
    public UnityEngine.GameObject target;

    private List<Unit> units;

    public int WaveCount()
    {
        return Q_waves.Count;
    }
	// Use this for initialization
	void Start () {
        Q_waves = new Queue<Wave>(waves);
        units = new List<Unit>();
	}
   
    // Update is called once per frame
    void Update() {
        
        if (canSpawnWave)
        {
            currentWave = Q_waves.Dequeue();
            canSpawnWave = false;
        }

        if (currentWave != null)
            if (unitCounter > currentWave.units.Count-1)
            {
                units.RemoveAll(unit => unit == null);
                if (Q_waves.Count == 0)
                {
                    if (units.Count == 0)
                    {
                        End();
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    canSpawnEnemy = false;
                    currentWave = null;
                    StartCoroutine(WaveDelay());
                }
                
            }

        if (canSpawnEnemy && currentWave != null)
            SpawnEnemy(currentWave.units[unitCounter]);
	}
    IEnumerator EnemyDelay()
    {
        canSpawnEnemy = false;
        yield return new WaitForSeconds(currentWave.enemyDelay);
        canSpawnEnemy = true;
    }

    IEnumerator WaveDelay()
    {
        unitCounter = 0;
        if (NextWave != null)
            NextWave();
        yield return new WaitForSeconds(waveDelay);
        canSpawnWave = true;
        canSpawnEnemy = true;
        
    }

    
    void SpawnEnemy(UnitVector enemys)
    {
        if (repeatCounter < enemys.repeatCounter)
        {
            enemys.units.ForEach(unit =>
            {
                var ai = unit.prefabUnit.GetComponent<UnitAI>();
                ai.agent.Warp(unit.spawnPoint);
                ai.Init(target);
                var enemy = Instantiate(unit.prefabUnit, this.transform.parent, false).GetComponent<Unit>();
                units.Add(enemy);
            });
            StartCoroutine("EnemyDelay");
            repeatCounter++;
        }
        else
        {
            repeatCounter = 0;
            unitCounter++;
        }
    }
}
