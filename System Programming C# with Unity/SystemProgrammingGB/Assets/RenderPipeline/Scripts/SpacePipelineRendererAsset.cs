using UnityEngine;
using UnityEngine.Rendering;

namespace SpaceRenderPipeline
{
    [CreateAssetMenu(menuName = "Rendering/SpacePipelineRenderAsset")]
    public class SpacePipelineRendererAsset : RenderPipelineAsset
    {
        protected override RenderPipeline CreatePipeline()
        {
            return new SpacePipelineRender(); ;
        }
    }
}