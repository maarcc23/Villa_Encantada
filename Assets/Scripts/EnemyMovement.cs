using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // Los puntos de la ruta
    public float speed = 2f; // Velocidad del enemigo
    private int currentWaypointIndex = 0;
    private bool isMoving = true; // Controla si el enemigo debe seguir moviéndose

    void Start()
    {
        // Verifica que haya waypoints asignados
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError("Waypoints no asignados. Arrastra los puntos al array en el Inspector.");
        }
    }

    void Update()
    {
        // Verifica si el enemigo debe seguir moviéndose
        if (!isMoving || waypoints == null || waypoints.Length == 0) return;

        // Mover al enemigo hacia el punto actual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        if (targetWaypoint == null)
        {
            Debug.LogError("Un waypoint en el array está vacío. Revisa las referencias en el Inspector.");
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Verificar si el enemigo llegó al punto actual
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Si se alcanzó el último punto, detener al enemigo
            if (currentWaypointIndex == waypoints.Length - 1)
            {
                isMoving = false; // Detener el movimiento
                Debug.Log("El enemigo ha llegado al último punto y se ha detenido.");
            }
            else
            {
                // Cambiar al siguiente punto
                currentWaypointIndex++;
            }
        }
    }
}


