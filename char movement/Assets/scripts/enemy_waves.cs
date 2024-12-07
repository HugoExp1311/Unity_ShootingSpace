using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class enemy_waves : MonoBehaviour
{
    [SerializeField] private float waveDelay;
    public GameObject[] spawnerPrefab;
    [SerializeField] private Slider waveProgressBar; // Slider cho tiến trình waves
    public bool isWaves = false;

    private int totalSpawners; // Tổng số spawner
    private int completedSpawners = 0; // Số lượng spawner đã hoàn thành

    private void Start()
    {
        totalSpawners = spawnerPrefab.Length; // Xác định tổng số spawner
        if (waveProgressBar != null)
        {
            waveProgressBar.maxValue = totalSpawners; // Đặt giá trị tối đa cho Slider
            waveProgressBar.value = 0; // Đặt giá trị ban đầu
            waveProgressBar.gameObject.SetActive(true); // Hiển thị thanh tiến trình
        }

        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        foreach (GameObject spawner in spawnerPrefab)
        {
            // Kích hoạt spawner
            spawner.SetActive(true);

            if (spawner.tag == "Spawner")
            {
                enemy_spawn enemySpawnComponent = spawner.GetComponent<enemy_spawn>();
                enemySpawnComponent.Spawner();

                // Chờ cho đến khi spawner hoàn thành
                yield return new WaitUntil(() => !enemySpawnComponent.isSpawn);
            }
            else
            {
                waveDelay = 2f;

                if (spawner.GetComponent<DialogueSystemTrigger>() != null)
                {
                    onDIalogEnd onDialogEnd = spawner.GetComponent<onDIalogEnd>();
                    CanvasManager.instance.isConversation = true;

                    // Chờ cho đến khi hội thoại kết thúc
                    yield return new WaitWhile(() => !onDialogEnd.isOnconversationEnd);

                    CanvasManager.instance.isConversation = false;
                }
            }

            // Tắt spawner sau khi hoàn thành
            spawner.SetActive(false);

            // Cập nhật tiến trình của thanh tiến trình
            completedSpawners++;
            if (waveProgressBar != null)
            {
                waveProgressBar.value = completedSpawners;
            }

            // Delay giữa các waves
            yield return new WaitForSeconds(waveDelay);
        }

        // Ẩn thanh tiến trình khi hoàn thành tất cả waves
        if (waveProgressBar != null)
        {
            waveProgressBar.gameObject.SetActive(false);
        }

        // Tắt object chứa script này
        gameObject.SetActive(false);
    }
}
