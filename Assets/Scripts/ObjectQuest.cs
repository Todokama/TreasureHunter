using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectQuest : MonoBehaviour
{
	public Quest_Event QEvent;
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			QEvent.end_Quest1 = true;

		}
	}

}
