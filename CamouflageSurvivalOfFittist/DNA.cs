using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour {

	//the genetic data stored in the DNA
	//gene for color:
	public float r;
	public float g;
	public float b;
	bool dead = false;	//turns true when the player clicks on the person
	public float TimeToDie = 0;		//used to know how long an entity lived, to sort them later on and know which one lived loonger(the fittist)
	SpriteRenderer sRenderer;	//used to access the renderer of the sprit
	Collider2D sCollider;	//used to access the collider of the sprite

	//unity function used to trigger an event on clicking on the sprite
	void OnMouseDown () {
		dead = true;
		TimeToDie = PopulationManager.elapsed;	//get the time the entity lived
		//Debug.Log("dead at " + TimeToDie);
		sRenderer.enabled = false;
		sCollider.enabled = false;
	}

	// Use this for initialization
	void Start () {
		//bend the values at initialization
		sRenderer = GetComponent<SpriteRenderer>();
		sCollider = GetComponent<Collider2D>();

		//setting the color of the person
		sRenderer.color = new Color(r,g,b);
		sRenderer.enabled = true;
		sCollider.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
