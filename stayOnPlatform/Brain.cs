using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {

	//each character has dna
    int DNALength = 2; //gets a length of 2 cuz it has 2 decision to make(what i do when i see the edge(0), and when i dont(1))
    public float timeAlive;
    public DNA dna;

    public GameObject Eyes;     //link to eyes
    bool alive = true;     
    bool seeGround = true;                

    //unity function for collider, when the character hits a prefab taged "deadd" the variable alive alter to false
    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "dead")
        {
            alive = false;
        }
    }
    
    //init the character
    public void Init()
    {
        //initialise DNA
        //0 forward
        //1 left
        //2 right 
         
        dna = new DNA(DNALength,3); // 3 cue we have 3 oprtions
        timeAlive = 0;
        alive = true;
    }


    void Update()
    {
        if(!alive) return;
        Debug.DrawRay(Eyes.transform.position, Eyes.transform.forward * 10, Color.red, 10);     //generate vector from eyes to the ground
        seeGround = false;
        RaycastHit hit;
        if(Physics.Raycast(Eyes.transform.position, Eyes.transform.forward * 10, out hit)){
            if(hit.collider.gameObject.tag == "platform") seeGround = true;
        }

        timeAlive = PopulationManager.elapsed;

        //read th dna to move
        float turn = 0;
        float move = 0;
        if(seeGround){
            if(dna.GetGene(0) == 0) move = 1;
            else if (dna.GetGene(0) == 1) turn = -90;
            else if (dna.GetGene(0) == 2) turn = 90;
        }
        else
        {
            if(dna.GetGene(1) == 0) move = 1;
            else if (dna.GetGene(1) == 1) turn = -90;
            else if (dna.GetGene(2) == 2) turn = 90;
        }

        this.transform.Translate(0, 0, move * 0.1f);
        this.transform.Rotate(0, turn, 0);


    }
}
