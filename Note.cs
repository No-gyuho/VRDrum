using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed = 2f;
    public int laneIndex;
    private bool isInHitZone = false;

    // 이동 방향
    private Vector3 moveDirection = new Vector3(0f, -1f, -1f);

    void Update()
    {
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);

        if (transform.position.y < -1f || transform.position.z < 0f)
        {
            Destroy(gameObject);
        }
    }

    public bool IsInHitZone()
    {
        return isInHitZone;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitZone"))
        {
            isInHitZone = true;
        }
        else if (other.CompareTag("MissZone"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HitZone"))
        {
            isInHitZone = false;
        }
    }
}
