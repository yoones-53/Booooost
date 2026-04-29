using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Enemy Prefabs")]
    public GameObject[] enemyPrefabs;

    [Header("Spawn Position")]
    public float spawnXMinOffset = 15f; // 플레이어 앞 최소 거리
    public float spawnXMaxOffset = 25f; // 플레이어 앞 최대 거리
    public float minY = -6f; // 스폰 가능한 최소 Y
    public float maxY = 82f; // 스폰 가능한 최대 Y

    [Header("Distance Spawn")]
    public float unitsPerSpawn = 10f;     // 이동거리 10마다 스폰
    public float unitsPerLevel = 20f;     // 이동거리 20마다 난이도 증가
    public int baseSpawnCount = 1; // 기본 스폰 개수

    private float nextSpawnX; // 다음 스폰 위치

    void Start()
    {
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");

        player = foundPlayer.transform;

        nextSpawnX = player.position.x + unitsPerSpawn; // 첫 스폰 위치
    }

    void Update()
    {
        if (player.position.x >= nextSpawnX) // 플레이어가 스폰 지점에 도달할때마다
        {
            SpawnEnemiesByDistance(); // 적 생성
            nextSpawnX += unitsPerSpawn; // 스폰 위치 갱신
        }
    }

    void SpawnEnemiesByDistance()
    {
        float playerX = player.position.x;

        int difficultyLevel = Mathf.FloorToInt(playerX / unitsPerLevel); // 난이도 조정
        int spawnCount = baseSpawnCount + difficultyLevel; // 기본 스폰 + 난이도 증가

        for (int i = 0; i < spawnCount; i++)
        {
            SpawnOneEnemy();
        }
    }

    void SpawnOneEnemy()
    {
        // 플레이어 앞에 적 랜덤 위치 생성
        float spawnX = player.position.x + Random.Range(spawnXMinOffset, spawnXMaxOffset);
        float spawnY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);

        int randomIndex = Random.Range(0, enemyPrefabs.Length); // 랜덤 적 생성

        Instantiate(enemyPrefabs[randomIndex], spawnPos, Quaternion.identity); // 적 생성
    }
}