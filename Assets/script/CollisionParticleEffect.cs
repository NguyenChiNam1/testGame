using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticleEffect : MonoBehaviour
{
    public ParticleSystem particleEffect; // Tham chiếu đến Particle System
    public string groundTag = "Ground";  // Tag của mặt đất

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu vật thể va chạm với mặt đất
        if (collision.gameObject.CompareTag(groundTag))
        {
            // Di chuyển Particle System tới vị trí va chạm
            particleEffect.transform.position = collision.contacts[0].point;

            particleEffect.Stop();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Dừng phát hạt khi không còn va chạm
        if (collision.gameObject.CompareTag(groundTag))
        {
            
            // Phát hiệu ứng Particle System
            particleEffect.Play();
        }
    }
}
