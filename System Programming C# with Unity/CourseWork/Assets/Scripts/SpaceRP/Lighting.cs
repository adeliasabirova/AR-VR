using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Lighting
{
	const string _bufferName = "Lighting";

	const int _maxDirLightCount = 4;

	static int
		_dirLightCountId = Shader.PropertyToID("_DirectionalLightCount"),
		_dirLightColorsId = Shader.PropertyToID("_DirectionalLightColors"),
		_dirLightDirectionsId = Shader.PropertyToID("_DirectionalLightDirections");

	static Vector4[]
		_dirLightColors = new Vector4[_maxDirLightCount],
		_dirLightDirections = new Vector4[_maxDirLightCount];

	CommandBuffer buffer = new CommandBuffer
	{
		name = _bufferName
	};

	CullingResults cullingResults;

	public void Setup(
		ScriptableRenderContext context, CullingResults cullingResults
	)
	{
		this.cullingResults = cullingResults;
		buffer.BeginSample(_bufferName);
		SetupLights();
		buffer.EndSample(_bufferName);
		context.ExecuteCommandBuffer(buffer);
		buffer.Clear();
	}

	void SetupLights()
	{
		NativeArray<VisibleLight> visibleLights = cullingResults.visibleLights;
		int dirLightCount = 0;
		for (int i = 0; i < visibleLights.Length; i++)
		{
			VisibleLight visibleLight = visibleLights[i];
			if (visibleLight.lightType == LightType.Directional)
			{
				SetupDirectionalLight(dirLightCount++, ref visibleLight);
				if (dirLightCount >= _maxDirLightCount)
				{
					break;
				}
			}
		}

		buffer.SetGlobalInt(_dirLightCountId, dirLightCount);
		buffer.SetGlobalVectorArray(_dirLightColorsId, _dirLightColors);
		buffer.SetGlobalVectorArray(_dirLightDirectionsId, _dirLightDirections);
	}

	void SetupDirectionalLight(int index, ref VisibleLight visibleLight)
	{
		_dirLightColors[index] = visibleLight.finalColor;
		_dirLightDirections[index] = -visibleLight.localToWorldMatrix.GetColumn(2);
	}
}