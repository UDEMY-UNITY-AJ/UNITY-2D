using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;

    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetPathWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    // Called in EnemySpawner
    public void SetWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }

    private void Move() {
        if (waypointIndex < waypoints.Count) {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
