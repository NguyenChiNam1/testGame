using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Tham chiếu đến đối tượng player
    public float smoothSpeed = 0.125f; // Tốc độ làm mượt camera
    public Vector3 offset; // Khoảng cách giữa camera và player

    private float cameraX; // Lưu trữ vị trí X hiện tại của camera

    void Start()
    {
        // Lưu trữ vị trí X hiện tại của camera để giữ cố định
        cameraX = transform.position.x;
    }

    void LateUpdate()
    {
        // Tính toán vị trí mục tiêu của camera với chỉ thay đổi theo chiều Y
        Vector3 desiredPosition = new Vector3(cameraX, player.position.y + offset.y, transform.position.z);
        // Tính toán vị trí của camera với hiệu ứng làm mượt
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Cập nhật vị trí của camera
        transform.position = smoothedPosition;
    }
}
