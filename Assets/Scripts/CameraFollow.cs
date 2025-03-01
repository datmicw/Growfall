using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -10);  // khoảng cách camera
    public float smoothSpeed = 5f;  // tốc độ di chuyển mượt

    private Vector3 lastPlayerPosition; // lưu vị trí trước đó của nhân vật

    private void LateUpdate()
    {
        if (player != null)
        {
            // kiểm tra nếu nhân vật thực sự di chuyển
            if (player.position != lastPlayerPosition)
            {
                Vector3 desiredPosition = player.position + offset;
                transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

                // xoay camera theo nhân vật
                Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
            }

            // cập nhật vị trí trước đó của nhân vật
            lastPlayerPosition = player.position;
        }
    }
}
