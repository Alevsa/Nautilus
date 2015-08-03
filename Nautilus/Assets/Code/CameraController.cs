using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

public class CameraController : MonoBehaviour 
{
    public float MinZoom;
    public float MaxZoom;
    public float ZoomSpeed;
    public float RotationSpeed;

    private float m_MinY;
    private float m_MaxY;

    private SmoothFollow m_smoothFollow;
	// Use this for initialization
	void Start () 
    {
        m_smoothFollow = GetComponent<SmoothFollow>();
        m_MinY = MinZoom + 18;
        m_MaxY = MaxZoom + 26;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AdjustZoom(float zoom)
    {
        zoom *= ZoomSpeed;
        float y = transform.position.y;

        if(y >= m_MinY && y <= m_MaxY)
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, y -= zoom*2, transform.position.z), ZoomSpeed);

        y = transform.position.y;

        if (y < m_MinY)
            transform.position = new Vector3(transform.position.x, m_MinY, transform.position.z);

        if(y > m_MaxY)
            transform.position = new Vector3(transform.position.x, m_MaxY, transform.position.z);

        float curDist = m_smoothFollow.Distance;

        if (curDist >= MinZoom && curDist <= MaxZoom)
            m_smoothFollow.Distance = Mathf.Lerp(m_smoothFollow.Distance, curDist - zoom, ZoomSpeed);

        curDist = m_smoothFollow.Distance;

        if (curDist < MinZoom)
            m_smoothFollow.Distance = MinZoom;

        if (curDist > MaxZoom)
            m_smoothFollow.Distance = MaxZoom;
    }

    public void AdjustRotation(float rotation)
    {
        float y = transform.rotation.y;

        Quaternion dest = new Quaternion(transform.rotation.x, y -= rotation/2, transform.rotation.z, transform.rotation.w);
        transform.rotation = Quaternion.Lerp(transform.rotation, dest, RotationSpeed);
    }
}
