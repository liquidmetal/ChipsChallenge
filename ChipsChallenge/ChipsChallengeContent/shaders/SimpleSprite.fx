sampler tex : register(s0);
sampler heightmap : register(s1);

float2 position;

struct PSO
{
	float4 color : COLOR0;
	float depth : DEPTH0;
};

PSO PixelShaderFunction(float2 uv: TEXCOORD0, float4 color : COLOR0)
{
	PSO ret;

	ret.color = tex2D(heightmap, uv);
	ret.depth = tex2D(heightmap, uv).r/255.0f;// - uv.y;
    return ret;
}

technique Technique1
{
    pass Pass1
    {
		ZEnable = TRUE;
		ZWriteEnable = TRUE;
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
