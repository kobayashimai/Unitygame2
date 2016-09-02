using UnityEngine; 
using System.Collections; 
 
 
 public class player_script : MonoBehaviour { 
 	// 速度 
 	public Vector2 SPEED = new Vector2(0.2f,0.2f); 
    private int restJumps = 3;

 	void Start () { 
	 
 	} 
 	 
 	// Update is called once per frame 
 	void Update () { 
 		// 移動処理 
 		Move();
 	} 
 
 
 	// 移動関数 
 	void Move(){ 
 		// 現在位置をPositionに代入 
 		Vector2 Position = transform.position; 
		Vector3 scale = transform.localScale;
 
 		if(Input.GetKey("left")){ 
 		// 代入したPositionに対して加算減算を行う 			
        Position.x -= SPEED.x; 
		scale.x = -1; 
			transform.localScale = scale;

 		} else if(Input.GetKey("right")){ 

 			Position.x += SPEED.x; 
			scale.x = 1; 
			transform.localScale = scale;
 		}
 
     // マウスをクリックするとジャンプする
        if (Input.GetKeyDown("space"))
        {

            if (restJumps > 0)
            {
                 //Position.y += SPEED.y; 
			    GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
                restJumps--;
			}	

        }
		// 現在の位置に加算減算を行ったPositionを代入する 
 		transform.position = Position; 	
	}
		

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "ground")
		{
			// ジャンプ回数をリセットする
			restJumps = 3;
		}

		if (coll.gameObject.tag == "goal") {

			Application.LoadLevel("goal");
		}
	}
}
	

 
 


