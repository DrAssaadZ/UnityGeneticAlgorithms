using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//helpful class
public class DNA {

	List<int> genes = new List<int>();
	int dnaLength = 0;
	int maxValues = 0;

	//constractor
	public DNA(int l, int v)
	{
		dnaLength = l;
		maxValues = v;
		SetRandom();	//setting the values of the genes randomly
	}

	public void SetRandom()
	{
		genes.Clear();
		for(int i = 0; i < dnaLength; i++)
		{
			genes.Add(Random.Range(0, maxValues));
		}
	}

	//set a specific gene in a specific position
	public void SetInt(int pos, int value)
	{
		genes[pos] = value;
	}

	//seetin dna from parent's dna, parent 11 will give th first half and the other give the last half
	public void Combine(DNA d1, DNA d2)
	{
		for(int i = 0; i < dnaLength; i++)
		{
			if(i < dnaLength/2.0)
			{
				int c = d1.genes[i];
				genes[i] = c;
			}
			else
			{
				int c = d2.genes[i]; 
				genes[i] = c;
			}
		}
	}

	//altering a gene randomly
	public void Mutate()
	{
		genes[Random.Range(0,dnaLength)] = Random.Range(0, maxValues);
	}

	// return the value of a specific gene
	public int GetGene(int pos)
	{
		return genes[pos];
	}

}
