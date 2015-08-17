using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;

public class LoadTown : MonoBehaviour 
{
	private int[] goods = new int[10];
	public GameObject titleBox;
	public GameObject subtitleBox;
	public GameObject descriptionBox;
	public GameObject dockButton;
	private XmlDocument towns = new XmlDocument();

	// Loads in the town's name and subname via a public variable in the script, the town's 
	// description is stored in XML being a bit larger than the names though it may or may not
	// be a good idea to switch everything to XML later. Probably not as it'll make the 
	// inspector about a million times harder to follow and I'll have to switch between looking 
	// at what goes where in the XML file and stuff.
	public void load(string name, string subname, string townID, int[] goods)
	{
		towns.Load ("Assets/OverWorld/Town/TownDescriptions");
		XmlNode node = towns.SelectSingleNode("/root/town[@id='" + townID + "']");
		string description = node.InnerText;
		titleBox.GetComponent<Text>().text = name;
		subtitleBox.GetComponent<Text>().text = subname;
		descriptionBox.GetComponent<Text>().text = description; 
	}

	public void trade()
	{
	}

	// Get this to work with the E button too methinks.
	public void undock()
	{
		Time.timeScale = 1;
		dockButton.SetActive (false);
		gameObject.SetActive (false);
	}
}
