using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class VoiceView : View
	{
		public VoiceView(RestClient client) : base(client)
		{
		}

		protected override string Route
			=> $"{APIEndpoints.VoiceRegions}";
	}
}
