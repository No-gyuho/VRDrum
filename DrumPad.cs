using UnityEngine;

public class DrumPad : MonoBehaviour
{
    public int laneIndex; // 드럼패드가 담당하는 라인 번호
    public AudioClip drumSound;
    private AudioSource audioSource;
    public JudgementUI judgementUI;
    private float lastHitTime = -1f;
    public float hitCooldown = 0.15f;
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = drumSound;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DrumStick"))
        {
            if (Time.time - lastHitTime < hitCooldown)
                return; // 너무 빠르면 무시
            // 사운드 재생
            audioSource.PlayOneShot(drumSound);

            // 해당 라인의 히트존 안에 있는 노트 찾기
            Note[] notes = Object.FindObjectsByType<Note>(FindObjectsSortMode.None);
            foreach (Note note in notes)
            {
                if (note.laneIndex == laneIndex && note.IsInHitZone())
                {
                    //Debug.Log($"판정 성공! 라인 {laneIndex}");
                    FindFirstObjectByType<ComboManager>()?.IncreaseCombo();
                    judgementUI?.ShowJudgement("Perfect!");
                    Destroy(note.gameObject);
                    return;
                }
            }

            //Debug.Log($"Miss! 라인 {laneIndex}");
            FindFirstObjectByType<ComboManager>()?.ResetCombo();
            judgementUI?.ShowJudgement("Miss!");
        }
    }
}