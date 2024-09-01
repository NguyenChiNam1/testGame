using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 force;
    private bool isDragging = false;
    private bool isOnGround = false; // Biến kiểm tra đối tượng có đang đứng trên mặt đất không
    private Rigidbody2D rb;
    public float maxDragDistance = 2f;
    public float forceMultiplier = 5f;

    public LineRenderer lineRenderer; // Tham chiếu đến LineRenderer

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer not assigned!");
        }
    }

    void Update()
    {
        if (isOnGround)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isDragging = true;
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, startPos);
            }

            if (Input.GetMouseButton(0) && isDragging)
            {
                Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float distance = Vector2.Distance(startPos, currentPos);

                if (distance > maxDragDistance)
                {
                    Vector2 direction = (currentPos - startPos).normalized;
                    endPos = startPos + direction * maxDragDistance;
                }
                else
                {
                    endPos = currentPos;
                }
                lineRenderer.SetPosition(1, endPos);
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                force = (startPos - endPos) * forceMultiplier;
                rb.AddForce(force, ForceMode2D.Impulse);
                isDragging = false;
                lineRenderer.positionCount = 0; // Ẩn LineRenderer khi thả chuột
            }
        }
    }

    // Kiểm tra khi đối tượng tiếp xúc với mặt đất
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    // Kiểm tra khi đối tượng không còn tiếp xúc với mặt đất
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
