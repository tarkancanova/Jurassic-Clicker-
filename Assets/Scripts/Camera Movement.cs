using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;

    private float targetX;

    private void Start()
    {
        targetX = this.transform.position.x;
    }

    private void Update()
    {
        Vector3 position = this.transform.position;
        position.x = Mathf.Clamp(position.x, -9.84f, 410.16f);
        this.transform.position = position;
    }

    public void OnPreviousLevelClick()
    {
        m_Camera.transform.DOKill();

        targetX = Mathf.Clamp(targetX - 30, -9.84f, 410.16f);

        m_Camera.transform.DOMoveX(targetX, 0.5f);
    }

    public void OnNextLevelClick()
    {
        m_Camera.transform.DOKill();

        targetX = Mathf.Clamp(targetX + 30, -9.84f, 410.16f);

        m_Camera.transform.DOMoveX(targetX, 0.5f);
    }
}
