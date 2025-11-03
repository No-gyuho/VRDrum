using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public TextAsset noteJsonFile;
    public GameObject notePrefab;
    public Transform[] spawnPoints; // 라인별 스폰 위치
    public Transform[] trackLines;  // 각 라인의 트랙 오브젝트
    public float spawnInterval = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnNote), 1f, spawnInterval);
    }

    void SpawnNote()
    {
        int lane = Random.Range(0, spawnPoints.Length);

        // 노트 생성
        GameObject note = Instantiate(notePrefab, spawnPoints[lane].position, Quaternion.identity);
        note.GetComponent<Note>().laneIndex = lane;
        // 트랙의 기울기 방향을 따라 이동 방향 설정
        Vector3 direction = -trackLines[lane].up;
        //note.GetComponent<Note>().moveDirection = direction;
    }
}
