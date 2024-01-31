using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager gameManager;
    private Camera cam;
    private Vector3 mousePos;
    private TrailRenderer trailRenderer;
    private BoxCollider boxCollider;
    private bool swiping;

    void Awake()
    {
        cam = Camera.main;
        trailRenderer = GetComponent<TrailRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        trailRenderer.enabled = false;
        boxCollider.enabled = false;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = mousePos;
    }

    void UpdateComponents()
    {
        trailRenderer.enabled = swiping;
        boxCollider.enabled = swiping;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }

            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Target target = other.gameObject.GetComponent<Target>();
        if (target)
        {
            target.DestroyTarget();
        }
    }
}
