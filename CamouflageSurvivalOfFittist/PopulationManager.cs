using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManager : MonoBehaviour {

	//link to the object
	public GameObject personPrefab;
	public int populationSize = 10;
	List<GameObject> population = new List<GameObject>();
	public static float elapsed = 0;

	int trialTime = 10;		//time for a generation(time to click)
	int generation = 1;		//the number of generation


	//adding some infos on screen
	GUIStyle guiStyle = new GUIStyle();
	void OnGUI(){
		guiStyle.fontSize = 20;
		guiStyle.normal.textColor = Color.white;
		GUI.Label(new Rect(10,10,100,20),"Generation: " + generation, guiStyle);
		GUI.Label(new Rect(10,40,100,20),"Trial Time: " + (int)elapsed, guiStyle);
	}

	// Use this for initialization
	void Start () {
		for(int i = 0; i < populationSize; i++){
			Vector3 pos = new Vector3(Random.Range(-13,13), Random.Range(-3.0f,5.0f),0);
			GameObject go = Instantiate(personPrefab, pos, Quaternion.identity);
			go.GetComponent<DNA>().r = Random.Range(0.0f,1.0f);
			go.GetComponent<DNA>().g = Random.Range(0.0f,1.0f);
			go.GetComponent<DNA>().b = Random.Range(0.0f,1.0f);
			population.Add(go);
		}
	}
	
	void BreedNewPopulation(){
		List<GameObject> newPopulation = new List<GameObject>();
		//create a new list and order the items of last generation by their gene time to die
		List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<DNA>().TimeToDie).ToList();

		population.Clear();

		//bread upper half of sorted list
		for( int i = (int) (sortedList.Count / 2.0f) - 1; i < sortedList.Count - 1; i++){
			//breeding is arbiturary, ichose this method
			population.Add(Breed(sortedList[i], sortedList[i + 1]));
    		population.Add(Breed(sortedList[i + 1], sortedList[i]));
		}

		for(int i = 0; i < sortedList.Count; i++){
			Destroy(sortedList[i]);
		}

		generation++;
	}


	GameObject Breed(GameObject parent1, GameObject parent2){
		Vector3 pos = new Vector3(Random.Range(-13,13), Random.Range(-3.0f,5.0f),0);
		GameObject go = Instantiate(personPrefab, pos, Quaternion.identity);

		//getting genes from parents
		DNA dna1 = parent1.GetComponent<DNA>();
		DNA dna2 = parent2.GetComponent<DNA>();

		//inheritence from the parents(purpose of genetic algorithms)
		//by picking a random number from 0 to 10 and setting 5 as a thrashold we have a 50/50 chance of picking each parent gene
		go.GetComponent<DNA>().r = Random.Range(0,10) < 5 ? dna1.r : dna2.r;
		go.GetComponent<DNA>().g = Random.Range(0,10) < 5 ? dna1.g : dna2.g;
		go.GetComponent<DNA>().b = Random.Range(0,10) < 5 ? dna1.b : dna2.b;
		
		return go;
	}

	// Update is called once per frame
	void Update () {
		elapsed += Time.deltaTime;
		if(elapsed > trialTime)
		{
			BreedNewPopulation();
			elapsed = 0;
		}	
	}
}
