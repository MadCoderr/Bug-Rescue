using UnityEngine;
using UnityEngine.EventSystems;

public class IgnoreCode : MonoBehaviour {

	public float rayLength;
	public LayerMask layermask;
	public float timer;

	// Use this for initialization
	void Start () {
		timer = 0.2f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ()) 
		{
			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,out hit,rayLength,layermask))
			{
				Debug.Log(hit.collider.name);
				hit.collider.gameObject.GetComponentInParent<ExampleBridge> ().enabled = true;
			}
		}

//		if (Input.GetMouseButton (0)) 
//		{
//			timer -= Time.deltaTime;
//
//			if (!EventSystem.current.IsPointerOverGameObject ()) 
//			{
//				RaycastHit hit;
//
//				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//				if(Physics.Raycast(ray,out hit,rayLength,layermask))
//				{
//					Debug.Log(hit.collider.name);
//					hit.collider.gameObject.GetComponentInParent<ExampleBridge> ().enabled = true;
//				}
//			}
//		}
//
//		if (Input.GetMouseButtonUp (0))
//			timer = 0.2f;

	}
		
}
