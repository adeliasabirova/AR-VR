using UnityEngine;
using UnityEngine.Rendering;


namespace SpaceRenderPipeline
{
    [CreateAssetMenu(menuName = "Rendering/SpacePipelineRenderAsset")]
    public class SpacePipelineRendererAsset : RenderPipelineAsset
    {
        [SerializeField]
        bool useDynamicBatching = true, useGPUInstancing = true, useSRPBatcher = true;
        protected override RenderPipeline CreatePipeline()
        {
            return new SpacePipelineRender(useDynamicBatching, useGPUInstancing, useSRPBatcher);
        }
    }
}