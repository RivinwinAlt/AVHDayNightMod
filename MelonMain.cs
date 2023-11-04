using MelonLoader;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;

namespace AVHDayNightMod
{
	
	public class MelonMain : MelonMod
	{
		internal static string modFolder = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

		public override void OnInitializeMelon()
		{
		}

		public override void OnSceneWasInitialized(int buildIndex, string sceneName)
		{
			// Create a new material
			Shader newShader = Shader.Find("Skybox/Cubemap Extended");
			if (newShader == null)
			{
				LoggerInstance.Msg("Shader could not be found");
				return;
			}
			Material newMaterial = new Material(newShader);
			if (newMaterial == null)
			{
				LoggerInstance.Msg("Material could not be created");
				return;
			}
			newMaterial.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 1f));
			newMaterial.SetTexture("_Tex", ReflectionProbe.defaultTexture);

			// Set the skybox material
			RenderSettings.skybox = newMaterial;

			// Set light intensity
			GameObject dLight = GameObject.Find("Directional Light");
			dLight.GetComponent<Light>().intensity = 1f;

			// Set fog111111111111111111111111111111111
			RenderSettings.fogColor = new Color(0.1764f, 0.8784f, 0.9255f, 1f);
			RenderSettings.fogDensity = 0.001f;
		}

		public override void OnUpdate()
		{

		}

		public override void OnDeinitializeMelon()
		{
		}
	}
}