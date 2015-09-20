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
    private Transform player;

	void Start () 
    {
        m_smoothFollow = GetComponent<SmoothFollow>();
        m_MinY = MinZoom + 18;
        m_MaxY = MaxZoom + 26;
		if (Application.loadedLevelName == "Overworld")
		{
        	player = GameObject.Find("Player").transform;
        }
        else 
        {
			player = GameObject.Find("PlayerBattle").transform;
        }
	}

    public void AdjustZoom(float zoom)
    {
        zoom *= ZoomSpeed;
        float y = transform.position.y;

        if (y >= m_MinY && y <= m_MaxY)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, y -= zoom*2, transform.position.z), ZoomSpeed);

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
        transform.RotateAround(player.position, Vector3.up,  rotation*RotationSpeed);
    }
}
