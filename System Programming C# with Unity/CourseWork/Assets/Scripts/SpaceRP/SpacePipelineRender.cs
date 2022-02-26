using UnityEngine;
using UnityEngine.Rendering;

namespace SpaceRenderPipeline
{
    public class SpacePipelineRender : RenderPipeline
    {
        private CameraRenderer _cameraRenderer = new CameraRenderer();

        bool useDynamicBatching, useGPUInstancing;

        public SpacePipelineRender(
            bool useDynamicBatching, bool useGPUInstancing, bool useSRPBatcher
        )
        {
            this.useDynamicBatching = useDynamicBatching;
            this.useGPUInstancing = useGPUInstancing;
            GraphicsSettings.useScriptableRenderPipelineBatching = useSRPBatcher;
            GraphicsSettings.lightsUseLinearIntensity = true;
        }

        protected override void Render(ScriptableRenderContext context, Camera[] cameras)
        {
            CamerasRender(context, cameras);
        }

        private void CamerasRender(ScriptableRenderContext context, Camera[] cameras)
        {
            foreach (var camera in cameras)
            {
                _cameraRenderer.Render(context, camera, useDynamicBatching, useGPUInstancing);
            }

        }
    }
}