using System;

namespace Spectacles.NET.Types
{
	[Flags]
	public enum UserFlags
	{
		NONE = 0,
		HYPESQUAD_EVENTS = 1 << 2,
		HOUSE_BRAVERY = 1 << 6,
		HOUSE_BRILLIANCE = 1 << 7,
		HOUSE_BALANCE = 1 << 8
	}
}
