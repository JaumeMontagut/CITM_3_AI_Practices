﻿using UnityEngine;
using System.Collections;

public class AIPerceptionManager : MonoBehaviour {

	public GameObject Alert;

    void PerceptionEvent (PerceptionEvent ev) {

		if(ev.type == global::PerceptionEvent.types.NEW)
		{
			Debug.Log("Saw something NEW");
			Alert.SetActive(true);
		}
		else
		{
			Debug.Log("LOST something");
			Alert.SetActive(false);
		}
	}
}
