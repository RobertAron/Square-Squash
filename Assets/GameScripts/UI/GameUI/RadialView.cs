using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class RadialView : MonoBehaviour {
	public ItemGeneratorController itemGeneratorController;
	public RadialController radialControllerPrefab;

	Dictionary<ColorPalette, RadialController> colorRadials = new Dictionary<ColorPalette, RadialController>();

	void Start () {
		if(itemGeneratorController==null||radialControllerPrefab==null)
		{
			throw new Exception("Radial View is missing require fields");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Dictionary<ColorPalette, float> cooldownValues = itemGeneratorController.GetCooldownValues();
		List<ColorPalette> colorsInGenerator = new List<ColorPalette>(cooldownValues.Keys);
		List<ColorPalette> colorsInRadials = new List<ColorPalette>(colorRadials.Keys);
		colorsInGenerator.Remove(ColorPalette.All);
		colorsInRadials.Remove(ColorPalette.All);
		foreach(ColorPalette color in colorsInGenerator){
			if(!colorRadials.ContainsKey(color))
			{
				GameObject newUIElement = Instantiate(radialControllerPrefab.gameObject,transform.position,transform.rotation,transform);
				RadialController newRadial = newUIElement.GetComponent<RadialController>();
				colorRadials.Add(color,newRadial);
				newUIElement.transform.SetSiblingIndex(0);
				newRadial.Initialize(ColorSchema.GetColor(color));
			}
			colorRadials[color].SetTimeRemaining(cooldownValues[color]);
		}
		foreach(ColorPalette color in colorsInRadials){
			if(!cooldownValues.ContainsKey(color))
			{
				GameObject radialWithoutCooldown = colorRadials[color].gameObject;
				Destroy(radialWithoutCooldown); 
				colorRadials.Remove(color);
			}
		}
	}
}
