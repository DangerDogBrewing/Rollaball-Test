using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	//public float speed = 0.000000000002f;
	public float speed = 1f;

	public GUIText countText;
	public GUIText winText;
	private int count;

	
	// Use this for initialization
	void Start () {
		count = 0;
		setCountText ();
		winText.text = "";
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	

	// Update is called once per frame
	void FixedUpdate () {

		#if UNITY_STANDALONE || UNITY_WEBPLAYER

			//get input by keyboard
			float movehorizontal = Input.GetAxis ("Horizontal");
			float movevertical = Input.GetAxis ("Vertical");
			
			Vector3 movement = new Vector3 (movehorizontal, 0.0f, movevertical);
			GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
		   

		#else	 

	//	transform.Translate(Input.acceleration.x * speed, -Input.acceleration.y* speed,0 );
		Vector3 dir = Vector3.zero;

		dir.x = Input.acceleration.x;
		dir.y = Input.acceleration.y;
		Vector3 movement = new Vector3(dir.x,0f,dir.y);

		GetComponent<Rigidbody>().AddForce(  movement * speed * Time.deltaTime);

		#endif //End of mobile platform dependendent compilation section started above with #elif


		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive(false);
			count+=1;
			setCountText();
		}
	}
	
	void setCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12) {
			winText.text = "YOU WIN!";
		}
	}
	

	
}