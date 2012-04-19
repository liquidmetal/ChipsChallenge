struct PixelShaderOutput
{
	float4 rt1 : COLOR0;
	float4 rt2 : COLOR1;
	float4 rt3 : COLOR2;
	float4 rt4 : COLOR3;
};

float4 VertexShaderFunction(float3 Position : POSITION0) : POSITION0
{
	return float4(Position, 1);
}

PixelShaderOutput PixelShaderFunction()
{
    PixelShaderOutput ret;

	ret.rt1 = float4(0,0,0,0);
	ret.rt2 = float4(0,0,0,0);
	ret.rt3 = float4(0,0,0,0);
	ret.rt4 = float4(0,0,0,0);

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
