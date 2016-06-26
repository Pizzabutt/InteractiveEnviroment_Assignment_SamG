using UnityEngine;
using System.Collections;

public class enviromentHandler : MonoBehaviour
{
	public enum EnvironmentType
	{
		fire,
		frozen,
		storm,
		forest
	};
	public EnvironmentType enviroType;

	public Light dirLight;
	public Color fireLightColor;
	public Color frozenLightColor;
	public Color stormLightColor;
	public Color forestLightColor;

	public FrostEffect frostPP;

	#region Stock
	void Start ()
	{
	
	}
	void Update ()
	{
		switch(enviroType)
		{
			case EnvironmentType.fire:
				fireZone(true);
				frozenZone(false);
				stormZone(false);
				forestZone(false);
				break;

			case EnvironmentType.frozen:
				fireZone(false);
				frozenZone(true);
				stormZone(false);
				forestZone(false);
				break;

			case EnvironmentType.storm:
				fireZone(false);
				frozenZone(false);
				stormZone(true);
				forestZone(false);
				break;

			case EnvironmentType.forest:
				fireZone(false);
				frozenZone(false);
				stormZone(false);
				forestZone(true);
				break;

			default:
				break;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.name.Contains("Fire"))
		{
			enviroType = EnvironmentType.fire;
		}
		if(other.name.Contains("Frozen"))
		{
			enviroType = EnvironmentType.frozen;
		}
		if(other.name.Contains("Storm"))
		{
			enviroType = EnvironmentType.storm;
		}
		if(other.name.Contains("Forest"))
		{
			enviroType = EnvironmentType.forest;
		}
	}
	#endregion

	public void fireZone(bool _active)
	{
		if(_active)
		{
			dirLight.color = Color.Lerp(dirLight.color, fireLightColor, 0.035f);
			dirLight.intensity = lerpFloat(dirLight.intensity, 0.25f, 0.35f);
		}
		else
		{
			dirLight.intensity = lerpFloat(dirLight.intensity, 1f, 0.35f);
		}
	}
	public void frozenZone(bool _active)
	{
		if(_active)
		{
			dirLight.color = Color.Lerp(dirLight.color, frozenLightColor, 0.035f);
			frostPP.FrostAmount = lerpFloat(frostPP.FrostAmount, 1, 0.03f);
		}
		else
		{
			frostPP.FrostAmount = lerpFloat(frostPP.FrostAmount, 0, 0.15f);
		}
	}
	public void stormZone(bool _active)
	{
		if(_active)
		{
			dirLight.color = Color.Lerp(dirLight.color, stormLightColor, 0.035f);
		}
		else
		{
			
		}
	}
	public void forestZone(bool _active)
	{
		if(_active)
		{
			dirLight.color = Color.Lerp(dirLight.color, forestLightColor, 0.035f);
		}
		else
		{

		}
	}

	float lerpFloat(float _input, float _target, float _lerpRate = 1f)
	{
		if(_input < _target)
		{
			_input += _lerpRate * Time.deltaTime;
			return _input;
		}
		if(_input > _target)
		{
			_input -= _lerpRate * Time.deltaTime;
			return _input;
		}
		else
		{
			return _target;
		}
	}
}
