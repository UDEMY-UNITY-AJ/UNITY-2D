using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update() {
        if (IsAttackerInLane()) {
            animator.SetBool("IsAttacking", true);
        } else {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        
        foreach (AttackerSpawner spawner in spawners) {
            bool isCloseEnough = Mathf.Abs((spawner.transform.position.y - transform.position.y)) <= Mathf.Epsilon;

            if (isCloseEnough) {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane() {
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        } else { return true; }
        
    }

    public void Fire() {
        Instantiate(projectile, transform.GetChild(0).transform.position, transform.rotation);
    }
}