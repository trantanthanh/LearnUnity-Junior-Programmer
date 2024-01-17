using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float speedRotate = 40.0f;
    public float scale = 1.0f;
    public float timeIntervalChangeColor = 0.5f;
    private float timeCount = 0f;
    Material material;

    enum CubeRotateState
    {
        X,
        Y,
        Z
    }

    CubeRotateState cubeRotateState = CubeRotateState.X;

    void Start()
    {
        transform.localScale = Vector3.one * scale;

        material = Renderer.material;
    }

    void Update()
    {
        switch (cubeRotateState)
        {
            case CubeRotateState.X:
                {
                    transform.Rotate(speedRotate * Time.deltaTime, 0.0f, 0.0f);
                    break;
                }
            case CubeRotateState.Y:
                {
                    transform.Rotate(0.0f, speedRotate * Time.deltaTime, 0.0f);
                    break;
                }
            case CubeRotateState.Z:
                {
                    transform.Rotate(0.0f, 0.0f, speedRotate * Time.deltaTime);
                    break;
                }
        }
        timeCount -= Time.deltaTime;
        if (timeCount < 0)
        {
            timeCount = timeIntervalChangeColor;
            material.color = new Color(Random.Range(0f, 1.0f), Random.Range(0f, 1.0f), Random.Range(0f, 1.0f), Random.Range(0f, 1.0f));

            CubeRotateState[] allStates = (CubeRotateState[])System.Enum.GetValues(typeof(CubeRotateState));
            int randomIndex = Random.Range(0, allStates.Length);
            cubeRotateState = allStates[randomIndex];
        }
    }
}
