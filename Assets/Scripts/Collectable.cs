using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float m_FallSpeed = 0f;
    [SerializeField] private float bottomBoundary = -5.3f;
    [SerializeField] private int scoreValue = 1;
	private Rigidbody2D m_Rigidbody2D = null;

	// Awake is called before Start function
	void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

    void Update()
	{
		if (m_Rigidbody2D.velocity.y < 0f && Mathf.Abs(m_Rigidbody2D.velocity.y) > m_FallSpeed) {
			m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, Mathf.Sign(m_Rigidbody2D.velocity.y) * m_FallSpeed);
        }

        if (transform.position.y < bottomBoundary) {
            OutOfBounds();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cup")
        {
            Collected();
        }
    }

    private void Collected() {
        EventManager.instance.OnCollect?.Invoke();
        EventManager.instance.OnScoreIncremented?.Invoke(scoreValue);
        Destroy(gameObject);
    }

    private void OutOfBounds()
    {
        Destroy(gameObject);
        EventManager.instance.OnCollectableDrop?.Invoke();
    }
}
