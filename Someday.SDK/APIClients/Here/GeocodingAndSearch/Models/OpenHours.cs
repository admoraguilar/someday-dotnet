using System;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record OpenHours
	{
		public Category[] Categories { get; init; } = Array.Empty<Category>();
		public string[] Text { get; init; } = Array.Empty<string>();
		public bool IsOpen { get; init; } = false;
		public OpenHoursStructured[] Structured { get; init; } = Array.Empty<OpenHoursStructured>();
	}
}
