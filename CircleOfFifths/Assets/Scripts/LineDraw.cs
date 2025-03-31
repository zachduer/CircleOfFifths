
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    private TrailRenderer trail;
    private ParticleSystem particles;

    private Camera mainCamera;

    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        particles = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Set depth for world position conversion

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0f; // Keep it in 2D plane

            // Move trail renderer to follow the mouse
            trail.transform.position = worldPosition;

            // Emit particles at this position
            EmitParticles(worldPosition);
        }

        if (Input.GetMouseButtonDown(0))
        {
            trail.Clear();
        }
    }

    void EmitParticles(Vector3 position)
    {
        particles.transform.position = position;
        particles.Emit(5); // Emit a small burst
    }

}