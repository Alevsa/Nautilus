using UnityEngine;
using System.Collections;

public class CameraControlNew : MonoBehaviour {

	public float MinZoom;
	public float MaxZoom;
	public float ZoomSpeed;
	public CameraFollow cameraFollow;

	[HideInInspector]
	public Vector3 newPosition;

	private bool bControlled = false;
	private Vector3 behindPosition;

	// Use this for initialization
	void Start () 
	{
		newPosition = this.transform.position - cameraFollow.Target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!bControlled)
			GetBehind ();
	}
	
	public void ChangeZoom (int positive)
	{
		if (positive > 0)
		{
			if ((newPosition - (newPosition * ZoomSpeed)).magnitude < MinZoom)
				newPosition = Vector3.ClampMagnitude(newPosition, MinZoom);
			else
				newPosition -= newPosition * ZoomSpeed;
		}
		else
		{
			newPosition += newPosition * ZoomSpeed;
			newPosition = Vector3.ClampMagnitude(newPosition, MaxZoom);
		}
	}

	public void HandleMouseX (float amount)
	{
			OrbitXZ (-amount);
			bControlled = true;
	}

	public void HandleMouseY (float amount)
	{
			OrbitYZ (amount);
			bControlled = true;
	}

	public void Unbind ()
	{
		bControlled = false;
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

		Vector3 projectionXZ = new Vector3 (newPosition.x, 0f, newPosition.z);

		Vector3 perpXZ = new Vector3 (-projectionXZ.z, 0f, projectionXZ.x).normalized;
//		Debug.Log (projectionXZ + " : " + perpXZ);

		Vector3 cross = Vector3.Cross (newPosition * amount, perpXZ);

		if (Mathf.Pow ((newPosition.y + cross.y), 2) > Mathf.Pow (distance,2)) 
			return;

		newPosition += cross;

		newPosition = Vector3.ClampMagnitude (newPosition, distance);
	}

	public void GetBehind()
	{
//		behindPosition = new Vector3 (0F, newPosition.y, newPosition.z - Mathf.Abs(newPosition.x));
//		behindPosition = cameraFollow.Target.transform.TransformPoint (behindPosition);
//		newPosition = Vector3.MoveTowards(newPosition, behindPosition - cameraFollow.Target.transform.position, 0.1F);
	}
}
