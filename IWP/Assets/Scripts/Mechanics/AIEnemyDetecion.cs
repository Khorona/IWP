using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyDetecion : MonoBehaviour
{

    [field: SerializeField]

    //public bool PlayerInArea { get; private set; }
    public bool PlayerDetected { get; private set; }
    //public Vector2 DirectionToTarget => target.transform.position - detectorOrigin.position;
    //public Transform Player { get; private set; }

    [Header("OverlapBox parameters")]
    [SerializeField]
    private Transform detectorOrigin;
    public Vector2 detectorSize = Vector2.zero;

    public float detectionDelay = 0.3f;

    public LayerMask detectorLayerMask;

    //[Header("Gizmo parameters")]


    //[SerializeField]
    //private string detectionTag = "Player";

    BoxCollider2D detectionbox;

    private GameObject target;

    public GameObject Target
    {
        get => target;
        private set
        {
            target = value;
            PlayerDetected = target != null;
        }
    }

    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDelay);
        PerformDetection();
        StartCoroutine(DetectionCoroutine()); 
    }

    public void PerformDetection()
    {
        if(detectionbox != null)
        {
            Target = detectionbox.gameObject;
        }
        else
        {
            Target = null;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag(detectionTag))
    //    {
    //        PlayerInArea = true;
    //        Player = collision.gameObject.transform;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag(detectionTag))
    //    {
    //        PlayerInArea = false;
    //        Player = null;
    //    }
    //}
}
