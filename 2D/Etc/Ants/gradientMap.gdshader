shader_type canvas_item;
render_mode unshaded;

uniform sampler2D gradient : hint_black;
uniform float mixAmount = 1.0;

void fragment(){
	vec4 inputColor = texture(TEXTURE, UV);
	float grayscaleValue = dot(inputColor.rgb, vec3(0.299, 0.587, 0.114));
	vec3 sampledColor = texture(gradient, vec2(grayscaleValue, 0.0)).rgb;
	
	COLOR.rgb = mix(inputColor.rgb, sampledColor, mixAmount);
	COLOR.a = inputColor.a;
}
