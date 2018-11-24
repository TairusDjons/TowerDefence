using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWaveVM : MonoBehaviour {

    public WaveGenerator generator;
    public Text currentWave;
    public Text waveAmount;

    int maxWaves;
	void Start () {
        waveAmount.text = generator.waves.Count.ToString();
        maxWaves = generator.waves.Count;
        currentWave.text = ((maxWaves - generator.waves.Count) + 1).ToString();
        generator.NextWave += SetText;
	}

    void SetText()
    {
        currentWave.text = ((maxWaves - generator.WaveCount()) + 1).ToString();
    }
}
