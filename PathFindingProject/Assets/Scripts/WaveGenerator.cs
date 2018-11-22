using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    public List<Wave> waves;
    public float enemyDelay;
    public float waveDelay;

    private bool canSpawnEnemy = true;
    private bool canSpawnWave = true;

    private int repeatCounter = 0;
    private int unitCounter = 0;
    private Wave currentWave;

    private Queue<Wave> Q_waves;
    public UnityEngine.GameObject target;

	// Use this for initialization
	void Start () {
        Q_waves = new Queue<Wave>(waves);
	}
   
    // Update is called once per frame
    void Update() {
        
        if (Q_waves.Count <= 0)
        {
            canSpawnWave = false;
        }

        if (canSpawnWave)
        {
            currentWave = Q_waves.Dequeue();
            canSpawnWave = false;
        }

        if (currentWave != null)
            if (unitCounter > currentWave.units.Count-1)
            {
                canSpawnEnemy = false;
                currentWave = null;
                StartCoroutine(WaveDelay());
            }  
        
        if (canSpawnEnemy && currentWave != null)
            SpawnEnemy(currentWave.units[unitCounter]);
	}
    IEnumerator EnemyDelay()
    {
        canSpawnEnemy = false;
        yield return new WaitForSeconds(enemyDelay);
        canSpawnEnemy = true;
    }

    IEnumerator WaveDelay()
    {
        unitCounter = 0;
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
                Instantiate(unit.prefabUnit, this.transform.parent, false);

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
