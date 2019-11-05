using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// TODO 1: Create a simple class to contain one entry in the blackboard
// should at least contain the gameobject, position, timestamp and a bool
// to know if it is in the past memory

public class BlackBoardEntry
{
    [HideInInspector]
    public GameObject obj;
    [HideInInspector]
    public Vector3 position;
    [HideInInspector]
    public float timestamp;
    [HideInInspector]
    public bool pastMemory;

    public BlackBoardEntry(GameObject obj, Vector3 position)
    {
        this.obj = obj;
        this.position = position;
        this.timestamp = Time.time;
        this.pastMemory = false;
    }
}

public class AIMemory : MonoBehaviour {

	public GameObject Cube;
	public Text Output;

    // TODO 2: Declare and allocate a dictionary with a string as a key and
    // your previous class as value
    private Dictionary<string, BlackBoardEntry> knowledgeBlackboard;

	// TODO 3: Capture perception events and add an entry if the player is detected
	// if the player stop from being seen, the entry should be "in the past memory"

	// Use this for initialization
	void Start ()
    {
        knowledgeBlackboard = new Dictionary<string, BlackBoardEntry>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 4: Add text output to the bottom-left panel with the information
        // of the elements in the Knowledge base

        string outputString = "";

        foreach (string entryKey in knowledgeBlackboard.Keys)
        {
            //TODO: Iterate instead of doing a TryGetValue every time
            BlackBoardEntry entry;
            knowledgeBlackboard.TryGetValue(entryKey, out entry);
            outputString += "GameObject: " + entry.obj.name + "\n";
            outputString += "Position  : " + entry.position + "\n";
            outputString += "Timestamp : " + entry.timestamp + "\n";
            outputString += "In Memory : " + entry.pastMemory + "\n";
        }

		Output.text = outputString;
	}

    public BlackBoardEntry HasSeen(GameObject obj)
    {
        BlackBoardEntry entry = null;
        if (knowledgeBlackboard.TryGetValue(obj.name, out entry))
        {
            return entry;
        }
        return null;
    }

    public void LostVision(GameObject obj)
    {
        BlackBoardEntry entry = null;
        knowledgeBlackboard.TryGetValue(obj.name, out entry);
        if (entry != null)
        {
            entry.pastMemory = true;
        }
        else
        {
            Debug.LogError("AI Lost vision of something they didn't see.");
        }
    }

    void SeeingObject(GameObject gameObject)
    {
        BlackBoardEntry entry = HasSeen(gameObject);
        if (entry != null)
        {
            //Updates entry
            entry.position = gameObject.transform.position;
            entry.timestamp = Time.time;
            entry.pastMemory = false;
        }
        else
        {
            //Creates new entry
            entry = new BlackBoardEntry(gameObject, gameObject.transform.position);
            knowledgeBlackboard.Add(gameObject.name, entry);
        }
    }

    void PerceptionEvent(PerceptionEvent ev)
    {
        if (ev.type == global::PerceptionEvent.types.NEW)
        {
            SeeingObject(ev.gameObject);
        }
        else
        {
            LostVision(ev.gameObject);
        }
    }
}
