﻿using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    [SerializeField, Header("這關的波數資料")]
    private DataWave[] dataWaves;
    [SerializeField, Header("生成敵人系統")]
    private SpawnEnemy[] spawnEnemys;

    private void Awake()
    {
        StartCoroutine(WaveUpdate());
    }

    /// <summary>
    /// 波數更新
    /// </summary>
    private IEnumerator WaveUpdate()
    {
        for (int i = 0; i < dataWaves.Length; i++)
        {
            print($"<color=#f69>波數：{dataWaves[i].name}</color>");

            // 每一個生成敵人系統都要重新啟動
            for (int j = 0; j < spawnEnemys.Length; j++)
            {
                // 更新每個生成系統的間隔時間 與 預製物
                spawnEnemys[j].RestartSpawn(dataWaves[i].interval, dataWaves[i].prefabEnemy);
            }

            yield return new WaitForSeconds(dataWaves[i].duration);
        }

        for (int j = 0; j < spawnEnemys.Length; j++)
        {
            // 停止所有生成系統的生成
            spawnEnemys[j].StopSpwan();
        }
    }
}
