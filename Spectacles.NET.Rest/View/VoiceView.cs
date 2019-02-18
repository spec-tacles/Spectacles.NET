using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class VoiceView : View
	{
		protected override string Route
			=> $"{APIEndpoints.VoiceRegions}";
		
		public VoiceView(RestClient client) : base(client)
		{
		}
	}
}