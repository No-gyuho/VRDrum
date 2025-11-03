using UnityEngine;

public class NoteMove : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 너무 아래로 떨어졌을 경우 제거
        if (transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }
}
