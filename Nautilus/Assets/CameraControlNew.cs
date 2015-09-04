using UnityEngine;
using System.Collections;

public class CameraControlNew : MonoBehaviour {

	public float MinZoom;
	public float MaxZoom;
	public float ZoomSpeed;
	public CameraFollow cameraFollow;

	[HideInInspector]
	public Vector3 newPosition;

	// Use this for initialization
	void Start () 
	{
		newPosition = cameraFollow.Target.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeZoom (int positive)
	{
		if (positive > 0)
			newPosition -= newPosition * ZoomSpeed;
		else
			newPosition += newPosition * ZoomSpeed;
	}

	public void HandleMouseX (float amount)
	{
			OrbitXZ (amount);
	}

	public void HandleMouseY (float amount)
	{
			OrbitYZ (amount);
	}

	public void OrbitXZ (float amount)
	{
		float distance = newPosition.magnitude;
		Vector3 cross = Vector3.Cross (new Vector3 (newPosition.x, 0f, newPosition.z) * amount, Vector3.up);
		newPosition = Vector3.ClampMagnitude (newPosition + cross, distance);
	}

	public void OrbitYZ (float amount)
	{
		float distance = newPosition.magnitude;
		Vector3 cross = Vector3.Cross (new Vector3 (0f, newPosition.y, newPosition.z) * amount, Vector3.right);

		if ((newPosition.y + cross.y) > distance) 
		{
			float div = (distance - newPosition.y) / cross.y ;
			cross.y = distance - newPosition.y;
			cross.x *= div;
		}

		newPosition += cross;

		newPosition = Vector3.ClampMagnitude (newPosition, distance);
	}
}
