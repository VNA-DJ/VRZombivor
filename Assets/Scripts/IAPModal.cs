using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPModal : MonoBehaviour {
	public GameObject[] buttons;

	public void BuyMachineGun () {
		buttons [0].SetActive (false);
		PlayerPrefs.SetInt ("Buy" + Application.loadedLevel, 1);
		PlayerPrefs.Save();
		IAPManager.Instance.Machinegun();
	}

	public void BuyKalashnikov () {
		buttons [1].SetActive (false);
		IAPManager.Instance.Kalashnikov();
	}

	public void BuyAssaultRifle () {
		buttons [2].SetActive (false);
		IAPManager.Instance.Modified_M4a1();
	}

	public void BuyAssaultRifle2 () {
		buttons [3].SetActive (false);
		IAPManager.Instance.Modified_Rifle();
	}

	public void BuySMG2 () {
		buttons [4].SetActive (false);
		IAPManager.Instance.Mp5();
	}

	public void BuyRevolver () {
		buttons [5].SetActive (false);
		IAPManager.Instance.Revolver();
	}
}
