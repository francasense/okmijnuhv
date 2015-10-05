using UnityEngine;
using System.Collections;

public interface ICartHandler {

	Cart currentCart{ get; set; }

	T GetComponent<T>() where T : Component;

}
