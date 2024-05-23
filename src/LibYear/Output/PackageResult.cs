﻿using System.Text.Json.Serialization;
using LibYear.Core;

namespace LibYear.Output;

internal sealed record PackageResult
{
	[JsonPropertyName("packageName")]
	public string PackageName { get; set; } = string.Empty;
	[JsonPropertyName("currentVersion")]
	public DisplayVersion? CurrentVersion { get; init; }
	[JsonPropertyName("latestVersion")]
	public DisplayVersion? LatestVersion { get; init; }
	[JsonConverter(typeof(DoubleFormatter))]
	[JsonPropertyName("daysBehind")]
	public double DaysBehind { get; init; }
	[JsonConverter(typeof(DoubleFormatter))]
	[JsonPropertyName("yearsBehind")]
	public double YearsBehind { get; init; }

	public PackageResult(Result result)
	{
		PackageName = result.Name;
		YearsBehind = result.YearsBehind;
		DaysBehind = result.DaysBehind;
		CurrentVersion = result.Installed is null ? null : new DisplayVersion(result.Installed);
		LatestVersion = result.Latest is null ? null : new DisplayVersion(result.Latest);
	}
}