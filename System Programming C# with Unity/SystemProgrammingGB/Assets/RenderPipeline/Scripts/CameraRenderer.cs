using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public partial class CameraRenderer
{
    private ScriptableRenderContext _context;
    private Camera _camera;

    private const string _bufferName = "Camera Render";
    private readonly CommandBuffer _commandBuffer = new CommandBuffer { name = _bufferName };
    
    private CullingResults _cullingResult;

    private static readonly List<ShaderTagId> drawingShaderTagIds = new List<ShaderTagId> { new ShaderTagId("SRPDefaultUnlit"), };
    public void Render(ScriptableRenderContext context, Camera camera)
    {
        _camera = camera;
        _context = context;

        PrepareBuffer();
        PrepareForSceneWindow();

        if(!Cull())
        {
            return;
        }

        ApplySettings();
        DrawVisible();
        DrawUnsupportedShaders();
        DrawGizmos();
        Submit();
    }

    private void Submit()
    {
        _commandBuffer.EndSample(SampleName);
        ExecuteCommandBuffer();
        _context.Submit();
    }

    private void ApplySettings()
    {        
        _context.SetupCameraProperties(_camera);
        _commandBuffer.ClearRenderTarget(true, true, Color.clear);
        _commandBuffer.BeginSample(SampleName);
        ExecuteCommandBuffer();
    }

    private DrawingSettings CreateDrawingSettings(List<ShaderTagId> shaderTags, SortingCriteria sortingCriteria, out SortingSettings sortingSettings)
    {
        sortingSettings = new SortingSettings(_camera)
        {
            criteria = sortingCriteria,
        };
        var drawingSettings = new DrawingSettings(shaderTags[0], sortingSettings);
        for (var i = 1; i < shaderTags.Count; i++)
        {
            drawingSettings.SetShaderPassName(i, shaderTags[i]);
        }
        return drawingSettings;
    }

    private void ExecuteCommandBuffer()
    {
        _context.ExecuteCommandBuffer(_commandBuffer);
        _commandBuffer.Clear();
    }

    private void DrawVisible()
    {
        var drawingSettings = CreateDrawingSettings(drawingShaderTagIds, SortingCriteria.CommonOpaque, out var sortingSettings);
        var filteringSettings = new FilteringSettings(RenderQueueRange.opaque);

        _context.DrawRenderers(_cullingResult, ref drawingSettings, ref filteringSettings);

        _context.DrawSkybox(_camera);

        sortingSettings.criteria = SortingCriteria.CommonTransparent;
        drawingSettings.sortingSettings = sortingSettings;
        filteringSettings.renderQueueRange = RenderQueueRange.transparent;

        _context.DrawRenderers(_cullingResult, ref drawingSettings, ref filteringSettings);
    }

    private bool Cull()
    {
        if(_camera.TryGetCullingParameters(out var parameters))
        {
            _cullingResult = _context.Cull(ref parameters);
            return true;
        }
        else
            return false;
    }
}