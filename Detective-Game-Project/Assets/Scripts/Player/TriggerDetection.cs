using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
	public GameObject DollyHuman;
	public GameObject DollyAnimal;

	private GameObject LastActivePFollow;
	private GameObject LastActiveAFollow;

	private bool CameraCachedP, CameraCachedA;

	public static GameObject CurrentTrigger = null;

	private void Start()
	{
		// Set the base priorities of the original follows
		GameManager.Instance.CameraFollow.GetComponent<Cinemachine.CinemachineFreeLook>().Priority = 11;
		GameManager.Instance.CameraFollowP2.GetComponent<Cinemachine.CinemachineFreeLook>().Priority = 11;

		// Set the base priorities of the new follows
		DollyHuman.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 10;
		DollyAnimal.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 10;
	}



	// Set the REGULAR camera priorities to 11!
	private void OnTriggerEnter(Collider other)
	{
		if (ReferenceEquals(other.gameObject, GameManager.Instance.Human))
		{
			if (!CameraCachedP)
			{
				//Reset();
				LastActivePFollow = Scripts.GameManager.Instance.CameraFollow;
				CameraCachedP = true;
			}

			Scripts.GameManager.Instance.CameraFollow = DollyHuman;


			DollyHuman.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority =
				LastActivePFollow.GetComponent<Cinemachine.CinemachineFreeLook>().Priority + 1; // 12

			// Increase the Animal's priority so that the camera doesnt't get overtaken by current
			if (Scripts.GameManager.Instance.CameraFollowP2.GetComponent<Cinemachine.CinemachineFreeLook>() != null)
				Scripts.GameManager.Instance.CameraFollowP2.GetComponent<Cinemachine.CinemachineFreeLook>().Priority =
					DollyHuman.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority + 1; // 13

			DollyHuman.GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = other.transform;
			DollyHuman.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = other.transform;


		}
		if (ReferenceEquals(other.gameObject, GameManager.Instance.Animal))
		{
			if (!CameraCachedA)
			{
				//Reset();
				LastActiveAFollow = Scripts.GameManager.Instance.CameraFollowP2;
				CameraCachedA = true;
			}

			Scripts.GameManager.Instance.CameraFollowP2 = DollyAnimal;

			DollyAnimal.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority =
				LastActiveAFollow.GetComponent<Cinemachine.CinemachineFreeLook>().Priority + 1; // 12

			// Increase the Player's priority so that the camera doesnt't get overtaken by current
			if (Scripts.GameManager.Instance.CameraFollow.GetComponent<Cinemachine.CinemachineFreeLook>() != null)
				Scripts.GameManager.Instance.CameraFollow.GetComponent<Cinemachine.CinemachineFreeLook>().Priority =
					DollyAnimal.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority + 1; // 13

			DollyAnimal.GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = other.transform;
			DollyAnimal.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = other.transform;
		}


	}

	private void OnTriggerExit(Collider other)
	{
		if (ReferenceEquals(other.gameObject, GameManager.Instance.Human))
		{
			if (!CameraCachedP)
				return;

			Debug.Log($"Exit : {GetInstanceID()}");
			Scripts.GameManager.Instance.CameraFollow = LastActivePFollow;

			DollyHuman.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 10;

			if (Scripts.GameManager.Instance.CameraFollowP2.GetComponent<Cinemachine.CinemachineFreeLook>() != null)
				Scripts.GameManager.Instance.CameraFollowP2.GetComponent<Cinemachine.CinemachineFreeLook>().Priority = 11;

			CameraCachedP = false;
		}
		if (ReferenceEquals(other.gameObject.transform.root.gameObject, GameManager.Instance.Animal))
		{
			if (!CameraCachedA)
				return;

			Scripts.GameManager.Instance.CameraFollowP2 = LastActiveAFollow;

			DollyAnimal.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 10;

			if (Scripts.GameManager.Instance.CameraFollow.GetComponent<Cinemachine.CinemachineFreeLook>() != null)
				Scripts.GameManager.Instance.CameraFollow.GetComponent<Cinemachine.CinemachineFreeLook>().Priority = 11;

			CameraCachedA = false;
		}
	}
}