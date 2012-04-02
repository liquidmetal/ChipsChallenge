struct PixelShaderOutput
{
	float4 color : COLOR0;		// Standard RGBA
	float4 depth : COLOR1;		// 24bits for 'height', 8 bits for stencil
	//float4 normal: COLOR2;	// 24 bits for normal
};

float4 VertexShaderFunction(float3 Position : POSITION0) : POSITION0
{
	return float4(Position, 1);
}

PixelShaderOutput PixelShaderFunction()
{
    PixelShaderOutput ret;

	ret.color = 0.0f;
	ret.color.a = 0.0f;

	// Set depth to 0 and stencil to 1 (draw all)
	ret.depth = float4(0, 0, 0, 1);

	//ret.normal.rgb = 0.5f;

	

	return ret;
}

technique Technique1
{
    pass Pass1
    {
		VertexShader = compile vs_2_0 VertexShaderFunction();
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
